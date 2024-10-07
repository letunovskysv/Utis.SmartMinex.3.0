
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип события в уведомлении о спуске/подъеме.
    /// </summary>
    [DisplayName("Тип события в уведомлении о спуске/подъеме")]
    public enum DeascentsOperationType
    {
        /// <summary>
        /// Подъем.
        /// </summary>
        [DisplayName("Подъем")]
        Climb = 0,

        /// <summary>
        /// Спуск.
        /// </summary>
        [DisplayName("Спуск")]
        Descent = 1,
    }
}