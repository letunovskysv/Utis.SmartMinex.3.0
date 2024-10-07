//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Metadata – Класс метаданных Системы, обеспечивает доступ к данным БД.
// Standalone
//--------------------------------------------------------------------------------------------------
#pragma warning disable CS8601
#region Using
using System.Collections.Concurrent;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Helpers;
#endregion Using

namespace Utis.SmartMinex.Data;

/// <summary> Метаданные.</summary>
sealed partial class Metadata : SmartModule, IMetadata
{
    #region Declarations

    readonly string? _dbprovider;
    readonly string? _connstr;
    string? _dbname;
    readonly string? _dbinitfile;

    readonly System.Reflection.ConstructorInfo _dbcreator;
    readonly System.Reflection.ConstructorInfo _fscreator;

    #endregion Declarations

    #region Properties

    /// <summary> Загрузчики метаданных.</summary>
    internal ConcurrentDictionary<long, IDataHelper> Helpers { get; } = [];
    public IObjectCollection Objects { get; private set; }

    public TNode Node { get; private set; }
    public string Version { get; }

    #endregion Properties

    public Metadata(IRuntime runtime, string? dataProvider, string? connectionString, string? configuration)
        : base(runtime)
    {
        Name = "Служба базы данных";
        _dbprovider = dataProvider;
        _connstr = connectionString;
        _dbinitfile = TPath.Combine(runtime.WorkingDirectory, configuration);
        Objects = runtime.GetType().GetProperty("Objects").GetValue(runtime) as IObjectCollection;

        var dbtype = _dbprovider.ToType(null) is Type dbt ? dbt : default!;
        _dbcreator = dbtype != null && !string.IsNullOrWhiteSpace(_connstr)
            ? dbtype.GetConstructors().First()
            : throw new Exception(STR.FailedCreateDatabaseConnection);

        var fstype = dbtype?.Assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IFactorySuite)));
        _fscreator = fstype != null
            ? fstype.GetConstructors().First()
            : throw new Exception(STR.FailedCreateFactorySuite);
    }

    public override bool OnStart()
    {
        if (_dbcreator != null && _fscreator != null && CreateDatabase() is IDatabase db)
        {
            var attempt = 1;
            while (attempt-- > 0) // Проверка подключения к БД -->
                try
                {
                    db.Open();
                    attempt = 0;
                    _dbname = db.DatabaseName;

                    AmendDatabase();
                    LoadMetadata();
                    return true;
                }
                catch (DbNotFoundException ex)
                {
                    if (attempt >= 0)
                    {
                        Runtime.Send(MSG.WarningMessage, ProcessId, 0, "Создание базы данных " + db.DatabaseName + ".");
                        if (CreateFactorySuite(this, db) is IDatabaseFactory fs)
                            using (var dbinit = new FileStream(_dbinitfile, FileMode.Open))
                                fs.CreateDatabase(_connstr, dbinit);
                    }
                    else
                    {
                        Runtime.Send(MSG.ErrorMessage, ProcessId, 0, "Ошибка создания базы данных " + db.DatabaseName + ": " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Runtime.Send(MSG.ErrorMessage, ProcessId, 0, "Ошибка поделючения к базе данных " + db.DatabaseName + ": " + ex.Message
                        + (" <<< " + ex.InnerException?.Message) ?? string.Empty);
                }
                finally
                {
                    db.Close();
                }
        }
        return false;
    }

    public override Task ExecuteProcessAsync(CancellationToken stoppingToken)
    {
        return base.ExecuteProcessAsync(stoppingToken);
    }
}
#pragma warning restore CS8601
