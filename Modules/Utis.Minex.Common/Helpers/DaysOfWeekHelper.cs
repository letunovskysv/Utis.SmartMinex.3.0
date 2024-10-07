using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Utis.Minex.Common.Helpers
{
    public static class DaysOfWeekHelper
    {
        private static readonly CultureInfo _ruCulture = CultureInfo.GetCultureInfo("ru-RU");

        /// <summary>
        /// Конвертировать DayOfWeek в кириллицу
        /// </summary>
        /// <returns></returns>
        public static string ToRusConvert(DayOfWeek d)
        {
            var rusValue = _ruCulture.DateTimeFormat.GetDayName(d);
            return rusValue;
        }

        /// <summary>
        /// Конвертировать DayOfWeek в кириллицу с заглавными 1-ми буквами
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToRusConvertUpperFirst(DayOfWeek d)
        {
            var rusValue = ToRusConvert(d);
            return $"{rusValue.Remove(1, rusValue.Length - 1).ToUpper()}{rusValue.Remove(0, 1)}";
        }

        /// <summary>
        /// Порядок дня по российской неделе
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int GetOrder(this DayOfWeek d)
        {
            var ind = d ==  DayOfWeek.Sunday ? 7 : (int)d;

            return ind;
        }

        /// <summary>
        /// Сортировать по российской неделе
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static IEnumerable<DayOfWeek> SortByRus(this IEnumerable<DayOfWeek> days)
        {
            var sorted = days
                .Select(x=> new { Index = x.GetOrder(), Value = x})
                .OrderBy(x=> x.Index)
                .Select(x=> x.Value)
                .ToArray();

            return sorted;
        }

        /// <summary>
        /// Русифицированный список дней
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetRusDays()
        {
            var days = System.Enum.GetValues<DayOfWeek>()
                .ToList();

            days.Remove(DayOfWeek.Sunday); 
            days.Add(DayOfWeek.Monday);

            return days.Select(x=> ToRusConvertUpperFirst(x));
        }
    }
}
