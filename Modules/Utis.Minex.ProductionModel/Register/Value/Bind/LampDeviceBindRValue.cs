namespace Utis.Minex.ProductionModel.Register.Value.Bind
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Register.Dimension.Bind;

        #endregion

    /// <summary>
    /// Значение привязок радиоблоков и светильников.
    /// </summary>
    [DisplayName("Значение привязок радиоблоков и светильников")]
    public class LampDeviceBindRValue : RBindValueBase<LampDeviceBindRDimension>
    {
        /// <summary>
        /// Привязывыаемое устройство.
        /// </summary>
        [DisplayName("Привязываемое устройство")]
        public virtual Device Device 
        { get; set; }
    }
}