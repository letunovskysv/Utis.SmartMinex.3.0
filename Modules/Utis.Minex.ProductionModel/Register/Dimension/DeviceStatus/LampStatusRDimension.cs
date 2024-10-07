using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Срез журнала статусов светильников
    /// </summary>
    [DisplayName("Журнал статусов светильников")]
    [Description("Срез журнала статусов светильников")]
    public class LampStatusRDimension : RDimensionBase
    {

        /// <summary>
        /// Светильник
        /// </summary>
        [DisplayName("Светильник")]
        public virtual Lamp Lamp { get; set; }
    }
}
