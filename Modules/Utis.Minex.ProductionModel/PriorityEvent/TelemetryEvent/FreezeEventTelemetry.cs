
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Событие обездвиживания.
    /// </summary>
    [DisplayName("Обездвиживание")]
    [Ackable]
    public class FreezeEventTelemetry : TelemetryEventPriorityBase
    {
        /// <summary>
        /// Состояние обездвиживания.
        /// </summary>
        [DisplayName("Состояние обездвиживания")]
        public virtual FreezeType FreezeType
        { get; set; }
    }
}