using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus;

namespace Utis.Minex.ProductionModel.Register.Value.DeviceStatus
{
    /// <summary>
    /// Журнал статусов считывателей
    /// </summary>
    [DisplayName("Журнал статусов считывателей")]
    [Description("Журнал статусов считывателей")]
    public class ReaderStatusRValue : RValueBase<ReaderStatusRDimension>
    {

        /// <summary>
        /// Статус
        /// </summary>
        [DisplayName("Статус")]
        public virtual Minex.Common.Enum.DeviceStatus Status { get; set; }
    }
}
