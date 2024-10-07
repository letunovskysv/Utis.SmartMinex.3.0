
namespace Utis.Minex.ProductionModel.Devices
{
    using Utis.Minex.Common;

    /// <summary>
    /// Устройство с радиометкой.
    /// </summary>
    [DisplayName("Устройство с радиометкой")]
    public abstract class DeviceWithRfid : Device, IDeviceWithRfid
    {
        /// <summary>
        /// Метка RFID.
        /// </summary>
        [DisplayName("Метка RFID")]
        [Description("Метка RFID")]
        public virtual RfidDevice RfidDevice 
        { get; set; }

        IRfidDevice IDeviceWithRfid.RfidDevice 
        { get => RfidDevice; set => RfidDevice = value as RfidDevice; }
    }
}