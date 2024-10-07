
namespace Utis.Minex.ProductionModel.Register.Value.State
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.Register.Dimension.State;

        #endregion

    /// <summary>
    /// Журнал выдачи/сдачи устройств персоналу.
    /// </summary>
    [DisplayName("Журнал выдачи/сдачи приборов")]
    [Description("Значения регистра выдачи/сдачи индивидуальных устройств персоналу")]
    public class IndividualDeviceRValue : RValueBase<IndividualDeviceRDimension>
    {        
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person 
        { get; set; }
                
        /// <summary>
        /// Статус выдачи индивидуального устройства.
        /// </summary>
        [DisplayName("Статус")]
        [Description("Статус выдачи индивидуального устройства")]
        public virtual IndividualDeviceIssueState IndividualDeviceIssueState 
        { get; set; }
        
        /// <summary>
        /// Номер персональной карты.
        /// </summary>
        [DisplayName("Номер карты")]
        [Description("Номер карты")]
        public virtual byte[] CardNumber
        { get; set; }
    }
}