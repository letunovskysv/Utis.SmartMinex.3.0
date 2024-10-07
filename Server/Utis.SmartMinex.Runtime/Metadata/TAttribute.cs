//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TAttribute – Реквизит.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Json.Serialization;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public interface IAttribute
{
    /// <summary> Реквизиты объекта конфигурации.</summary>
    TAttributeCollection Attributes { get; }
}

/// <summary> Реквизит.</summary>
public class TAttribute : TEntity
{
    #region Properties

    public TObject Object { get; set; }

    /// <summary> Признак возможности пустого значения.</summary>
    public bool Nullable { get; set; }

    /// <summary> Признак только чтения.</summary>
    public bool ReadOnly { get; set; }

    /// <summary> Флаги.</summary>
    [JsonConverter(typeof(StringEnumConverter<TAttributeFlags>))]
    public TAttributeFlags Flags { get; set; }

    /// <summary> Сортировка.</summary>
    public int Ordinal { get; set; }

    #endregion Properties

    /// <summary> Фабрика данных необходимых для построения инструкций к базе данных.</summary>
    [JsonIgnore]
    public readonly TAttributeFactory Factory = new();
}

public class TAttributeCollection : List<TAttribute>
{
    public TAttribute? KeyField => this.FirstOrDefault(ai => ai.Flags.HasFlag(TAttributeFlags.Key));
}

[Flags]
public enum TAttributeFlags
{
    None = 0,
    Key = 1,
    Parent = 2,
    Code = 4,
    Name = 8,
    Group = 16,
    Datetime = 32,
    Version = 64,
    Autoinc = 128
}

/// <summary> Фабрика данных необходимых для построения инструкций к базе данных.</summary>
public class TAttributeFactory
{
    public string? Name;
    public bool IsReference;
    public Type? PropertyType;
}
