//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisMenuItem –
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Archestra.Controls;

public class UtisMenuItem
{
    public string Name { get; set; }
    public string? Value { get; set; }
    public bool HasChild => Items != null && Items.Count > 0;
    public bool Splitter => Name == "-";

    public int Level;

    public List<UtisMenuItem>? Items { get; set; }
}

public class UtisMenuItemEventArgs(object? target, UtisMenuItem item) : EventArgs
{
    public object? Target { get; set; } = target;
    public UtisMenuItem Item { get; set; } = item;
}
