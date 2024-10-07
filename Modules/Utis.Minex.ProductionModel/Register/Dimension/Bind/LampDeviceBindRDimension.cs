
namespace Utis.Minex.ProductionModel.Register.Dimension.Bind
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Срез привязок светильников и радиоблоков.
    /// </summary>
    [DisplayName("Срез привязок светильников и радиоблоков")]
    public class LampDeviceBindRDimension : RBindDimensionBase
    {
        /// <summary>
        /// Светильник.
        /// </summary>
        [DisplayName("Светильник")]
        public virtual Lamp Lamp 
        { get; set; }
    }
}