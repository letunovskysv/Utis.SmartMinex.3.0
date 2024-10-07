
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Событие движения.
    /// </summary>
    [DisplayName("Событие движения")]
    public class MoveEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Тип движения.
        /// </summary>
        [DisplayName("Тип движения")]
        public virtual MoveState MoveState 
        { get; set; }
    }
}