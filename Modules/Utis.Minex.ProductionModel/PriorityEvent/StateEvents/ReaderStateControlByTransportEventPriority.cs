
namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Positioning;

        #endregion

    /// <summary>
    /// Состояние оборудования позиционирования
    /// </summary>
    [DisplayName("Контроль считывателей (транспортом)")]
    public class ReaderStateControlByTransportEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Оборудование позиционирования.
        /// </summary>
        [DisplayName("Устройство")]
        [Description("Оборудование позиционирования")]
        public virtual Reader Reader
        { get; set; }

        /// <summary>
        /// Состояние оборудования позиционирования.
        /// </summary>
        [DisplayName("Состояние устройства")]
        [Description("Состояние инфраструктурного оборудования позиционирования")]
        public virtual DeviceState ReaderState
        { get; set; }

        /// <summary>
        /// Номер порта.
        /// </summary>
        [DisplayName("Порт")]
        [Description("Номер порта")]
        public virtual int PortNum
        { get; set; }

        /// <summary>
        /// Статус порта.
        /// </summary>
        [DisplayName("Статус")]
        [Description("Статус порта")]
        public virtual DeviceState PortState
        { get; set; }

        /// <summary>
        /// Идентификатор транспорта.
        /// </summary>
        [DisplayName("Транспорт")]
        [Description("Транспорт")]
        public virtual Transport Transport
        { get; set; }

        /// <summary>
        /// Транспортное оборудования позиционирования 
        /// </summary>
        [DisplayName("Устройства транспорта")]
        [Description("Транспортное оборудования позиционирования")]
        public virtual MobileRegDevice MobileRegDevice
        { get; set; }
    }
}