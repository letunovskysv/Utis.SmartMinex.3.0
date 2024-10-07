namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип события журнала антинаезда
    /// </summary>
    [DisplayName("Тип события журнала антинаезда")]
    public enum ListRankType
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// Антинаезд
        /// </summary>
        [DisplayName("Антинаезд")]
        Anticollision = 1,

        /// <summary>
        /// Регистрация машиниста
        /// </summary>
        [DisplayName("Регистрация машиниста")]
        Driver = 2,

        /// <summary>
        /// Транспортировка
        /// </summary>
        [DisplayName("Транспортировка")]
        Passenger = 3
    }
}