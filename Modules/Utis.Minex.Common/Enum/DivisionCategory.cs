
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Категория организационной единицы.
    /// </summary>
    [DisplayName("Категория организационной единицы")]
    public enum DivisionCategory
    {
        /// <summary>
        /// Не задано.
        /// </summary>
        [DisplayName("Не задано")]
        Default = 0,

        /// <summary>
        /// Основное.
        /// </summary>
        [DisplayName("Основное")]
        Main = 1,

        /// <summary>
        /// Внешнее.
        /// </summary>
        [DisplayName("Внешнее")]
        Outer = 2,

        /// <summary>
        /// Внутренний подряд.
        /// </summary>
        [DisplayName("Внутренний подряд")]
        Inner = 3,
    }
}