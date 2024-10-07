
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent.Methane
{
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Событие значения метана в кадегории ПДК.
    /// </summary>
    [DisplayName("Событие значения метана в кадегории ПДК")]
    [Ackable]
    public class MethaneLevelEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Значение метана в кадегории ПДК.
        /// </summary>
        [DisplayName("Значение метана в кадегории ПДК")]
        public virtual MethaneLevel MethaneLevel { get; set; }
    }
}