using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.CommandAndCalls;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие аварийного вызова по шахте, с приоритетом
    /// </summary>
    [DisplayName("Событие аварийного вызова по шахте, с приоритетом")]
    [Ackable]
    public class EmergencyCallEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Источник вызова
        /// </summary>
        [DisplayName("Источник вызова")]
        public virtual EmergencyCallType EmergencyCallType { get; set; }

        /// <summary>
        /// Имя вызвавшего аварию в шахте
        /// </summary>
        [DisplayName("Имя вызвавшего аварию в шахте")]
        public virtual string CallerName { get; set; }

        /// <summary>
        /// Команда диспечера
        /// </summary>
        [DisplayName("Команда диспечера")]
        public virtual DispatcherCommand DispatcherCommand { get; set; }

        /// <summary>
        /// Номер метки РБ, по которой выполняется вызов/сброс
        /// </summary>
        /// <remarks>В случае вызова из шахты</remarks>
        [DisplayName("Номер метки РБ, по которой выполняется вызов/сброс")]
        public virtual int Label { get; set; }
    }
}