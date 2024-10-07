//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DataAcquisitionService – Модуль сбора данных с сервера сбора данных ССД.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Modules;

/// <summary> Служба сбора данных (DAS).</summary>
sealed class DataAcquisitionService : SmartModule
{
    public DataAcquisitionService(IRuntime runtime) : base(runtime)
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
