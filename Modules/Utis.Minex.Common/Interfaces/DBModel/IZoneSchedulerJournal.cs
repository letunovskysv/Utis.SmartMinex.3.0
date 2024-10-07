using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Utis.Minex.Common.Attributes;
using Utis.Minex.Common.Enums;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал расписания активности зон
    /// </summary>
    [DisplayName("Журнал расписания активности зон")]
    public interface IZoneSchedulerJournal : IJournalClose
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        IZoneDangerousJournal ZoneDangerous { get; set; }

        ///<summary>
        /// Дни недели <<see cref="System.DayOfWeek"/>
        /// </summary>
        [DisplayName("Дни недели")]
        IEnumerable<DayOfWeek> DaysOfWeek { get; set; }

        ///<summary>
        /// Время начала активности
        /// </summary>
        [DisplayName("Время начала активности")]
        [CustomColumnAttribute(SettingsType.Time)]        
        TimeSpan TimeStart { get; set; }

        ///<summary>
        /// Время окончания активности
        /// </summary>
        [DisplayName("Время окончания активности")]
        [CustomColumnAttribute(SettingsType.Time)]
        TimeSpan TimeEnd { get; set; }

        string IDataErrorInfo.Error => ErrorByProps(nameof(DaysOfWeek), nameof(TimeStart), nameof(TimeEnd));

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(DaysOfWeek):
                        if (DaysOfWeek == null || !DaysOfWeek.Any())
                            return "Дни обязательны к заполнению";
                        break;
                    case nameof(TimeStart):
                        if (TimeStart != default)
                            return CheckTimes();
                        break;

                    case nameof(TimeEnd):
                        return CheckTimes();
                }

                string CheckTimes()
                {
                    if (TimeStart >= TimeEnd)
                        return "Время старта должно быть меньше времени окончания";

                    return string.Empty;
                }

                return string.Empty;
            }
        }
    }
}
