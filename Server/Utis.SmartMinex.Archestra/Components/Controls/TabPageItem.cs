//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TabPageItem –
//--------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Components;

namespace Utis.SmartMinex.Archestra.Components;

public class TabPageItem
{
    static int _num = 0;

    public int Id { get; set; } = ++_num;
    public string Name { get; set; }
    public string Icon { get; set; }

    public Type Type { get; set; }
    public Dictionary<string, object?> Parameters { get; set; }
}
