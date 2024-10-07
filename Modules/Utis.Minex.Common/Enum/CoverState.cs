
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояния крышки.
    /// </summary>
    [DisplayName("Состояния крышки")]
    public enum CoverState : byte
    {
        /// <summary>
        /// Закрыта.
        /// </summary>
        [DisplayName("Закрыта")]
        Closed = 0,
        
        /// <summary>
        /// Открыта.
        /// </summary>
        [DisplayName("Открыта")]
        Opened = 1,
    }
}