
namespace Utis.Minex.ProductionModel.Register.Dimension.Bind
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Журнал привязок индивидуальных устройств и персонала.
    /// </summary>
    [DisplayName("Журнал определения индивидуальных устройств")]
    [Description("Журнал привязок индивидуальных устройств и персонала")]
    public class IndividualDeviceBindRDimension : RBindDimensionBase
    {        
        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Индивидуальное устройство")]
        public virtual IndividualDevice IndividualDevice 
        { get; set; }
    }
}