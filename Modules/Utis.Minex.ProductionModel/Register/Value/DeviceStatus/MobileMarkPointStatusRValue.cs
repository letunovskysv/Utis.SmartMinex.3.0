using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов мобильных АТО
    /// </summary>
    [DisplayName("Журнал статусов мобильных АТО")]
    [Description("Журнал статусов мобильных АТО")]
    public class MobileMarkPointStatusRValue : RValueBase<MobileMarkPointStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.DeviceStatus Status { get; set; }
    }
}
