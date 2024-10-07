namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Positioning;

    #endregion

    /// <summary>
    /// Состояние порта линии RS485.
    /// </summary>
    [DisplayName("Состояние порта линии RS485")]
    [Ackable]
    public class PortStateEventPriority : PriorityEventBase, IPortStateEventPriority
    {
        /// <summary>
        /// Идентификатор линии.
        /// </summary>
        [DisplayName("Конфигурация линии считывателей")]
        [Description("Конфигурация линии считывателей")]
        public virtual LineConfig LineConfig
        { get; set; }

        /// <summary>
        /// Номер порта.
        /// </summary>
        [DisplayName("Порт")]
        [Description("Номер порта")]
        public virtual int PortNum 
        { get; set; }

        /// <summary>
        /// Статус порта.
        /// </summary>
        [DisplayName("Статус")]
        [Description("Статус порта")]
        public virtual DeviceState PortState 
        { get; set; }

        ILineConfig IPortStateEventPriority.LineConfig { get => LineConfig; set => LineConfig = value as LineConfig; }
    }
}