using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие доставки сообщения на пейджер
    /// </summary>
    [DisplayName("Событие доставки сообщения на пейджер")]
    public class PagerEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Текст сообщения от пейджера
        /// </summary>
        [DisplayName("Текст сообщения от пейджера")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Пейджер
        /// </summary>
        [DisplayName("Пейджер")]
        public virtual Pager Pager { get; set; }

        /// <summary>
        /// Тип события пейджера
        /// </summary>
        [DisplayName("Тип события пейджера")]
        public virtual PagerEventType EventType { get; set; }
    }
}