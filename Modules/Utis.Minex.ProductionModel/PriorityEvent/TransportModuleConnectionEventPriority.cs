using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие состояния соединения с Транспортным Модулем.
    /// </summary>
    [DisplayName("Событие состояния соединения с Транспортным Модулем")]
    public class TransportModuleConnectionEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Состояние соединения
        /// </summary>
        [DisplayName("Состояние соединения")]
        public TransportModuleConnectionState ConnectionState { get; set; }
    }
}
