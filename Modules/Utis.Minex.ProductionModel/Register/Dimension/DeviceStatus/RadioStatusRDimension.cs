using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension.DeviceStatus
{
    /// <summary>
    /// Журнал статусов радиостанций
    /// </summary>
    [DisplayName("Журнал статусов радиостанций")]
    [Description("Срез журнала статусов радиостанций")]
    public class RadioStatusRDimension : RDimensionBase
    {
        /// <summary>
        /// Радиостанция
        /// </summary>
        [DisplayName("Радиостанция")]
        public virtual Radio Radio { get; set; }
    }
}
