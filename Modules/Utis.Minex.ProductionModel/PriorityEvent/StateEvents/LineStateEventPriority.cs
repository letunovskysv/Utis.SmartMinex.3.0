using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Positioning;

        #endregion

    /// <summary>
    /// Состояние обрыва линии связи.
    /// </summary>
    [DisplayName("Состояние обрыва линии связи")]
    [Ackable]
    public class LineStateEventPriority : PriorityEventBase, ILineStateEventPriority
    {
        /// <summary>
        /// Конфигурация линии считывателей.
        /// </summary>
        [DisplayName("Конфигурация линии считывателей")]
        [Description("Конфигурация линии считывателей")]
        public virtual LineConfig LineConfig 
        { get; set; }

        /// <summary>
        /// Состояние линии.
        /// </summary>
        [DisplayName("Состояние линии")]
        [Description("Состояние линии RS485 Modbus")]
        public virtual LineState LineState 
        { get; set; }

        ILineConfig ILineStateEventPriority.LineConfig { get => LineConfig; set => LineConfig = value as LineConfig; }
    }
}