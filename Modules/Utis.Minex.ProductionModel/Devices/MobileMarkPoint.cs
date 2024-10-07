
namespace Utis.Minex.ProductionModel.Devices
{
    using Utis.Minex.Common;

    /// <summary>
    /// Справочник мобильных автономных точек отметки.
    /// </summary>
    [DisplayName("Справочник мобильных автономных точек отметки")]
    public class MobileMarkPoint : DeviceWithRfid
    {
        /// <summary>
        /// Серийный номер.
        /// </summary>
        [DisplayName("Серийный")]
        [Description("Серийный номер")]
        public virtual int? Serial
        { get; set; }

        /// <summary>
        /// Версия прошивки.
        /// </summary>
        [DisplayName("Прошивка")]
        [Description("Версия прошивки")]
        public virtual string FirmwareVersion
        { get; set; }
    }
}
