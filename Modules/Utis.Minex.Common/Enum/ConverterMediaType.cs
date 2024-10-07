
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип конвертируемого соединения
    /// </summary>
    [DisplayName("Тип конвертируемого соединения")]
    public enum ConverterMediaType
    {
        /// <summary>
        /// Not defined
        /// </summary>
        [DisplayName("Not defined")]
        None = 0,

        /// <summary>
        /// RS-485
        /// </summary>
        [DisplayName("RS-485")]
        RS485 = 1,

        /// <summary>
        /// USB
        /// </summary>
        [DisplayName("USB")]
        USB = 2,

        /// <summary>
        /// Ethernet
        /// </summary>
        [DisplayName("Ethernet")]
        Ethernet = 3,
    }
}