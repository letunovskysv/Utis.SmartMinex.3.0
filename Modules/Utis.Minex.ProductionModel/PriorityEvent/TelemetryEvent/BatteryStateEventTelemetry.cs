using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    /// <summary>
    /// Событие состояния батареи
    /// </summary>
    [DisplayName("Событие температуры крышки")]
    public class BatteryStateEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Состояние батареи
        /// </summary>
        [DisplayName("Состояние батареи")]
        public virtual BatteryState BatteryState { get; set; }
    }
}