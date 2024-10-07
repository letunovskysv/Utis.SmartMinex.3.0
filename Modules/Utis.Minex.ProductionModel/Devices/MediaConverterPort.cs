using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Positioning;

namespace Utis.Minex.ProductionModel.Devices
{
    /// <summary>
    /// порт медиаконвертера
    /// </summary>
    [DisplayName("порт медиаконвертера")]
    public class MediaConverterPort : Device, IMediaConverterPort
    {
        /// <summary>Медиаконвертер</summary>
        [DisplayName("Медиаконвертер")]
        public virtual MediaConverter MediaConverter { get; set; }

        /// <summary>Настройки порта</summary>
        [DisplayName("Настройки порта")]
        public virtual PortSettings Settings { get; set; }

        /// <summary>№ порта при соединении по IP</summary>
        [DisplayName("№ порта")]
        [Description("№ порта при соединении по IP")]
        public virtual int IPPort { get; set; }

        IMediaConverter IMediaConverterPort.MediaConverter
        { get => MediaConverter; set => MediaConverter = value as MediaConverter; }
        IPortSettings IMediaConverterPort.Settings 
        { get => Settings; set => Settings = value as PortSettings; }
    }
}