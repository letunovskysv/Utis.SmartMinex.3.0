
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип движения.
    /// </summary>
    [DisplayName("Тип движения")]
    public enum MoveState : byte
    {
        /// <summary>
        /// Остановился.
        /// </summary>
        [DisplayName("Остановился")]
        Stopped = 0,

        /// <summary>
        /// Движется.
        /// </summary>
        [DisplayName("Движется")]
        Moving = 1,
    }
}