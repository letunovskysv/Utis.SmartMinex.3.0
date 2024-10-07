//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MaintenanceService – План обслуживания. Обслуживание БД.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Modules;

/// <summary> План обслуживания. Обслуживание БД.</summary>
sealed class MaintenanceService : SmartModule
{
    public MaintenanceService(IRuntime runtime) : base(runtime)
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
