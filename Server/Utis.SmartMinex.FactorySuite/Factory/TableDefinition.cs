//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TableDefinition – Определение таблицы в БД.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Data;

/// <summary> Определение таблицы в БД.</summary>
public class TableDefinition(string tableName, string schema)
{
    public string Name = tableName.Contains('.') ? tableName : string.Concat(schema, '.', tableName);
    public List<string> Columns = [];
    public List<string> Constraints = [];
}
