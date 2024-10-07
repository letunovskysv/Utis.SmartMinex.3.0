
namespace Utis.Minex.ProductionModel.PriorityEvent
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

        #endregion

    /// <summary>
    /// Событие состояния соединения с ПУКС.
    /// </summary>
    [DisplayName("Событие состояния соединения с ПУКС")]
    public class PuksConnectedEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Состояние соединения.
        /// </summary>
        [DisplayName("Состояние соединения")]
        public virtual PuksState State 
        { get; set; }
    }
}