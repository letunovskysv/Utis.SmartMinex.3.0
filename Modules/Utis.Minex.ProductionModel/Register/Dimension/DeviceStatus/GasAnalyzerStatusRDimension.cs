using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Срез журнала статусов газоанализаторов
    /// </summary>
    [DisplayName("Журнал статусов газоанализаторов")]
    [Description("Срез журнала статусов газоанализаторов")]
    public class GasAnalyzerStatusRDimension : RDimensionBase
    {

        /// <summary>
        /// Газоанализатор
        /// </summary>
        [DisplayName("Газоанализатор")]
        public virtual GasAnalyzer GasAnalyzer { get; set; }
    }
}
