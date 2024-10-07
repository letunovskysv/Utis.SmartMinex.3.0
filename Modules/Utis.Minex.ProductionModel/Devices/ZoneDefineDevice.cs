
namespace Utis.Minex.ProductionModel.Devices
{
    using System.ComponentModel;
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;
    using DescriptionAttribute = Minex.Common.DescriptionAttribute;
    using DisplayNameAttribute = Minex.Common.DisplayNameAttribute;

        #endregion

    /// <summary>
    /// Устройство, определяющее границы зоны.
    /// </summary>
    [DisplayName("Устройство, определяющее границы зоны")]
    public abstract class ZoneDefineDevice : DeviceWithRfid, IZoneDefineDevice
    {
        /// <summary>
        /// Территориальная принадлежность.
        /// </summary>
        [DisplayName("Размещение")]
        [Description("Территориальная принадлежность")]
        [ReadOnly(true)]
        public virtual Horizon Horizon 
        { get; set; }

        IHorizon IZoneDefineDevice.Horizon 
        { get => Horizon; set => Horizon = value as Horizon; }
    }
}