using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Конфигурация порта линии считывателей.
    /// </summary>
    [DisplayName("Состояние порта линии RS485")]
    public interface IPortStateEventPriority : IPriorityEventBase
    {        /// <summary>
             /// Идентификатор линии.
             /// </summary>
        [DisplayName("Конфигурация линии считывателей")]
        [Description("Конфигурация линии считывателей")]
        public ILineConfig LineConfig
        { get; set; }

        /// <summary>
        /// Номер порта.
        /// </summary>
        [DisplayName("Порт")]
        [Description("Номер порта")]
        public int PortNum
        { get; set; }

        /// <summary>
        /// Статус порта.
        /// </summary>
        [DisplayName("Статус")]
        [Description("Статус порта")]
        public DeviceState PortState
        { get; set; }
    }
}
