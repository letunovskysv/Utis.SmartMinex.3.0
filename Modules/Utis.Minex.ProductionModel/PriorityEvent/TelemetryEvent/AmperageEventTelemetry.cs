using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    /// <summary>
    /// Событие силы тока
    /// </summary>
    [DisplayName("Событие силы тока")]
    public class AmperageEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Сила тока, mA
        /// </summary>
        [DisplayName("Сила тока, mA")]
        public virtual long Amperage { get; set; }
    }
}