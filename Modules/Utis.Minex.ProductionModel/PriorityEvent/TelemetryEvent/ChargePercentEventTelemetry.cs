
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    using Utis.Minex.Common;

    /// <summary>
    /// Событие процента зарядки аккумуляторной батареи.
    /// </summary>
    [DisplayName("Событие процента зарядки аккумуляторной батареи")]
    public class ChargePercentEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Заряд аккумуляторной батареи, %.
        /// </summary>
        [DisplayName("Заряд аккумуляторной батареи, %")]
        public virtual long ChargePercent 
        { get; set; }
    }
}