using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    /// <summary>
    /// Событие температуры крышки
    /// </summary>
    [DisplayName("Событие температуры крышки")]
    public class CapTemperatureEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Температура
        /// </summary>
        [DisplayName("Температура")]
        public virtual long Temperature { get; set; }
    }
}