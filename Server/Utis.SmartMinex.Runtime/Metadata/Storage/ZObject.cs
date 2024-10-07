//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ZObject – Атрибуты объектов конфигурации (метаданных) в базе данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
#endregion Using

namespace Utis.SmartMinex.Runtime;

[DebuggerDisplay("{Id}, {Parent}, {Type}")]
[Table("config.zobjects")]
public class ZObject
{
    [Column("id", TypeName = "bigint PRIMARY KEY")]
    public long Id { get; set; }
    public long Parent { get; set; }
    /// <summary> Тип объекта конфигурации, TType.</summary>
    public long Type { get; set; }
    /// <summary> Определение объекта конфигурации.</summary>
    public byte[] Definition { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    /// <summary> Признак исключения из конфигурации.</summary>
    public bool Deleted { get; set; }
    public long RowVersion { get; set; }
}
