//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DatabaseFactorySuite – Доступ к базе данных.
// Данные и инструкции по умолчанию для БД PostgreSql.
//--------------------------------------------------------------------------------------------------
#region Using
using Dapper;
using System.Diagnostics;
using Utis.SmartMinex.FactorySuite;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public abstract partial class DatabaseFactorySuite: IFactorySuite, IDatabaseFactory
{
    #region Declarations

    static readonly string SQLDATEFORMAT = "yyyyMMdd HH:mm:ss.fff";
    static readonly DateTime SQLMINDATETIME = new(1900, 1, 1);

    protected virtual SortedList<int, string> _maptypes => throw new NotImplementedException();

    protected IMetadata _md;
    protected IDatabase _db;
    XState _state;
    TObject _obj;
    List<XField> _fields;
    List<XFrom> _from;
    List<XWhere> _where;
    List<Type> _types;
    List<string> _ids;

    List<string> _sql;

    #endregion Declarations

    #region Properties

    public virtual string LQ => "\"";
    public virtual string RQ => "\"";

    public IDatabase Database => _db;

    public virtual string DefaultScheme => "public";

    public virtual string Version => _db.Scalar("SELECT version()").ToString();

    public virtual int ConnectionCount => int.Parse(_db.Scalar("SELECT COUNT(*) FROM pg_stat_activity WHERE pg_stat_activity.datname=current_database() AND pid<>pg_backend_pid()").ToString());

    public string DatabaseName => _db.DatabaseName;

    public virtual string DatabaseSize => _db.Scalar("SELECT pg_size_pretty(pg_database_size(current_database()))").ToString();

    #endregion Properties

    public DatabaseFactorySuite(IMetadata md, IDatabase db)
    {
        _md = md;
        _db = db;
        SqlMapper.AddTypeHandler(new TOptionsTypeHandler());
    }

    public void Dispose()
    {
        _db?.Close();
        _db?.Dispose();
        GC.SuppressFinalize(this);
    }

    public void Amend(Stream configuration)
    {
        var sw = Stopwatch.StartNew();
        var dbinit = new DbInitFile(configuration);
        CreateEnvironment(_db, dbinit);

        sw.Stop();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("warn: " + string.Format(STR.AmendDatabase, _db.DatabaseName, sw.ElapsedMilliseconds));
        Console.ResetColor();
    }

    /// <summary> Подготовка данных к новой инструкций.</summary>
    void Clear()
    {
        _fields = [];
        _from = [];
        _where = [];
        _types = [];
        _ids = [];
    }

    public IFactorySuite Use(IDatabase db)
    {
        _db.Close();
        _db = db;
        return this;
    }

    public virtual string AsSqlValue(object? value)
    {
        if (value == null || value == DBNull.Value)
            return "NULL";

        switch (value)
        {
            case DateTime dt:
                return dt < SQLMINDATETIME
                    ? "'19000101'"
                    : "'" + dt.ToString(SQLDATEFORMAT) + "'";

            case TimeSpan ts:
                return "'" + ts.ToString() + "'";

            case string str:
                return string.Concat("N'", str.Replace("'", "''"), "'");

            case bool bval:
                return bval ? "true" : "false";

            case byte:
            case short:
                return string.Concat(value.ToString(), "::smallint");

            case float fval:
                return float.IsNaN(fval) ? "NULL" : fval.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case double dval:
                return double.IsNaN(dval) ? "NULL" : dval.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case decimal dec:
                return dec.ToString(System.Globalization.CultureInfo.InvariantCulture);

            case byte[] arr:
                return string.Concat("'\\x", string.Join(null, arr.Select(b => b.ToString("X2")).ToArray()), "'");
        }
        if (!value.GetType().IsPrimitive)
            return value.ToString();

        return value.ToString().Replace(',', '.');
    }

    #region Nested types

    enum XState
    {
        None,
        Select
    }

    [DebuggerDisplay("Name={Name}, Alias={Display}, IsKey={IsKey}")]
    sealed class XField
    {
        public string Name;

        public XField(string alias, TAttribute? ai)
        {
            Name = string.Concat(alias, '.', ai?.Factory.Name ?? "*");
        }
    }

    struct XFrom
    {
        public string Join;
        public string Name;
        public string Alias;
        public string? Where;

        public XFrom(string join, string name, string alias)
        {
            Join = join;
            Name = string.Concat(name, " AS ", alias);
            Alias = alias;
        }

        public XFrom(string join, string name, string refalias, string key, string alias, string value)
            : this(join, name, refalias)
        {
            Where = string.Concat(" ON ", refalias, '.', key, '=', alias, '.', value);
        }

        public override string ToString() => string.Concat(Join, Name);
    }

    struct XWhere(string join, string condition)
    {
        public string Join = join;
        public string Condition = condition;

        public override string ToString() => string.Concat(Join, Condition);
    }

    #endregion Nested types
}
