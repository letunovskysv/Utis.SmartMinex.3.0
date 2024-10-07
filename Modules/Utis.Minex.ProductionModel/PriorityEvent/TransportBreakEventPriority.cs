using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Catalog;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие разрыва/сцепления транспорта
    /// </summary>
    [DisplayName("Событие разрыва/сцепления транспорта")]
    [Description("Событие разрыва/сцепления транспорта")]
    [Ackable]
    public class TransportBreakEventPriority : PriorityEventBase
    {
        ///<summary>
        /// Транспорт
        /// </summary>
        [DisplayName("Транспорт")]
        public virtual Transport Transport { get; set; }

        /// <summary>
        /// Разрыв/сцепление
        /// </summary>
        [DisplayName("Разрыв/сцепление")]
        public virtual TransportBreakState TransportBreakState { get; set; }
    }
}
