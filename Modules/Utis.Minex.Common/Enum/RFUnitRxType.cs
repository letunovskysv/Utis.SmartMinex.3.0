
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Канал радиоблока.
    /// </summary>
    [DisplayName("Канал радиоблока")]
    public enum RFUnitRxType
    {
        /// <summary>
        /// Прямой.
        /// </summary>     
        [DisplayName("Прямой")]
        Straight = 0,

        /// <summary>
        /// Зеркальный.
        /// </summary>
        [DisplayName("Зеркальный")]
        Mirror = 1,
    }
}