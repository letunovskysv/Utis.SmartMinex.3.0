//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisSession – Пользовательская сессия.
//--------------------------------------------------------------------------------------------------
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Data;

namespace Utis.SmartMinex.Client.Components;

/// <summary> Пользовательская сессия.</summary>
class UtisSession
{
    public TMenu? Menu { get; set; }

    public UtisSession(IDispatcher dsp)
    {
        Menu ??= dsp.Select<TMenu>().First();
    }
}
