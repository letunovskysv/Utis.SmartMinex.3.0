using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие получения сообщения от ПУКС (СУБР).
    /// </summary>
    [DisplayName("Событие получения сообщения от ПУКС (СУБР)")]
    public class PuksMessageEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Сообщение.
        /// </summary>
        [DisplayName("Сообщение")]
        public virtual PuksMessage PuksMessage
        { get; set; }

        /// <summary>
        /// Номер аварии.
        /// </summary>
        [DisplayName("Номер аварии")]
        public virtual int AlarmNumber
        { get; set; }
    }
}