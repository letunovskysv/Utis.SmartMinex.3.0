using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов газоанализаторов
    /// </summary>
    [DisplayName("Журнал статусов газоанализаторов")]
    [Description("Журнал статусов газоанализаторов")]
    public class GasAnalyzerStatusRValue : RValueBase<GasAnalyzerStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.VerifiableDeviceStatus Status { get; set; }
    }
}
