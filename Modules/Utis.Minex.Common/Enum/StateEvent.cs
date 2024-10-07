
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус события.
    /// </summary>
    [DisplayName("Статус события")]
    public enum StateEvent : byte
    {
        /// <summary>
        /// Не задано (по умолчанию).
        /// </summary>
        [DisplayName("Не задано (по умолчанию)")]
        Default = 0,

        /// <summary>
        /// Уведомление.
        /// </summary>
        [DisplayName("Уведомление")]
        Notification = 1,

        /// <summary>
        /// Предупреждение.
        /// </summary>
        [DisplayName("Предупреждение")]
        Warning = 2,

        /// <summary>
        /// Тревога. 
        /// </summary>
        [DisplayName("Тревога")]
        Alarm = 3,
    }
}