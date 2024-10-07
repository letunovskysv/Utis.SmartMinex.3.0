using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Срез журнала статусов АТО
    /// </summary>
    [DisplayName("Журнал статусов АТО")]
    [Description("Срез журнала статусов АТО")]
    public class MarkPointStatusRDimension : RDimensionBase
    {

        /// <summary>
        /// АТО
        /// </summary>
        [DisplayName("АТО")]
        public virtual MarkPoint MarkPoint { get; set; }
    }
}
