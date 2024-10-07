namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип горной выработки
    /// </summary>
    [DisplayName("Тип горной выработки")]
    public enum MineType
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Просто выработка
        /// </summary>
        [DisplayName("Выработка")]
        Excavation = 1,

        /// <summary>
        /// Рудоспуск
        /// </summary>
        [DisplayName("Рудоспуск")]
        Pass = 2,

        /// <summary>
        /// Ствол
        /// </summary>
        [DisplayName("Ствол")]
        Shaft = 3,

        /// <summary>
        /// Ствол
        /// </summary>
        [DisplayName("Вент. восстающий")]
        Vent = 4,

        /// <summary>
        /// Короткая ниша
        /// </summary>
        [DisplayName("Короткая ниша")]
        ShortNisha = 5
    }
}