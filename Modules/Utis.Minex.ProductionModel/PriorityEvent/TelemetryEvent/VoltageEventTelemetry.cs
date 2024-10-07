using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    /// <summary>
    /// Событие вольтажа оборудования
    /// </summary>
    [DisplayName("Событие вольтажа оборудования")]
    public class VoltageEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Вольтаж, mV
        /// </summary>
        [DisplayName("Вольтаж, mV")]
        public virtual long Voltage { get; set; }
    }
}