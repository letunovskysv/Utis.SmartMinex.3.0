//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: PgSqlDatabase – База данных PostgreSql.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public sealed class PgSqlFactorySuite(IMetadata md, IDatabase db) : DatabaseFactorySuite(md, db)
{
    #region Declarations

    protected override SortedList<int, string> _maptypes => new()
        {
            { typeof(int).FullName.GetHashCode(), "int NOT NULL DEFAULT " + Activator.CreateInstance<int>() },
            { typeof(int?).FullName.GetHashCode(), "int NULL" },
            { typeof(long).FullName.GetHashCode(), "bigint NOT NULL DEFAULT " + Activator.CreateInstance<long>() },
            { typeof(long?).FullName.GetHashCode(), "bigint NULL" },
            { typeof(bool).FullName.GetHashCode(), "boolean NOT NULL DEFAULT " + Activator.CreateInstance<bool>() },
            { typeof(bool?).FullName.GetHashCode(), "boolean NULL" },
            { typeof(DateTime).FullName.GetHashCode(), "timestamp(3) with time zone NOT NULL" },
            { typeof(DateTime?).FullName.GetHashCode(), "timestamp(3) with time zone NULL" },
            { typeof(string).FullName.GetHashCode(), "varchar(256) NOT NULL" },
            { typeof(byte[]).FullName.GetHashCode(), "bytea NOT NULL" },
            { typeof(TOptions).FullName.GetHashCode(), "text NULL" },
            { @"bit".GetHashCode(), "boolean" },
            { @"float(4)".GetHashCode(), "real" },
            { @"float(8)".GetHashCode(), "double precision"},
            { @"tinyint".GetHashCode(), "smallint" },
            { @"\btimestamp\b".GetHashCode(), "bytea" },
            { @"rowversion".GetHashCode(), "bigint" },
            { @"datetime".GetHashCode(), "timestamp(3) with time zone" },
            { @"nvarchar(max)".GetHashCode(), "text" },
            { @"nvarchar".GetHashCode(), "varchar" },
            { @"varbinary\(\w+\)".GetHashCode(), "bytea" },
            { @"varbinary".GetHashCode(), "bytea" }
        };

    #endregion Declarations

    public override void CreateDatabase(string connectionString, Stream? configuration)
    {
        var dbname = _db.DatabaseName;
        _db.Close();
        var success = false;
        var newdb = new PgSqlDatabase(Regex.Replace(connectionString, @"DATABASE=.*?[;$]", "Database=postgres;", RegexOptions.IgnoreCase));
        try
        {
            newdb.Open();
            if (!newdb.Query("SELECT datname FROM pg_database").Rows.Cast<DataRow>().Any(r => r[0].ToString().ToUpper() == dbname.ToUpper()))
            {
                // TEMPLATE='template0' - если указать другой или опустить получим ошибку: new collation (Russian_Russia.1251)(ru_RU.UTF-8) is incompatible with the collation of the template database (English_United States.1252)
                newdb.Exec(@$"CREATE DATABASE {LQ}{dbname}{RQ} WITH OWNER=postgres ENCODING='UTF8' LC_COLLATE='Russian_Russia.1251' LC_CTYPE='Russian_Russia.1251' TABLESPACE=pg_default CONNECTION LIMIT=-1 TEMPLATE='template0';");
                success = true;
            }
        }
        finally
        {
            newdb.Close();
        }
        Thread.Sleep(1000); // задержка на инициализацию БД
        if (success && configuration != null)
        {
            var dbinit = new DbInitFile(configuration);
            _db = new PgSqlDatabase(connectionString);
            _db.Open();
            CleanEnvironment(_db);
            CreateEnvironment(_db, dbinit);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("warn: " + string.Format(STR.InitDatabase, _db.DatabaseName));
            Console.ResetColor();
        }
    }
}