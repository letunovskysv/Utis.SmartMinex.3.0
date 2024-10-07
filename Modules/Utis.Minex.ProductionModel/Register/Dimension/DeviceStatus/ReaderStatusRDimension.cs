using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Считыватель
    /// </summary>
    [DisplayName("Журнал статусов считывателей")]
    [Description("Срез журнала статусов считывателей")]
    public class ReaderStatusRDimension : RDimensionBase
    {
        /// <summary>
        /// Считыватель
        /// </summary>
        [DisplayName("Считыватель")]
        public virtual Reader Reader { get; set; }
    }
}
