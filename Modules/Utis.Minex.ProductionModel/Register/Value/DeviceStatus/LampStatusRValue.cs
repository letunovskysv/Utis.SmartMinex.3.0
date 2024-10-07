using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов светильников
    /// </summary>
    [DisplayName("Журнал статусов светильников")]
    [Description("Журнал статусов светильников")]
    public class LampStatusRValue : RValueBase<LampStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.DeviceStatus Status { get; set; }
    }
}
