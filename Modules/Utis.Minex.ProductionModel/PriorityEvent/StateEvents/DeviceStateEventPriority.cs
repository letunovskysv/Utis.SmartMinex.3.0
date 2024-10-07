
namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;
    
        #endregion 

    /// <summary>
    /// Состояние оборудования позиционирования
    /// </summary>
    [DisplayName("Состояние оборудования позиционирования")]
    [Ackable]
    public class DeviceStateEventPriority : PriorityEventBase, IDeviceStateEventPriority
    {
        /// <summary>
        /// Оборудование позиционирования
        /// </summary>
        [DisplayName("Устройство")]
        [Description("Оборудование позиционирования")]
        public virtual Device Device 
        { get; set; }

        /// <summary>
        /// Состояние оборудования позиционирования
        /// </summary>
        [DisplayName("Состояние устройства")]
        [Description("Состояние инфраструктурного оборудования позиционирования")]
        public virtual DeviceState DeviceState 
        { get; set; }

        IDevice IDeviceStateEventPriority.Device
        { get => Device; set => Device = value as Device; }
    }
}