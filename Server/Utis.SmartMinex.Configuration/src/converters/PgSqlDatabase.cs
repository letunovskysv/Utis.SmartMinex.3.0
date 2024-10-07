//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: PgSqlDatabase – База данных PostgreSql.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Data.Common;
using Npgsql;
#endregion Using

namespace Utis.SmartMinex.Utils;

class PgSqlDatabase(string connectionString)
{
    #region Declarations

    readonly string _connstr = connectionString;
    DbConnection? _conn;

    #endregion Declarations

    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    public PgSqlDatabase Open()
    {
        _conn = new NpgsqlConnection(_connstr);
        try
        {
            _conn.Open();
        }
        catch (NpgsqlException ex)
        {
            throw;
        }
        return this;
    }

    public void Close()
    {
        if (_conn != null && _conn.State == ConnectionState.Open)
        {
            _conn.Close();
            _conn = null;
        }
    }

    public DataTable? Query(string statement, params object?[] args)
    {
        var ds = new DataSet();
        var stmt = args.Length == 0 ? statement : string.Format(statement, args);
        using var cmd = new NpgsqlDataAdapter(stmt, (NpgsqlConnection)_conn);
        cmd.Fill(ds);
        return ds.Tables.Count > 0 ? ds.Tables[0] : null;
    }
}