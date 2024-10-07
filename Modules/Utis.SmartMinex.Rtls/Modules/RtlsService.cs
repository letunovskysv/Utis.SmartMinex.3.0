//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: RtlsService – Модуль расчёта координат реального времени.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Modules;

/// <summary> Модуль расчёта координат реального времени.</summary>
sealed class RtlsService : SmartModule
{
    public RtlsService(IRuntime runtime) : base(runtime)
    {
    }

    public override Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.Test:
                break;
        }
        return Task.CompletedTask;
    }
}
