using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Состояние оборудования позиционирования
    /// </summary>
    [DisplayName("Состояние оборудования позиционирования")]
    [Ackable]
    public interface IDeviceStateEventPriority : IPriorityEventBase
    {
        /// <summary>
        /// Оборудование позиционирования
        /// </summary>
        [DisplayName("Устройство")]
        [Description("Оборудование позиционирования")]
        IDevice Device
        { get; set; }

        /// <summary>
        /// Состояние оборудования позиционирования
        /// </summary>
        [DisplayName("Состояние устройства")]
        [Description("Состояние инфраструктурного оборудования позиционирования")]
        DeviceState DeviceState
        { get; set; }
    }
}
