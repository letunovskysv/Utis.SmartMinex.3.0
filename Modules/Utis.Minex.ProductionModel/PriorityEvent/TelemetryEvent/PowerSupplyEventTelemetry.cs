
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using
        
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Событие типа источника питания.
    /// </summary>
    [DisplayName("Событие типа источника питания")]
    [Ackable]
    public class PowerSupplyEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Источник питания.
        /// </summary>
        [DisplayName("Источник питания")]
        public virtual PowerSupplyType PowerSupply 
        { get; set; }
    }
}
