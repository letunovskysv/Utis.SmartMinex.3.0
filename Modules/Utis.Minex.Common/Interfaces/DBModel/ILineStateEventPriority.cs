using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Состояние обрыва линии связи.
    /// </summary>
    [DisplayName("Состояние обрыва линии связи")]
    public interface ILineStateEventPriority : IPriorityEventBase
    {
        /// <summary>
        /// Конфигурация линии считывателей.
        /// </summary>
        [DisplayName("Конфигурация линии считывателей")]
        [Description("Конфигурация линии считывателей")]
        public ILineConfig LineConfig
        { get; set; }

        /// <summary>
        /// Состояние линии.
        /// </summary>
        [DisplayName("Состояние линии")]
        [Description("Состояние линии RS485 Modbus")]
        public LineState LineState
        { get; set; }
    }
}
