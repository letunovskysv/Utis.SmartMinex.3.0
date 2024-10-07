//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MsSqlDatabase – База данных MS SQL.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Data.SqlClient;
using Dapper;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public class MsSqlDatabase(string connectionString) : TDatabase(connectionString)
{
    #region Declarations

    const int SQLERR_NO_INSTANCE = 2;
    const int SQLERR_NO_DATABASE = 4060;
    const int _timeout = 300; // second

    string? _infoMessage;

    #endregion Declarations

    #region Properties

    public override string DatabaseName => Regex.Match(_connstr, @"(?<=INITIAL CATALOG=|Database=).*?(?=;|$)", RegexOptions.IgnoreCase).Value;

    #endregion Properties

    public override IDatabase Open()
    {
        _conn = new SqlConnection(string.Concat(_connstr, ";Application Name=smsrv",
            string.IsNullOrWhiteSpace(ApplicationName) ? string.Empty : " - " + ApplicationName));

        try
        {
            _conn.Open();
            ((SqlConnection)_conn).InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);
        }
        catch (SqlException ex)
        {
            if (ex.ErrorCode == SQLERR_FAILED && ex.Number == SQLERR_NO_INSTANCE)
                throw new DbException(DbException.NO_INSTANCE, ex);
            else if (ex.ErrorCode == SQLERR_FAILED && ex.Number == SQLERR_NO_DATABASE)
                throw new DbNotFoundException(DbException.NO_DATABASE, ex);
            else
                throw;
        }
        return this;
    }

    public override DataTable? Query(string sql, params object?[] args) =>
        Query(CommandBehavior.Default, sql, args);

    public override void Exec(string sql, params object?[] args) =>
        Exec(CommandBehavior.Default, sql, args);

    #region Private methods

    /// <summary> Вызывается при вызове в хранимой процедуре инструкции PRINT. Некоторый такой callback.</summary>
    void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        if (e.Errors[0].Number == 0 || e.Errors[0].Number == 61000) // print or raiserror
            _infoMessage += (_infoMessage == null ? "" : "\n") + e.Message.Trim();
    }


    DataTable Query(CommandBehavior behavior, string sql, params object?[] args)
    {
        _infoMessage = null;
        var res = new DataTable();
        SqlTransaction? tran = null;
        lock (_syncRoot)
            try
            {
                tran = ((SqlConnection)_conn).BeginTransaction();
                try
                {
                    res = QueryTran(tran, behavior, sql, args);
                    tran.Commit();
                }
                catch (SqlException ex)
                {
                    if (ex.Number != 15002) // Code cannot be executed within a transaction
                        throw;

                    tran.Rollback();
                    res = QueryTran(tran, behavior, sql, args);
                }
            }
            catch (SqlException ex)
            {

                if (tran != null)
                    try
                    {
                        tran.Rollback();
                    }
                    catch { }

                res.Dispose();
                if (ex.Number < 60000)
                {
                    //TService.EventLog.WriteError(statement + "\n" + ex.Message);
                    throw new Exception(string.Format(sql, args), ex);
                }
                else throw;
            }
        return res;
    }

    DataTable QueryTran(SqlTransaction tran, CommandBehavior behavior, string sql, params object?[] args)
    {
        _infoMessage = null;
        var res = new DataTable();
        using var cmd = new SqlCommand(string.Format(sql, args), (SqlConnection)_conn, tran);
        cmd.CommandTimeout = _timeout;
        using var reader = cmd.ExecuteReader(behavior);
        res.Load(reader);
        return res;
    }

    void Exec(CommandBehavior behavior, string sql, params object[] args)
    {
        _infoMessage = null;
        lock (_syncRoot)
            using (SqlCommand cmd = new SqlCommand(args.Length > 0 ? string.Format(sql, args) : sql, (SqlConnection)_conn))
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("<PRE>" + sql + "</PRE>", ex);
                }
    }

    #endregion Private methods
}
