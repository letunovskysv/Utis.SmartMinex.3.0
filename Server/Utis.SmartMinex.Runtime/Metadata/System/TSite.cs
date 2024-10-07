//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TSite – Физическая таблица базы данных. Справочник площадок.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Data;

using System.ComponentModel.DataAnnotations.Schema;

[Table("config.sites")]
public class TSite : TTreeCatalogItem, IReplicated
{
    /// <summary> Местонаходжение площадки. Связт со структурным справочником.</summary>
    [Column("location", TypeName = "bigint NULL")]
    public long Location { get; set; }

    /// <summary> Примечание, комментарий, описание.</summary>
    [Column(TypeName = "nvarchar(1024) NULL")]
    public string? Description { get; set; }

    public long RowVersion { get; set; }
}
