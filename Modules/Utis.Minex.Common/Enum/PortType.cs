
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип порта линии считывателей.
    /// </summary>
    [DisplayName("Тип порта линии считывателей")]
    public enum PortType
    {
        /// <summary>
        /// TCP.
        /// </summary>
        [DisplayName("TCP")]
        TCP = 0,

        /// <summary>
        /// COM.
        /// </summary>
        [DisplayName("COM")]
        COM = 1,

        /// <summary>
        /// UDP.
        /// </summary>
        [DisplayName("UDP")]
        UDP = 2,

        /// <summary>
        /// TCPRTU.
        /// </summary>
        [DisplayName("TCPRTU")]
        TCPRTU = 3,

        /// <summary>
        /// UDPRTU.
        /// </summary>
        [DisplayName("UDPRTU")]
        UDPRTU = 4,
    }
}