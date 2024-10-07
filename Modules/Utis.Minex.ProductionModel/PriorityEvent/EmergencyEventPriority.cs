using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие аварии в шахте
    /// </summary>
    [DisplayName("Событие аварии в шахте")]
    [Description("Событие аварии в шахте c с приоритетами")]
    [Ackable]
    public class EmergencyEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Номер аварии
        /// </summary>
        [DisplayName("Номер аварии")]
        public virtual int Alarm { get; set; }

        /// <summary>
        /// Индивидуальное устройство
        /// </summary>
        [DisplayName("Индивидуальное устройство")]
        public virtual IndividualDevice IndividualDevice { get; set; }

        /// <summary>
        /// Событие
        /// </summary>
        [DisplayName("Событие")]
        public virtual EmergencyType EmergencyType { get; set; }

        /// <summary>
        /// Источник аварии
        /// </summary>
        [DisplayName("Источник")]
        public virtual EmergencyInitiatorType SourceType { get; set; }

        /// <summary>
        /// Канал получения вызова
        /// </summary>
        [DisplayName("Канал получения вызова")]
        public virtual EmergencyReceivingType ReceivingType { get; set; }
    }
}