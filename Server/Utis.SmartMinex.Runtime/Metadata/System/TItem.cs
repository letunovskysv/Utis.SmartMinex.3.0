//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TItem – Базовый класс для всех типов объектов конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel.DataAnnotations.Schema;
#endregion Using

namespace Utis.SmartMinex.Data;

/// <summary> Базовый класс для всех типов объектов конфигурации.</summary>
public abstract class TItem : ICloneable
{
    /// <summary> Глобальный уникальный 64-разрядный идентификатор записи в БД.</summary>
    [Column("id", TypeName = "bigint PRIMARY KEY")]
    public required long Id { get; set; }

    public object Clone() => MemberwiseClone();
}

public class TCatalogItem : TItem
{
    /// <summary> Состояния записи.</summary>
    public required TRowState State { get; set; }

    /// <summary> Код, шифр, обозначение.</summary>
    [Column("code", TypeName = "nvarchar(8) NOT NULL")]
    public required string Code { get; set; }

    /// <summary> Наименование записи.</summary>
    [Column("name", TypeName = "nvarchar(64) NOT NULL")]
    public required string Name { get; set; }

    public override string ToString() => "(" + Code + ") " + Name;
}

public class TTreeCatalogItem : TCatalogItem
{
    /// <summary> Признак группы.</summary>
    [Column("isgroup", TypeName = "bit NOT NULL DEFAULT false")]
    public required bool IsGroup { get; set; }

    /// <summary> Родительская запись в таблице.</summary>
    [Column("parent", TypeName = "bigint NOT NULL DEFAULT 0")]
    public required long Parent { get; set; }
}

/// <summary> Запись имеет площадку.</summary>
public interface ISiteItem
{
    /// <summary> Площадка.</summary>
    long Site { get; set; }
}

/// <summary> Запись имеет версию строки для репликации.</summary>
public interface IReplicated
{
    /// <summary> Версия строки, Timestamp.</summary>
    long RowVersion { get; set; }
}

/// <summary> Состояние записи.</summary>
public enum TRowState
{
    None = 0,
    New = 1,
    Edit = 2,
    Accept = 4,
    Active = 8,
    Disable = 128,
    Deleted = 256
}