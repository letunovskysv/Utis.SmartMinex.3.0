using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.Positioning;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    public class ReaderToLineChangedEventPriority : PriorityEventBase
    {
        /// <summary>
        /// id считывателя
        /// </summary>    
        [DisplayName("Считыватель")]
        public Reader Reader
        { get; set; }

        /// <summary>
        /// Конфигурация линии считывателей.
        /// </summary>
        [DisplayName("Конфигурация линии считывателей")]
        public virtual LineConfig LineConfig
        { get; set; }
    }
}
