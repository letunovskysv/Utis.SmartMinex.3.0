using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал отсутствия связи с УРПТ-ИС-Т
    /// </summary>
    public class MobileRegDeviceOfflineJournal : Journal
    {
        /// <summary>
        /// Мобильное устройство регистрации
        /// </summary>
        [DisplayName("Мобильное устройство регистрации")]
        public virtual MobileRegDevice MobileRegDevice 
        { get; set; }

        /// <summary>
        /// Состояние связи
        /// </summary>
        [DisplayName("Состояние связи")]
        public virtual DeviceState DeviceState 
        { get; set; }
    }
}
