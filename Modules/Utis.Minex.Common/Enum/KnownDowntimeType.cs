namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип простоя
    /// </summary>
    [DisplayName("Тип простоя")]
    public enum KnownDowntimeType
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Не задано")]
        None = 0,

        /// <summary>
        /// Общерудничный
        /// </summary>
        [DisplayName("Общерудничный")]
        General = 1,

        /// <summary>
        /// Технологический
        /// </summary>
        [DisplayName("Технологический")]
        Technological = 2,

        /// <summary>
        /// Ремонт
        /// </summary>
        [DisplayName("Ремонт")]
        Repair = 3,
    }
}