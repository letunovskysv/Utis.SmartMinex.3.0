using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// порт медиаконвертера
    /// </summary>
    [DisplayName("порт медиаконвертера")]
    public interface IMediaConverterPort : IDevice
    {
        /// <summary>Медиаконвертер</summary>
        [DisplayName("Медиаконвертер")]
        IMediaConverter MediaConverter { get; set; }

        /// <summary>Настройки порта</summary>
        [DisplayName("Настройки порта")]
        IPortSettings Settings { get; set; }

        /// <summary>№ порта при соединении по IP</summary>
        [DisplayName("№ порта")]
        [Description("№ порта при соединении по IP")]
        int IPPort { get; set; }
    }
}
