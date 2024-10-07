using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    /// <summary>
    /// Событие ёмкости оборудования
    /// </summary>
    [DisplayName("Событие ёмкости оборудования")]
    public class CapacityEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Ёмкость, мАh
        /// </summary>
        [DisplayName("Ёмкость, мАh")]
        public virtual long Capacity { get; set; }
    }
}