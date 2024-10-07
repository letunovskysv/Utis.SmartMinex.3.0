
namespace Utis.Minex.ProductionModel.Devices
{
    using Utis.Minex.Common;

    /// <summary>
    /// Мобильное устройство регистрации.
    /// </summary>
    [DisplayName("Мобильное устройство регистрации")]
    public class MobileRegDevice : DeviceWithRfid
    {
        /// <summary>
        /// Версия прошивки.
        /// </summary>
        [DisplayName("Версия прошивки")]
        public virtual string Version 
        { get; set; }

        /// <summary>
        /// IP-адрес
        /// </summary>
        [DisplayName("IP-адрес")]
        public virtual string Ip { get; set; }
    }
}