namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Газ
    /// </summary>
    [DisplayName("Газ")]
    public enum Gas
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// Метан
        /// </summary>
        [DisplayName("Метан")]
        Ch4 = 1,

        /// <summary>
        /// Кислород
        /// </summary>
        [DisplayName("Кислород")]
        O2 = 2,

        /// <summary>
        /// Оксид углерода
        /// </summary>
        [DisplayName("Оксид углерода")]
        Co = 3,

        /// <summary>
        /// Диоксид углерода
        /// </summary>
        [DisplayName("Диоксид углерода")]
        Co2 = 4
    }
}