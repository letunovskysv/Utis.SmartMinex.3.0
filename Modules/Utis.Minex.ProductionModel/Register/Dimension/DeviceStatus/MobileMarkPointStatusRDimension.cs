using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Срез журнала статусов мобильных АТО
    /// </summary>
    [DisplayName("Журнал статусов мобильных АТО")]
    [Description("Срез журнала статусов мобильных АТО")]
    public class MobileMarkPointStatusRDimension : RDimensionBase
    {

        /// <summary>
        /// Мобильная АТО
        /// </summary>
        [DisplayName("Мобильная АТО")]
        public virtual MobileMarkPoint MobileMarkPoint { get; set; }
    }
}
