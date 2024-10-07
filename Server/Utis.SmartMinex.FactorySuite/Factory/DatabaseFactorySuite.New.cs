//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DatabaseFactorySuite.New – Доступ к базе данных. Создание новой базы данных.
//--------------------------------------------------------------------------------------------------
#pragma warning disable CS8601, CS8602
#region Using
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public partial class DatabaseFactorySuite
{
    protected string GetSchema(string name)
    {
        var res = Regex.Match(name, @"^[\w_]+(?=\.)").Value;
        return string.IsNullOrEmpty(res) ? DefaultScheme : res;
    }

    public string ZDatabase(string source)
    {
        var parts = source.Split(['.']);
        return parts.Length == 3 ? parts[0] : DatabaseName;
    }

    public string ZTable(string source)
    {
        var parts = source.Split(['.']);
        return parts.Length switch
        {
            1 => string.Concat(LQ, DefaultScheme, RQ, '.', LQ, parts[0], RQ),
            2 => string.Concat(LQ, parts[0], RQ, '.', LQ, parts[1], RQ),
            _ => string.Concat(LQ, parts[1], RQ, '.', LQ, parts[2], RQ)
        };
    }

    public string? ZField(string? source) =>
        string.IsNullOrWhiteSpace(source) ? null : string.Concat(LQ, source, RQ);

    protected string ColumnDefinition(PropertyInfo pi)
    {
        var ca = pi.GetCustomAttribute<ColumnAttribute>();
        if (ca == null)
            if (pi.PropertyType.IsEnum)
                return "integer";
            else
                return _maptypes.TryGetValue(pi.PropertyType.FullName.GetHashCode(), out var pt1) ? pt1 : "nvarchar(256)";

        var ctype = Regex.Match(ca.TypeName, @"[\w_]+\(\D+\)|[\w_]+").Value;
        if (_maptypes.TryGetValue(ctype.GetHashCode(), out var pt2))
            return ca.TypeName.Replace(ctype, pt2);

        return ca.TypeName;
    }

    public virtual void CreateDatabase(string connectionString, Stream? configuration) => throw new NotImplementedException();

    /// <summary> Удаляем все системные таблицы на основании атрибутов классов.</summary>
    protected virtual void CleanEnvironment(IDatabase db)
    {
        foreach (var table in this.GetTypes<TableAttribute>())
        {
        }
    }

    /// <summary> Создать системные таблицы на основании атрибутов классов.</summary>
    protected virtual void CreateEnvironment(IDatabase db, DbInitFile? dbinit)
    {
        var schemas = Database.Schemas();
        var tables = Database.Tables();
        var stmt = new StringBuilder();
        var newtabs = new List<string>();
        this.GetTypes<TableAttribute>().ForEach(ztype => // Создаём системные таблицы в БД на основании типов (классов) -->
        {
            var tbl = ztype.GetCustomAttribute<TableAttribute>(false);
            var defn = new TableDefinition(tbl.Name, DefaultScheme);
            var schema = GetSchema(defn.Name);
            if (!schemas.Contains(schema))
            {
                CreateSchema(schema);
                schemas.Add(schema);
            }
            if (!tables.Contains(defn.Name))
            {
                foreach (var prop in ztype.GetProperties(BindingFlags.Instance | BindingFlags.Public).OrderBy(d => d.MetadataToken))
                {
                    var zattr = prop.GetCustomAttribute<ColumnAttribute>();
                    defn.Columns.Add(string.Concat(LQ, zattr?.Name ?? prop.Name.ToLower(), RQ, " ", ColumnDefinition(prop)));
                }
                stmt.Append("CREATE TABLE ").Append(ZTable(defn.Name)).Append(" (").Append(string.Join(",", defn.Columns))
                    .Append(");\r\n");

                tables.Add(defn.Name);
                newtabs.Add(defn.Name);
            }
        });
        if (stmt.Length > 0)
            _db.Exec(stmt.ToString());

        if (dbinit != null) // Первоначальная инициализация БД -->
        {
            var now = DateTime.Now.ToSqlDatetime();
            var ver = DateTime.Now.ToSqlTimestamp();

            stmt.Clear();
            dbinit.ForEach(zobj =>
            {
                stmt.Append("INSERT INTO config.zobjects (\"id\",\"parent\",\"type\",\"definition\",\"created\",\"updated\",\"deleted\",\"rowversion\") VALUES (")
                    .Append(zobj.Id).Append(',').Append(zobj.Parent).Append(',').Append(zobj.Type).Append(',')
                    .Append(zobj.Definition.ToSqlBinary()).Append(',')
                    .Append(now).Append(',').Append(now).Append(',').Append(zobj.Deleted).Append(',').Append(ver)
                    .Append(") ON CONFLICT (").Append(LQ).Append("id").Append(RQ)
                    .Append(") DO UPDATE SET \"parent\"=excluded.\"parent\",\"type\"=excluded.\"type\",\"definition\"=excluded.\"definition\",\"updated\"=excluded.\"updated\",\"rowversion\"=excluded.\"rowversion\";\r\n");
            });
            if (stmt.Length > 0)
                _db.Exec(stmt.ToString());

            stmt.Clear(); // Заполняем данными -->
            foreach (var row in dbinit.Items.Where(r => newtabs.Contains(r.Key)))
                foreach (var val in row.Value)
                    stmt.Append("INSERT INTO ").Append(ZTable(row.Key)).Append(val).Append(";\r\n");

            if (stmt.Length > 0)
                _db.Exec(stmt.ToString());
        }
    }

    /// <summary> Кэш SQL-инструкций для вставки и обновления БД.</summary>
    static readonly ConcurrentDictionary<Type, XInsertCommandArgs> INSERT = [];

    public void Insert(object item)
    {
        var typ = item.GetType();
        if (!INSERT.TryGetValue(typ, out var ins))
        {
            var comma = string.Empty;
            var comma2 = string.Empty;
            var tinfo = typ.GetCustomAttribute<TableAttribute>() ?? throw new Exception(STR.FailedInsertDbBasedOfType);
            var getters = new List<MethodInfo>();
            var begin = new StringBuilder("INSERT INTO ").Append(tinfo.Name).Append(" (");
            var end = new StringBuilder(") ON CONFLICT (").Append(LQ).Append("id").Append(RQ).Append(") DO UPDATE SET ");
            foreach (var p in typ.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var fname = p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name.ToLower();
                begin.AppendFormat("{0}{1}{2}{3}", comma, LQ, fname, RQ);
                comma = ",";
                if (fname != "id")
                {
                    end.AppendFormat("{0}{1}{2}{3}=excluded.{1}{2}{3}", comma2, LQ, fname, RQ);
                    comma2 = ",";
                }
                getters.Add(p.GetGetMethod());
            }
            begin.Append(") VALUES (");
            INSERT.TryAdd(typ, ins = new()
            {
                Begin = begin.ToString(),
                Getters = [.. getters],
                End = end.ToString()
            });
        }
        _db.Exec(string.Concat(ins.Begin, string.Join(',', ins.Getters.Select(g => AsSqlValue(g.Invoke(item, null)))), ins.End));
    }

    protected virtual void CreateSchema(string name) =>
        _db.Exec($"CREATE SCHEMA {LQ}{name}{RQ};");

    class XInsertCommandArgs
    {
        public required string Begin;
        public required string End;
        public required MethodInfo[] Getters;
    }
}
#pragma warning restore CS8601, CS8602
