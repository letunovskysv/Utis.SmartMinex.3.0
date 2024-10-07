//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDatabase – База данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Dapper;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public abstract class TDatabase(string connectionString) : IDatabase
{
    #region Declarations

    protected const int SQLERR_FAILED = -2147467259;

    /// <summary> Исключаем одновременный доступ (запрос) к данным базы данных.</summary>
    protected readonly object _syncRoot = new();
    protected readonly string _connstr = connectionString;
    protected DbConnection? _conn;

    #endregion Declarations

    #region Properties

    public string ApplicationName { get; set; }

    public virtual string DatabaseName => Regex.Match(_connstr, @"(?<=INITIAL CATALOG=|Database=).*?(?=;|$)", RegexOptions.IgnoreCase).Value;

    #endregion Properties

    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    public virtual IDatabase Open() => throw new NotImplementedException();

    public void Close()
    {
        if (_conn != null && _conn.State == ConnectionState.Open)
        {
            _conn.Close();
            _conn.Dispose();
            _conn = null;
        }
    }

    public virtual DataTable? Query(string sql, params object?[] args) => throw new NotImplementedException();

    public virtual object? Scalar(string sql, params object?[] args)
    {
        using var result = Query(sql, args);
        if (result?.Rows.Count > 0)
            return result.Rows[0][0];

        return null;
    }

    public virtual void Exec(string sql, params object?[] args) => throw new NotImplementedException();

    #region Database objects

    /// <summary> Возвращает список схем данных в текущей базе данных.</summary>
    public virtual List<string> Schemas() => throw new NotImplementedException();

    /// <summary> Возвращает список таблиц в текущей базе данных.</summary>
    public virtual List<string> Tables() => throw new NotImplementedException();

    /// <summary> Возвращает список представлений в текущей базе данных.</summary>
    public virtual List<string> Views() => throw new NotImplementedException();

    /// <summary> Возвращает список хранимых процедур в текущей базе данных.</summary>
    public virtual List<string> Procedures() => throw new NotImplementedException();

    #endregion Database objects

    #region Models

    public IEnumerable<T>? Select<T>(string sql, params object?[] args)
    {
        lock (_syncRoot)
            return _conn?.Query<T>(string.Format(sql, args), commandTimeout: 180);
    }

    public IEnumerable<T>? Select<T>(Expression<Func<T, bool>>? predicate)
    {
        if (this.GetTypes<TableAttribute>().FirstOrDefault(t => t.Equals(typeof(T))) is Type type)
        {
            return Select<T>(string.Concat("SELECT* FROM ",
                type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name,
                predicate == null ? string.Empty : string.Concat(" WHERE ", SqlWhereExpression.Convert(predicate))));
        }
        return null;
    }

    public IEnumerable<object>? Select(Type type, string sql, params object?[] args)
    {
        lock (_syncRoot)
            return _conn?.Query(type, string.Format(sql, args), commandTimeout: 180);
    }

    static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, MethodInfo?>> _cache_method = [];

    public IEnumerable<object>? Select(Type type, Type[] types, string splitOn, string sql, params object?[] args)
    {
        //sql = @"SELECT a.""id"",a.""name"",a.""divisionparent_id"",a.""divisioncategory"",a.""ismaindivision"",a.""isfromintegration"",a.""shiftmode_id"",a.""created"",a.""updated"",a.""deleted"",a.""versionobject""
        //, b.*, c.*
        //FROM ""public"".""division"" AS a
        //LEFT JOIN ""public"".""division"" AS b ON b.""id""=a.""divisionparent_id""
        //LEFT JOIN ""public"".""shiftmode"" AS c ON c.""id""=a.""shiftmode_id""
        //where a.""divisionparent_id"" is not null";

        lock (_syncRoot)
        {
            var pnames = splitOn.Split([',']).Select((s, i) => i > 0 ? s[0..^3] : s).ToArray();
            return _conn?.Query(sql, types, (items) =>
            {
                MethodInfo? setter;
                var item = items.First();
                for (int i = pnames.Length - 1; i > 0; i--)
                {
                    var pname = pnames[i];
                    if (_cache_method.TryGetValue(type, out var mi))
                    {
                        if (mi.TryGetValue(pname, out var val))
                            setter = val;
                        else
                            mi.TryAdd(pname, setter = item.GetType().GetProperty(pname, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase).GetSetMethod());
                    }
                    else
                    {
                        var cache = new ConcurrentDictionary<string, MethodInfo?>();
                        cache.TryAdd(pname, setter = item.GetType().GetProperty(pname, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase).GetSetMethod());
                        _cache_method.TryAdd(type, cache);
                    }
                    if (!items[i].GetType().GetProperty("Id").GetValue(items[i]).Equals(0L)) // с Parent не работает
                        setter?.Invoke(item, [items[i]]);
                }
                return item;
            }, splitOn: splitOn);
        }
    }

    #endregion Models
}