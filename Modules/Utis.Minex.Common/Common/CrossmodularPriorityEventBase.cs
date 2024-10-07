
namespace Utis.Minex.Common.Common
{
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Событие с приоритетом
    /// </summary>
    [DisplayName("Событие с приоритетом")]
    public class CrossmodularPriorityEventBase : CrossmodularEventBase
    {
        /// <summary>
        /// Статус события.
        /// </summary>
        [DisplayName("Статус события")]
        [Description("Статус состояния: отражает состояние источника события")]
        public StateEvent StateEvent 
        { get; set; }

        /// <summary>
        /// Приоритет события.
        /// </summary>
        [DisplayName("Приоритет события")]
        [Description("Приоритет события: приоритет важности события")]
        public PriorityEnum Priority 
        { get; set; }
    }
}