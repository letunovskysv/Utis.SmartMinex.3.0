namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Единица измерения периода
    /// </summary>
    [DisplayName("Единица измерения периода")]
    public enum DurationType
    {
        /// <summary>
        /// Секунда
        /// </summary>
        [DisplayName("Секунда")]
        second = 0,

        /// <summary>
        /// Минута
        /// </summary>
        [DisplayName("Минута")]
        minute = 1,

        /// <summary>
        /// Час
        /// </summary>
        [DisplayName("Час")]
        hour = 2,

        /// <summary>
        /// Сутки
        /// </summary>
        [DisplayName("Сутки")]
        day = 3,

        /// <summary>
        /// Неделя
        /// </summary>
        [DisplayName("Неделя")]
        week = 4,

        /// <summary>
        /// Декада
        /// </summary>
        [DisplayName("Декада")]
        Decade = 5,

        /// <summary>
        /// Месяц
        /// </summary>
        [DisplayName("Месяц")]
        Month = 6,

        /// <summary>
        /// Квартал
        /// </summary>
        [DisplayName("Квартал")]
        quarter = 7,

        /// <summary>
        /// Год
        /// </summary>
        [DisplayName("Год")]
        year = 8
    }
}