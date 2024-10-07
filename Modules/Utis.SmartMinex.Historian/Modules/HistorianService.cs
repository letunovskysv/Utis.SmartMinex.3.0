//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: HistorianService – Модуль хранения технологических данных.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Modules;

/// <summary> Служба хранения технологических данных.</summary>
sealed class HistorianService : SmartModule
{
    public HistorianService(IRuntime runtime) : base(runtime)
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
