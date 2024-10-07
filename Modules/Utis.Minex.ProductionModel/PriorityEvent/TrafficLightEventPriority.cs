using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие переключения индикации светофора
    /// </summary>
    [DisplayName("Событие индикации светофора")]
    [Description("Событие индикации светофора с приоритетами")]
    [Ackable]
    public class TrafficLightEventPriority : PriorityEventBase
    {
       ///<summary>
        /// Считыватель с функцией светофора
        /// </summary>
        [DisplayName("Считыватель-светофор")]
        public virtual Reader TrafficLightReader { get; set; }
      
           /// <summary>
        /// Состояние индикации светофора
        /// </summary>
        [DisplayName("Индикация светофора")]
        public virtual TrafficLightState TrafficLightState { get; set; }
    }
}
