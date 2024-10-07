//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DatabaseFactorySuite.Build – Доступ к базе данных. Построение и выполнение инструкции.
//--------------------------------------------------------------------------------------------------
#pragma warning disable CS8601, CS8602
#region Using
using Dapper;
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public partial class DatabaseFactorySuite
{
    public IFactorySuite Build()
    {
        _sql = [];
        var comma = string.Empty;
        switch (_state)
        {
            case XState.Select:
                var stmt = new StringBuilder("SELECT ");
                _fields.ForEach(f =>
                {
                    stmt.Append(comma).Append(f.Name);
                    comma = ",";
                });
                _from.ForEach(f => stmt.Append(f.Join).Append(f.Name).Append(f.Where));
                _sql = [stmt.ToString()];
                break;
        }
        return this;
    }

    public DataTable? Run()
    {
        DataTable? res = null;
        foreach(var stmt in _sql)
            res = _db.Query(stmt);

        return res;
    }

    public IEnumerable<T>? Run<T>()
    {
        return null;
    }

    public IEnumerable<object>? RunAsEnumerable()
    {
        var t = _db.Select(_obj.Model, _types.ToArray(), string.Join(",", _ids), _sql.First());
        return t;
    }

    public override string ToString()
    {
        var keywords = new[] { "SELECT", "FROM", "INNER JOIN", "LEFT JOIN", "JOIN", "WHERE" };
        var sql = _sql.First()?.ToString() ?? string.Empty;
        var parts = Regex.Matches(sql, @"SELECT\s*|\s*FROM\s*|\s*LEFT\sJOIN\s*|\s*INNER\ssJOIN\s*|""*[\w_]+""*\.""\w+"",*(\s*AS\s*[\w_]+)*(\sON\s([\w_]+\.""[\w_]+""|[<>=!?])+)*|.+?").Cast<Match>()
            .Select(m => (keywords.Contains(m.Value.Trim()) ? string.Empty : "\t") + m.Value.Trim()).ToList();

        return string.Join("\r\n", parts);
    }
}
#pragma warning restore CS8601, CS8602
