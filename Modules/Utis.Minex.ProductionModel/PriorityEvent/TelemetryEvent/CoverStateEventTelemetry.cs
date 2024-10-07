
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Событие состояния крышки.
    /// </summary>
    [DisplayName("Событие крышки")]
    [Ackable]
    public class CoverStateEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Состояние крышки.
        /// </summary>
        [DisplayName("Состояние крышки")]
        public virtual CoverState CoverState 
        { get; set; }
    }
}