using System;

namespace Utis.Minex.Common
{
        using Utis.Minex.Common.Enum;

    /// <summary>
    /// Событие с приоритетом.
    /// </summary>
    [DisplayName("Событие с приоритетом")]
    public abstract class PriorityEventBase : VersionObjectBase, IPriorityEventBase
    {
        /// <summary>
        /// Статус события.
        /// </summary>
        [DisplayName("Статус события")]
        [Description("Статус состояния: отражает состояние источника события")]
        public virtual StateEvent StateEvent
        { get; set; }

        /// <summary>
        /// Приоритет события.
        /// </summary>
        [DisplayName("Приоритет события")]
        [Description("Приоритет события: приоритет важности события")]
        public virtual PriorityEnum Priority
        { get; set; }

        /// <summary>
        /// Дата, время поступления события из источника, фиксации в БД.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника, фиксации в БД")]
        public virtual DateTime Datetime 
        { get; set; }

        /// <summary>
        /// Признак события сброса.
        /// </summary>
        [DisplayName("Признак события сброса")]
        public virtual bool IsReset 
        { get; set; }
    }
}