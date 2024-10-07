using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.Journals;

namespace Utis.Minex.ProductionModel.Register.Dimension.Movement
{
    public abstract class MovementJournal : DateOutJournal
    {
        /// <summary>
        /// Устройство.
        /// </summary>
        [DisplayName("Устройство с меткой")]
        [Description("Устройство с меткой")]
        public virtual DeviceWithRfid Device
        { get; set; }
    }
}