
namespace Utis.Minex.ProductionModel.Register.Value.Common
{
    #region Using
    
    using Utis.Minex.Common;

    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.MineSpace;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    /// <summary>
    /// Базовый объект значений журнала перемещения.
    /// </summary>
    [DisplayName("Значения регистра перемещения")]
    [Description("Базовый объект значений регистра перемещения")]
    public abstract class RMovementValueBase<T> : ROutValueBase<T> where T : RDimensionBase
    {
        /// <summary>
        /// Антенна.
        /// </summary>
        [DisplayName("Номер антенны устройства считывания")]
        public virtual int Antenna 
        { get; set; }

        /// <summary>
        /// Устройство считывания.
        /// </summary>
        [DisplayName("Устройство считывания")]
        [Description("Устройство считывания, на котором произошла регистрация")]
        public virtual DeviceWithRfid RfidDevice
        { get; set; }

        /// <summary>
        /// Выработка.
        /// </summary>
        [DisplayName("Выработка")]
        public virtual Working Working 
        { get; set; }

        /// <summary>
        /// Зона.
        /// </summary>
        [DisplayName("Зона")]
        [Description("Зона, в которой произошло событие регистрации")]
        public virtual Zone Zone 
        { get; set; }
    }
}