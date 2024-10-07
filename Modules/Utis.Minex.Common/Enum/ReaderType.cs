
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип УРПТ.
    /// </summary>
    [DisplayName("Тип УРПТ")]
    public enum ReaderType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        None      = 0,

        /// <summary>
        /// Обычный (стандартный).
        /// </summary>
        [DisplayName("Обычный (стандартный)")]
        Standard  = 1,

        /// <summary>
        /// Комбинированный.
        /// </summary>
        [DisplayName("Комбинированный")]
        Combined  = 2,

        /// <summary>
        /// Выходной.
        /// </summary>
        [DisplayName("Выходной")]
        Output    = 3,

        /// <summary>
        /// Транспортный.
        /// </summary>
        [DisplayName("Транспортный")]
        Transport = 4,

        /// <summary>
        /// Охранный.
        /// </summary>
        [DisplayName("Охранный")]
        Security = 5,

        /// <summary>
        /// Тупиковый.
        /// </summary>
        [DisplayName("Тупиковый")]
        Deadlock = 6,
    }
}