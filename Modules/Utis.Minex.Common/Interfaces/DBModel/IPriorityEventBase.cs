using System;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Событие с приоритетом.
    /// </summary>
    [DisplayName("Событие с приоритетом")]
    public interface IPriorityEventBase : IVersionObjectBase
    {
        /// <summary>
        /// Статус события.
        /// </summary>
        [DisplayName("Статус события")]
        [Description("Статус состояния: отражает состояние источника события")]
        StateEvent StateEvent
        { get; set; }

        /// <summary>
        /// Приоритет события.
        /// </summary>
        [DisplayName("Приоритет события")]
        [Description("Приоритет события: приоритет важности события")]
        PriorityEnum Priority
        { get; set; }

        /// <summary>
        /// Дата, время поступления события из источника, фиксации в БД.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника, фиксации в БД")]
        DateTime Datetime
        { get; set; }

        /// <summary>
        /// Признак события сброса.
        /// </summary>
        [DisplayName("Признак события сброса")]
        bool IsReset
        { get; set; }
    }
}
