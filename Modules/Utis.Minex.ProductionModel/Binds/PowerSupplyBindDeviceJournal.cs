using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Binds
{
    /// <summary>
    /// Устройства подключённые к блоку питания
    /// </summary>
    public class PowerSupplyBindDeviceJournal : JournalClose, IPowerSupplyBindDeviceJournal
    {
        /// <summary>
        /// Устройство
        /// </summary>
        [DisplayName("Устройство")]
        public virtual Device Device 
        { get; set; }

        /// <summary>
        /// Блок питания
        /// </summary>
        [DisplayName("Блок питания")]
        public virtual Reader Reader
        { get; set; }

        IDevice IPowerSupplyBindDeviceJournal.Device { get => Device; set => Device = value as Device; }
        IReader IPowerSupplyBindDeviceJournal.Reader { get => Reader; set => Reader = value as Reader; }
    }
}
