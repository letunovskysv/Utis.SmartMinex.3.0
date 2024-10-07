using System;

namespace Utis.Minex.ProductionModel.Positioning
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Конфигурация порта линии считывателей.
    /// </summary>
    [DisplayName("Конфигурация порта линии считывателей")]
    public class PortSettings : CatalogBase, IPortSettings
    {
        /// <summary>
        /// Тип порта (COM, TCP, UDP, TCPRTU, UDPRTU).
        /// </summary>
        [DisplayName("Тип порта")]
        [Description("Тип порта (COM, TCP, UDP, TCPRTU, UDPRTU")]
        public virtual PortType PortType 
        { get; set; }

        /// <summary>
        /// Время ожидания первого байта, в милисекундах.
        /// </summary>
        [DisplayName("Время ожидания 1го байта")]
        [Description("Время ожидания первого байта, в милисекундах")]
        public virtual int TimeOut1ByteMs
        { get; set; } = 1000;

        /// <summary>
        /// Время ожидания последующих байтов, в милисекундах.
        /// </summary>
        [DisplayName("Время ожидания байтов")]
        [Description("Время ожидания последующих байтов, в мс.")]
        public virtual int TimeOutBytesMs 
        { get; set; } = 1000;

        /// <summary>
        /// Тип переоткрытия порта линии считывателей,
        /// используется для контроля связи с преобразователем порта — FTDI, MOXA, и т.д.
        /// </summary>
        [DisplayName("Тип переоткрытия порта линии считывателей")]
        [Description("Используется для контроля связи с преобразователем порта — FTDI, MOXA, и т.д.")]
        public virtual PortReOpenType ReOpenType
        { get; set; }
        
        /// <summary>
        /// Скорость порта.
        /// </summary>
        [DisplayName("Скорость порта")]
        public virtual int BaudRate
        { get; set; }
        
        /// <summary>
        /// Порт IP (указывается в поле IP через ":").
        /// </summary>
        /// <remarks>Поле Readonly</remarks>
        /// <summary>Строковое представление</summary>
        public override string ToString()
        {
            return $"{Enum.GetName(typeof(PortType), PortType)}{Id}";
        }
    }
}