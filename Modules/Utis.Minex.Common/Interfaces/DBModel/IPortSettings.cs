using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Конфигурация порта линии считывателей.
    /// </summary>
    [DisplayName("Конфигурация порта линии считывателей")]
    public interface IPortSettings : IObjectNamed
    {
        /// <summary>
        /// Тип порта (COM, TCP, UDP, TCPRTU, UDPRTU).
        /// </summary>
        [DisplayName("Тип порта")]
        [Description("Тип порта (COM, TCP, UDP, TCPRTU, UDPRTU")]
        PortType PortType
        { get; set; }

        /// <summary>
        /// Время ожидания первого байта, в милисекундах.
        /// </summary>
        [DisplayName("Время ожидания 1го байта")]
        [Description("Время ожидания первого байта, в милисекундах")]
        int TimeOut1ByteMs
        { get; set; }

        /// <summary>
        /// Время ожидания последующих байтов, в милисекундах.
        /// </summary>
        [DisplayName("Время ожидания байтов")]
        [Description("Время ожидания последующих байтов, в мс.")]
        int TimeOutBytesMs
        { get; set; }

        /// <summary>
        /// Тип переоткрытия порта линии считывателей,
        /// используется для контроля связи с преобразователем порта — FTDI, MOXA, и т.д.
        /// </summary>
        [DisplayName("Тип переоткрытия порта линии считывателей")]
        [Description("Используется для контроля связи с преобразователем порта — FTDI, MOXA, и т.д.")]
        PortReOpenType ReOpenType
        { get; set; }

        /// <summary>
        /// Скорость порта.
        /// </summary>
        [DisplayName("Скорость порта")]
        int BaudRate
        { get; set; }
    }
}
