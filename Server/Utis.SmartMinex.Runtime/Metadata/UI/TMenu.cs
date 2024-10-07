//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TMenu – Сведения об объекте метаданных: Пользовательское меню.
//--------------------------------------------------------------------------------------------------
#region Using
using System;
using System.Diagnostics;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Сведения об объекте метаданных - Пользовательское меню.</summary>
public sealed class TMenu : TEntity
{
    public List<TMenuItem> Items { get; set; }
}

[DebuggerDisplay("{Name}, {Target} - {Path}")]
public class TMenuItem
{
    public string Name { get; set; }
    public string Path { get; set; }
    /// <summary> Ссылка на внешний файл изображения.</summary>
    public string Image { get; set; }
    /// <summary> Встроенная иконка Radzen.</summary>
    public string Icon { get; set; }
    public long Target { get; set; }

    public List<TMenuItem> Items { get; set; }
}
