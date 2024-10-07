
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип переоткрытия порта линии считывателей.
    /// </summary>
    [DisplayName("Тип переоткрытия порта линии считывателей")]
    public enum PortReOpenType
    {
        /// <summary>
        /// Авто.
        /// </summary>
        [DisplayName("Авто")]
        Auto = 0,

        /// <summary>
        /// Всегда.
        /// </summary>
        [DisplayName("Всегда")]
        Always = 1,

        /// <summary>
        /// Никогда.
        /// </summary>
        [DisplayName("Никогда")]
        Never = 2,
    }
}