
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Уровень заряда.
    /// </summary>
    [DisplayName("Уровень заряда")]
    public enum ChargeLevel : byte
    {
        /// <summary>
        /// Нормальный заряд.
        /// </summary>
        [DisplayName("Нормальный заряд")]
        Normal = 0,

        /// <summary>
        /// Низкий заряд.
        /// </summary>
        [DisplayName("Низкий заряд")]
        Low    = 1,
    }
}