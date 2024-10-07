using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.MobileDevice
{
    using Common;

    /// <summary>
    /// Регистрация подключения АРМ мобильного устройства
    /// </summary>
    [DisplayName("АРМ МУ")]
    [Description("Регистрация подключения АРМ мобильного устройства")]
    public class MobileDevice : DataProviderServer
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        [DisplayName("Пользователь")]
        public virtual MobileUser MobileUser { get; set; }
    }
}