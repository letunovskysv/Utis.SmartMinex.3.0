using System;
using System.Collections.Generic;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Journals
{

    /// <summary>
    /// Журнал расписания активности зон
    /// </summary>
    [DisplayName("Журнал расписания активности зон")]
    public class ZoneSchedulerJournal : JournalClose, IZoneSchedulerJournal
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        public virtual ZoneDangerousJournal ZoneDangerous { get; set; }

        ///<summary>
        /// Дни недели <<see cref="System.DayOfWeek"/>
        /// </summary>
        [DisplayName("Дни недели")]
        public virtual IEnumerable<DayOfWeek> DaysOfWeek { get; set; }

        ///<summary>
        /// Время начала активности
        /// </summary>
        [DisplayName("Время начала активности")]
        public virtual TimeSpan TimeStart { get; set; }

        ///<summary>
        /// Время окончания активности
        /// </summary>
        [DisplayName("Время окончания активности")]
        public virtual TimeSpan TimeEnd { get; set; }

        IZoneDangerousJournal IZoneSchedulerJournal.ZoneDangerous
        { get => ZoneDangerous; set => ZoneDangerous = value as ZoneDangerousJournal; }
    }
}
