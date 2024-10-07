//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: PgSqlDatabase – База данных PostgreSql.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Npgsql;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public sealed class PgSqlDatabase(string connectionString) : TDatabase(connectionString)
{
    #region Properties

    public override string DatabaseName => Regex.Match(_connstr, @"(?<=INITIAL CATALOG=|Database=).*?(?=;|$)", RegexOptions.IgnoreCase).Value;

    #endregion Properties

    public override IDatabase Open()
    {
        _conn = new NpgsqlConnection(string.Concat(_connstr, ";Application Name=smsrv",
          string.IsNullOrWhiteSpace(ApplicationName) ? string.Empty : " - " + ApplicationName));

        try
        {
            _conn.Open();
        }
        catch (NpgsqlException ex)
        {
            if (ex.ErrorCode == SQLERR_FAILED && ex.InnerException is SocketException)
                throw new DbException(DbException.NO_INSTANCE, ex);
            else if (ex.ErrorCode == SQLERR_FAILED && ex is PostgresException sql && sql.SqlState == "3D000")
                throw new DbNotFoundException(DbException.NO_DATABASE, ex);
            else
                throw;
        }
        return this;
    }

    public override DataTable? Query(string sql, params object?[] args)
    {
        var ds = new DataSet();
        var stmt = args.Length == 0 ? sql : string.Format(sql, args);
        try
        {
            lock (_syncRoot)
            {
                using var cmd = new NpgsqlDataAdapter(stmt, (NpgsqlConnection)_conn);
                cmd.Fill(ds);
            }
        }
        catch (NpgsqlException ex)
        {
            throw new DbException(ex.SqlState, stmt, ex);
        }
        return ds.Tables.Count > 0 ? ds.Tables[0] : null;
    }

    public override void Exec(string sql, params object?[] args)
    {
        try
        {
            lock (_syncRoot)
            {
                if (args.Length > 0) sql = string.Format(sql, args);
                using var cmd = new NpgsqlCommand(sql, (NpgsqlConnection)_conn);
                cmd.ExecuteNonQuery();
            }
        }
        catch (NpgsqlException ex)
        {
            throw new DbException(ex.SqlState, sql, ex);
        }
    }

    #region Database objects

    public override List<string> Schemas() =>
        Query("SELECT schema_name FROM INFORMATION_SCHEMA.SCHEMATA ORDER BY 1")
                .Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();

    public override List<string> Tables() =>
        Query("SELECT table_schema||'.'||table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_schema NOT IN ('information_schema','pg_catalog') ORDER BY 1")
            .Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();

    public override List<string> Views() =>
        Query("SELECT table_schema||'.'||table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_schema NOT IN ('information_schema','pg_catalog') AND table_type='BASE TABLE' ORDER BY 1")
            .Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();

    public override List<string> Procedures() =>
        Query("SELECT routine_schema||'.'||routine_name FROM INFORMATION_SCHEMA.ROUTINES WHERE routine_schema NOT IN ('information_schema','pg_catalog') ORDER BY 1")
            .Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToList();

    #endregion Database objects
}