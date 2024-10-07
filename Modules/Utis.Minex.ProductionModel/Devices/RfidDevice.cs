
namespace Utis.Minex.ProductionModel.Devices
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Метка RFID.
    /// </summary>
    [DisplayName("Метка RFID устройства")]
    public class RfidDevice : CatalogBase, IRfidDevice
    {
        /// <summary>
        /// ПРОГРАММИСТ ВНИМАНИЕ конструктор только для hibernate не использовать в коде
        /// </summary>
        public RfidDevice()//только для hibernate не использовать в коде
        {
        }

        /// <summary>
        /// Метка RFID.
        /// </summary>
        /// <param name="rfid">Идентификатор метки.</param>
        /// <param name="rfidDeviceType">Тип метки.</param>
        public RfidDevice(int rfid, RfidDeviceType rfidDeviceType)
        {
            Rfid           = rfid;
            RfidDeviceType = rfidDeviceType;
            Name           = $"{rfidDeviceType.GetEnumDisplayName()} {rfid}";
        }

        /// <summary>
        /// Метка RFID.
        /// </summary>
        [UniqueKey("Rfid")]
        [DisplayName("Метка RFID")]
        public virtual int Rfid 
        { get; set; }

        /// <summary>
        /// Тип метки (класс устройства).
        /// </summary>
        [UniqueKey("Rfid")]
        [DisplayName("Тип метки (класс устройства)")]
        public virtual RfidDeviceType RfidDeviceType 
        { get; set; }
    }
}