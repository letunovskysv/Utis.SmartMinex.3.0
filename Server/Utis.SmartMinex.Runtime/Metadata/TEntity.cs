//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TEntity – Базовый класс объекта конфигурации: справочник, документ и т.д.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Diagnostics;
using System.Text.Json.Serialization;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Сведения об объекте метаданных. Базовый тип.</summary>
[DebuggerDisplay("{Id}, {Type}, {Name}")]
public class TEntity: ICloneable
{
    [JsonPropertyOrder(0)]
    public long Id { get; set; }
    public long Parent { get; set; }
    public TType Type { get; set; }
    public string? Code { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public string? FullName { get; set; }
    public string? Source { get; set; }
    public string? Description { get; set; }
    /// <summary> Порядок отображения.</summary>
    public int Ordinal { get; set; }

    /// <summary> Признак исключения из конфигурации.</summary>
    public bool Deleted { get; set; }

    /// <summary> Редактор свойств объекта конфигурации, класс дизайнера.</summary>
    public string? Designer { get; set; }

    public object Clone() => MemberwiseClone();
}

public class THelper : TEntity
{
    /// <summary> Список обрабатываемых типов метаданных.</summary>
    public List<long> Types { get; set; }
}