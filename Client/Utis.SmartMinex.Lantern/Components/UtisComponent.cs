//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisComponent –
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
#endregion Using

namespace Utis.SmartMinex.Client;

public abstract class UtisComponent : ComponentBase, IDisposable
{
    [Inject]
    protected IJSRuntime _jsr { get; set; }

    [Parameter]
    public string? Style { get; set; }

    public virtual void Dispose() => GC.SuppressFinalize(this);
}
