//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MsSqlFactorySuite – База данных MS SQL.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public sealed class MsSqlFactorySuite(IMetadata md, IDatabase db) : DatabaseFactorySuite(md, db)
{
    public override void CreateDatabase(string connectionString, Stream? configuration)
    {
        var dbname = _db.DatabaseName;
        _db.Close();
        var success = false;
        var newdb = new MsSqlDatabase(Regex.Replace(connectionString, @"INITIAL CATALOG=.*?[;$]", "Initial Catalog=master;", RegexOptions.IgnoreCase));
        try
        {
            newdb.Open();
            if (!newdb.Query("EXEC sp_databases").Rows.Cast<DataRow>().Any(r => r[0].ToString().ToUpper() == dbname.ToUpper()))
            {
                newdb.Exec(@$"CREATE DATABASE {LQ}{dbname}{RQ} COLLATE Cyrillic_General_CI_AS; ALTER DATABASE [{dbname}] SET RECOVERY SIMPLE;");
                success = true;
            }
        }
        finally
        {
            newdb.Close();
        }
        Thread.Sleep(5000); // задержка на инициализацию БД
        if (success && configuration != null)
        {
            _db = new MsSqlDatabase(connectionString);
            _db.Open();
            CleanEnvironment(_db);
        }
    }
}
