using System.Collections;
using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие активации опасной зоны
    /// </summary>
    [DisplayName("Событие активации опасной зоны")]
    [Ackable]
    public class ZoneDangerousEventPriority : PriorityEventBase, IZoneDangerousCheckBase, IZoneDangerousEventPriority
    {
        /// <summary>
        /// Идентификатор зоны.
        /// </summary>
        [DisplayName("Идентификатор зоны")]
        public long ZoneId
        { get; set; }

        /// <summary>
        /// Идентификатор опасной зоны
        /// </summary>
        [DisplayName("Идентификатор опасной зоны")]
        public long ZoneDangerousId
        { get; set; }    

        /// <summary>
        /// Тип события
        /// </summary>
        [DisplayName("Тип события")]
        public ZoneDangerousEventType Type
        { get; set; }

        /// <summary>
        /// Поврежденные устройства
        /// </summary>
        [DisplayName("Поврежденные устройства")]
        public virtual long[] DamagedDevices
        { get; set; }

        /// <summary>
        /// Статусы события
        /// </summary>
        [DisplayName("Статусы события")]
        public virtual int[] TypeStatuses
        { get; set; }

    }
}