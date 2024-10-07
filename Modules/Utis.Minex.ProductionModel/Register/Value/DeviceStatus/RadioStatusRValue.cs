using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов радиостанций
    /// </summary>
    [DisplayName("Журнал статусов радиостанций")]
    [Description("Журнал статусов радиостанций")]
    public class RadioStatusRValue : RValueBase<RadioStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.DeviceStatus Status { get; set; }
    }
}
