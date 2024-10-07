using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Devices
{
    using Common;
    using Interfaces;

    /// <summary>
    /// Справочник считывателей УРПТ-ИС
    /// </summary>
    [DisplayName("Считыватели УРПТ-ИС")]
    [Description("Справочник считывателей УРПТ-ИС")]
    public class ReaderExt : Reader, IIPDevice
    {
        /// <summary>Медиаконвертер RS485-Ethernet (Modbus TCP - Modbus-RTU</summary>
        [DisplayName("Преобразователь")]
        [Description("Медиаконвертер RS485-Ethernet (Modbus TCP - Modbus-RTU")]
        public virtual MediaConverterEthernet Converter { get; set; }

        /// <summary>IP-адрес WiFi-маршрутизатора</summary>
        [DisplayName("WiFi")]
        [Description("IP-адрес WiFi-маршрутизатора")]
        public virtual string Ip { get; set; }

        /// <summary>ССД, к которому относится медиаконвертер</summary>
        [DisplayName("ССД")]
        [Description("ССД, к которому относится считыватель")]
        public virtual DAServer DAServer { get { return LineConfig.DAServer; } protected internal set { } }
    }
}