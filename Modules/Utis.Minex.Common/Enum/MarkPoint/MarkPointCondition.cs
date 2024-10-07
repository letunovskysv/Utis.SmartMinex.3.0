
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние АТО.
    /// </summary>
    [DisplayName("Состояние АТО")]
    public enum MarkPointCondition
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [DisplayName("Не определено")]
        [Description("Не определено")]
        None = 0,

        /// <summary>
        /// Исправно.
        /// </summary>
        [DisplayName("Исправно")]
        [Description("Исправно")]
        Good = 1,

        /// <summary>
        /// Неисправно.
        /// </summary>
        [DisplayName("Неисправно")]
        [Description("Неисправно")]
        NoGood = 2,

        /// <summary>
        /// Подлежит проверке.
        /// </summary>
        [DisplayName("Подлежит проверке")]
        [Description("Подлежит проверке")]
        NeedVerified  = 4,

        /// <summary>
        /// Отказ.
        /// </summary>
        [DisplayName("Отказ")]
        [Description("Отказ")]
        Fault = 8,
    }
}