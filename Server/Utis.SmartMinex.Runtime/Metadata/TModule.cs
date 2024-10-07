//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TModule – Класс описания модуля, сервиса. 
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Json.Serialization;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Сведения об объекте метаданных - Модуль.</summary>
public class TModule : TEntity
{
    /// <summary> Признак загрузки из базы данных.</summary>
    /// <remarks> Запуск модулей после полной загрузки конфигурации (метаданных) из базы данных.</remarks>
    public bool FromDatabase { get; set; }

    [JsonConverter(typeof(StringEnumConverter<RuntimeStartMode>))]
    public RuntimeStartMode Start { get; set; }

    public Type? ModuleType { get; set; }

    public Dictionary<string, object?> Parameters { get; set; } = [];

    public string? this[string name] =>
        Parameters.TryGetValue(name, out var val) ? val?.ToString() : default!;
}

public enum RuntimeStartMode
{
    None = 0,
    Auto = 2,
    Manual = 3,
    Disabled = 4
}
