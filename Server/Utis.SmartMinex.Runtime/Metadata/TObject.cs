//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TObject – Базовый класс объекта конфигурации: справочник, документ и т.д.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Json.Serialization;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public class TObject : TEntity, IAttribute
{
    /// <summary> Соответствующий тип записи, модель.</summary>
    public Type? Model { get; set; }

    /// <summary> Флаги.</summary>
    [JsonConverter(typeof(StringEnumConverter<TObjectFlags>))]
    public TObjectFlags Flags { get; set; }

    [JsonIgnore]
    public TAttributeCollection Attributes { get; } = [];

    /// <summary> Фабрика данных необходимых для построения инструкций к базе данных.</summary>
    [JsonIgnore]
    public readonly TObjectFactory Factory = new();
}

[Flags]
public enum TObjectFlags
{
    None = 0,
    System = 1,
    Replicated = 2,
    Site = 4,
    /* Не физическая таблица */
    View = 8,
    /* Возможен экспорт */
    Exported = 0x20000000,
    /* Отметить объект */
    Mark = 0x40000000
}

/// <summary> Фабрика данных необходимых для построения инструкций к базе данных.</summary>
public class TObjectFactory
{
    public string Database;
    public string Table;
    /// <summary> Объект находиться во внешней БД.</summary>
    public bool IsExternal;

    public bool Modified = true;
}