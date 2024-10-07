
namespace Utis.Minex.ProductionModel.Register.Dimension.State
{
    #region Using
    
    using Utis.Minex.Common;
    
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Срез регистра выдачи/сдачи индивидуальных устройств персоналу.
    /// </summary>
    [DisplayName("Журнал выдачи/сдачи приборов")]
    [Description("Срез регистра выдачи/сдачи индивидуальных устройств персоналу")]
    public class IndividualDeviceRDimension : RDimensionBase
    {   
        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Устройство")]
        [Description("Индивидуальное устройство")]
        public virtual IndividualDevice IndividualDevice 
        { get; set; }
    }
}