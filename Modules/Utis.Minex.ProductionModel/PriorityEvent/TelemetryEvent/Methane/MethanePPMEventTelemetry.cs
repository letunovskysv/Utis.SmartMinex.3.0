using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent.Methane
{
    /// <summary>
    /// Событие по метану в относительном значении (миллионных долях(PPM))
    /// </summary>
    [DisplayName("Событие по метану в относительном значении (миллионных долях(PPM))")]
    public class MethanePPMEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// PPM(относительное значение в миллионных долях)
        /// </summary>
        [DisplayName("PPM(относительное значение в миллионных долях)")]
        public virtual float PPM { get; set; }
    }
}