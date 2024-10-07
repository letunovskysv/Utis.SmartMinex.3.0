using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Результат проверки зоны
    /// </summary>
    public interface IZoneDangerousCheckBase
    {
        /// <summary>
        /// Поврежденные устройства
        /// </summary>
        [DisplayName("Поврежденные устройства")]
        long[] DamagedDevices
        { get; }

        /// <summary>
        /// Статусы события
        /// </summary>
        [DisplayName("Статусы события")]
        int[] TypeStatuses
        { get; }

        /// <summary>
        /// Статусы события типизированные
        /// </summary>
        [DisplayName("Статусы события")]
        public IEnumerable<ZoneDangerousStatusType> Statuses => System.Enum.GetValues<ZoneDangerousStatusType>()
                    .Where(x => TypeStatuses.Contains((int) x))
                    .ToArray();


        /// <summary>
        /// Общий статус проверки
        /// </summary>
        bool IsSuccess => !TypeStatuses.Any();
    }



    /// <summary>
    /// Событие активации опасной зоны
    /// </summary>
    [DisplayName("Событие активации опасной зоны")]
    public interface IZoneDangerousEventPriority : IPriorityEventBase, IZoneDangerousCheckBase
    {
        /// <summary>
        /// Идентификатор зоны.
        /// </summary>
        [DisplayName("Идентификатор зоны")]
        long ZoneId
        { get; set; }

        /// <summary>
        /// Номер метки объекта
        /// </summary>
        [DisplayName("Идентификатор опасной зоны")]
        long ZoneDangerousId
        { get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        [DisplayName("Тип события")]
        ZoneDangerousEventType Type
        { get; set; }

        /// <summary>
        /// Поврежденные устройства
        /// </summary>
        [DisplayName("Поврежденные устройства")]
        new long[] DamagedDevices
        { get; set; }

        /// <summary>
        /// Статусы события
        /// </summary>
        [DisplayName("Статусы события")]
        new int[] TypeStatuses
        { get; set; }
    }
}
