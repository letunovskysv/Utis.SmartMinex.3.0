
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Приоритет события.
    /// </summary>
    [DisplayName("Приоритет события")]
    public enum PriorityEnum : byte
    {
        /// <summary>
        /// Низкий.
        /// </summary>
        [DisplayName("Низкий")]
        Low = 0,

        /// <summary>
        /// Средний.
        /// </summary>
        [DisplayName("Средний")]
        Medium = 1,

        /// <summary>
        /// Высокий.
        /// </summary>
        [DisplayName("Высокий")]
        High = 2,
    }
}