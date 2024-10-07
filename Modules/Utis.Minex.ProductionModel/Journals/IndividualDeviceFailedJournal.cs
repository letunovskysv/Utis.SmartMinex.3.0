
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Журнал неуспешной выдачи/сдачи светильника.
    /// </summary>
    [DisplayName("Журнал неуспешной выдачи/сдачи светильника")]
    public class IndividualDeviceFailedJournal : Journal
    {
        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Устройство")]
        [Description("Индивидуальное устройство")]
        public virtual IndividualDevice IndividualDevice
        { get; set; }

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

        /// <summary>
        /// Причина
        /// </summary>
        [DisplayName("Причина")]
        [Description("Причина")]
        public virtual string Reason
        { get; set; }
    }
}
