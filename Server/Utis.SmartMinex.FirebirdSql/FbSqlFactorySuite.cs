//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: FbSqlDatabase – База данных Firebird SQL.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public sealed class FbSqlFactorySuite : DatabaseFactorySuite
{
    protected override SortedList<int, string> _maptypes => new()
        {
            { @"bit".GetHashCode(), "bool" },
            { @"float(4)".GetHashCode(), "real" },
            { @"float(8)".GetHashCode(), "double precision"},
            { @"tinyint".GetHashCode(), "smallint" },
            { @"\btimestamp\b".GetHashCode(), "bytea" },
            { @"rowversion".GetHashCode(), "bigint" },
            { @"datetime".GetHashCode(), "timestamp" },
            { @"nvarchar\(max\)".GetHashCode(), "varchar(8191)" },
            { @"nvarchar".GetHashCode(), "varchar" },
            { @"varbinary\(\w+\)".GetHashCode(), "bytea" },
            { @"varbinary".GetHashCode(), "bytea" }
        };

    public FbSqlFactorySuite(IMetadata md, IDatabase db) : base(md, db) { }
}
