//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TNodeRow – Физическая таблица базы данных. Справочник узлов баз данных.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Data;

using System.ComponentModel.DataAnnotations.Schema;
using Utis.SmartMinex.Runtime;

[Table("config.nodes")]
public class TNode : TTreeCatalogItem, ISiteItem, IReplicated
{
    public long Site { get; set; }

    /// <summary> Сетевой адрес или имя сервера.</summary>
    public string? Host { get; set; }

    /// <summary> Тип узла базы данных.</summary>
    /// <remarks> Используется при распределённой БД.</remarks>
    public int Type { get; set; }

    /// <summary> Уровень в иерархии узла базы данных.</summary>
    /// <remarks> Используется при распределённой иеррархической БД.</remarks>
    public int Level { get; set; }

    /// <summary> Идентификатор БД. [0..1023] </summary>
    public required int Index { get; set; }

    /// <summary> Признак текущего узла БД.</summary>
    /// <remarks> В базе данных, данный признак должен быть только у одного узла.</remarks>
    public bool Active { get; set; }

    /// <summary> Примечание, комментарий, описание.</summary>
    [Column(TypeName = "nvarchar(1024) NULL")]
    public string? Description { get; set; }

    /// <summary> Версия ПО объектового сервера. Обновляется при подключении публикатора узла.</summary>
    [Column(TypeName = "nvarchar(16) NULL")]
    public string? FWRev { get; set; }

    /// <summary> Версия базы данных объектового сервера. Обновляется при подключении публикатора узла.</summary>
    [Column(TypeName = "nvarchar(16) NULL")]
    public string? DBRev { get; set; }

    /// <summary> Дополнительные свойства (расширения).</summary>
    public TOptions? Options { get; set; }

    public long RowVersion { get; set; }

    public override string ToString() => "(" + Code + ") " + Name + " #" + Index;
}
