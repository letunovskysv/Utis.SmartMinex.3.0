
namespace Utis.Minex.ProductionModel.Register.Value.Bind
{
    #region Using

    using Utis.Minex.Common;

    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.Register.Dimension.Bind;

    #endregion

    /// <summary>
    /// Журнал постоянных привязок индивидуальных устройств.
    /// </summary>
    [DisplayName("Журнал постоянных привязок индивидуальных устройств")]
    public class IndividualDeviceBindRValue : RBindValueBase<IndividualDeviceBindRDimension>
    {        
        /// <summary>
        /// Персона.
        /// </summary>
        [DisplayName("Персона")]
        [Description("Сотрудник или гость")]
        public virtual Person Person 
        { get; set; }
    }
}