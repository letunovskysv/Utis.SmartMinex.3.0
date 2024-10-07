using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов АТО
    /// </summary>
    [DisplayName("Журнал статусов АТО")]
    [Description("Журнал статусов АТО")]
    public class MarkPointStatusRValue : RValueBase<MarkPointStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.DeviceStatus Status { get; set; }
    }
}
