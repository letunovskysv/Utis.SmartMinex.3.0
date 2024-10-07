//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisPage – Базовый компонент Веб-страницы.
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
#endregion Using

namespace Utis.SmartMinex.Client.Components;

public class UtisPage : ComponentBase, IDisposable
{
    [Inject]
    protected IDispatcher _dsp { get; set; }

    /// <summary> Вызов JavaScript функций в браузере.</summary>
    [Inject]
    protected IJSRuntime _jsr { get; set; }

    [Inject]
    protected NavigationManager _nav { get; set; }

    protected async Task Download(string filename, Func<Stream?> export)
    {
        if (export.Invoke() is Stream stream)
        {
            using var msref = new DotNetStreamReference(stream);
            await _jsr.InvokeVoidAsync(WellKnownJS.DownloadStream, filename, msref);
        }
    }

    public virtual void Dispose() => GC.SuppressFinalize(this);
}
