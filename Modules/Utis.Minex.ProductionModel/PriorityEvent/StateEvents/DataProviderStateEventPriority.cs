
namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

        #endregion

    /// <summary>
    /// Событие состояния поставщика данных.
    /// </summary>
    [DisplayName("Событие состояния поставщика данных")]
    public class DataProviderStateEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Поставщик данных.
        /// </summary>
        [DisplayName("Поставщик данных")]
        public virtual long DataProviderId
        { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [DisplayName("Статус")]
        public virtual DataProviderState ProviderState
        { get; set; }

        /// <summary>
        /// IP-адрес/имя хоста.
        /// </summary>
        [DisplayName("IP-адрес/имя хоста")]
        public virtual string Host
        { get; set; }
    }
}