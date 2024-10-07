namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы мест установки
    /// </summary>
    [DisplayName("Типы мест установки")]
    public enum LocationDeviceType
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Погрузка
        /// </summary>
        [DisplayName("Погрузка")]
        Loading = 1,

        /// <summary>
        /// Разгрузка
        /// </summary>
        [DisplayName("Разгрузка")]
        Unloading = 2,

        /// <summary>
        /// Перегрузка
        /// </summary>
        [DisplayName("Перегрузка")]
        Reloading = 3,

        /// <summary>
        /// Опасное
        /// </summary>
        [DisplayName("Опасное")]
        Dangerous = 4,

        /// <summary>
        /// Складирование негабаритов
        /// </summary>
        [DisplayName("Складирование негабаритов")]
        OversizedStorage = 5,

        /// <summary>
        /// Маршрутное
        /// </summary>
        [DisplayName("Маршрутное")]
        Route = 6,
    }
}
