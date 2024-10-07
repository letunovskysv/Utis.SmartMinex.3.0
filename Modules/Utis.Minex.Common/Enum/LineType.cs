namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип линии считывателей.
    /// </summary>
    [DisplayName("Тип линии считывателей")]
    public enum LineType
    {
        /// <summary>
        /// Прямая - 1 порт.
        /// </summary>
        [DisplayName("Прямая - 1 порт")]
        Straight = 0,

        /// <summary>
        /// Кольцевая - 2 порта.
        /// </summary>
        [DisplayName("Кольцевая - 2 порта")]
        Circular = 1,
    }
}