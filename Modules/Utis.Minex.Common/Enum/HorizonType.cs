namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Категории горных выработок
    /// </summary>
    [DisplayName("Категории горных выработок")]
    public enum HorizonType
    {
        /// <summary>
        /// По умолчанию
        /// </summary>
        [DisplayName("По умолчанию")]
        None = 0,

        /// <summary>
        /// Подсечка
        /// </summary>
        [DisplayName("Подсечка")]
        Undercut = 1,

        /// <summary>
        /// Откаточный
        /// </summary>
        [DisplayName("Откаточный")]
        Haulage = 2,

        /// <summary>
        /// Вентиляционно-закладочный
        /// </summary>        
        [DisplayName("Вентиляционно-закладочный")]
        VentilationBackfilling = 3
    }
}