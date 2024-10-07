
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние обездвиживания.
    /// </summary>
    [DisplayName("Состояние обездвиживания")]
    public enum FreezeType : byte
    {
        /// <summary>
        /// В движении.
        /// </summary>
        [DisplayName("В движении")]
        NotFreeze = 0,

        /// <summary>
        /// Обездвижен. 
        /// </summary>
        [DisplayName("Обездвижен")]
        FreezeFiveMinuts = 1,
    }
}