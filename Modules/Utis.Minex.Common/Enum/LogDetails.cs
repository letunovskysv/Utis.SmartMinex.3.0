namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Детализация лога необходима для отладки и выявления ошибок
    /// </summary>
    [DisplayName("Детализация лога необходима для отладки и выявления ошибок")]
    public enum LogDetails
    {
        /// <summary>
        /// Минимальный
        /// </summary>
        [DisplayName("Минимальный")]
        Min = 0,

        /// <summary>
        /// Обычный
        /// </summary>
        [DisplayName("Обычный")]
        Normal = 1,

        /// <summary>
        /// Расширенный
        /// </summary>
        [DisplayName("Расширенный")]
        Full = 2
    }
}