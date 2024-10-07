using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Событие посещений зоны
    /// </summary>
    [DisplayName("Событие посещений зоны")]
    [Ackable]
    public class ZoneEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Идентификатор зоны.
        /// </summary>
        [DisplayName("Идентификатор зоны")]
        public long ZoneId
        { get; set; }

        /// <summary>
        /// Номер метки объекта.
        /// </summary>
        [DisplayName("Номер метки объекта")]
        public int ObjectLabel
        { get; set; }

        /// <summary>
        /// Тип объекта.
        /// </summary>
        [DisplayName("Тип объекта")]
        public MobileDeviceType ObjectType
        { get; set; }

        /// <summary>
        /// Тип события.
        /// </summary>
        [DisplayName("Тип события")]
        public ZoneEventType Type
        { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DisplayName("Идентификатор")]
        public long ObjectId
        { get; set; }

        /// <summary>
        /// Типы нарушений
        /// </summary>
        [DisplayName("Типы нарушений")]
        public IEnumerable<DangerousZoneType> ViolationTypes
        { get; set; } = new List<DangerousZoneType>();

        /// <summary>
        /// Идентификатор зоны постового
        /// </summary>
        [DisplayName("Идентификатор зоны постового")]
        public long? GuardZoneId
        { get; set; }
    }
}