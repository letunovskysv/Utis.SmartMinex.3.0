//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: FbSqlDatabase – База данных Firebird SQL.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net.Sockets;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using FirebirdSql.Data.FirebirdClient;
using Dapper;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public class FbSqlDatabase(string connectionString) : TDatabase(connectionString)
{
    #region Properties

    public override string DatabaseName => Regex.Match(_connstr, @"(?<=Database=[\w\:\/]*)[^\/.]*?(?=\.FDB)", RegexOptions.IgnoreCase).Value;

    #endregion Properties

    public override IDatabase Open()
    {
        _conn = new FbConnection(string.Concat(_connstr, ";Application name=smsrv",
            string.IsNullOrWhiteSpace(ApplicationName) ? string.Empty : "Application name=" + ApplicationName));

        try
        {
            _conn.Open();
        }
        catch (FbException ex)
        {
            if (ex.ErrorCode == SQLERR_FAILED && ex.InnerException is SocketException)
                throw new DbException(DbException.NO_INSTANCE, ex);
            else if (ex.ErrorCode == SQLERR_FAILED && ex is FbException sql && sql.SqlState == "3D000")
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
                using var cmd = new FbDataAdapter(stmt, (FbConnection)_conn);
                cmd.Fill(ds);
            }
        }
        catch (FbException ex)
        {
            throw new DbException(ex.ErrorCode, ex);
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
                using var cmd = new FbCommand(sql, (FbConnection)_conn);
                cmd.ExecuteNonQuery();
            }
        }
        catch (FbException ex)
        {
            throw new DbException(ex.ErrorCode, ex);
        }
    }
}
