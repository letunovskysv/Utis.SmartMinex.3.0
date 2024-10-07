//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WorkflowService – Модуль документооборота, рабочего процесса.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Modules;

/// <summary> Модуль документооборота, рабочего процесса.</summary>
sealed class WorkflowService : SmartModule
{
    public WorkflowService(IRuntime runtime) : base(runtime)
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
