
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using       

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Событие уровня заряда аккумуляторной батареи.
    /// </summary>
    [DisplayName("Событие уровня заряда аккумуляторной батареи")]
    [Ackable]
    public class ChargeLevelEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Уровень заряда.
        /// </summary>
        [DisplayName("Уровень заряда")]
        public virtual ChargeLevel ChargeLevel
        { get; set; }
    }
}