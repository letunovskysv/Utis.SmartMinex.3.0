//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IOServer – Модуль обслуживания устройств УРПТ.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Collections.Concurrent;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Devices;

/// <summary> Служба хранения технологических данных.</summary>
sealed class IOServer : SmartModule, IOService
{
    #region Declarations

    /// <summary> Реестр оборудования.</summary>
    readonly ConcurrentDictionary<long, IDevice> _devices = new();

    #endregion Declarations

    #region Properties

    public List<IDevice> Devices => [.. _devices.Values];

    #endregion Properties

    public IOServer(IRuntime runtime) : base(runtime)
    {
        Messages = [MSG.DeviceStateChanged];
    }

    public override Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.DeviceStateChanged:
                break;
        }
        return Task.CompletedTask;
    }
}
