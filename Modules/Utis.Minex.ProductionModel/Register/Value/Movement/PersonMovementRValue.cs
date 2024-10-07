
namespace Utis.Minex.ProductionModel.Register.Value.Movement
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Register.Value.Common;
    using Utis.Minex.ProductionModel.Register.Dimension.Movement;
    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Журнал регистраций персонала.
    /// </summary>
    [DisplayName("Журнал регистраций персонала")]
    [Description("Значения регистра регистраций персонала")]
    public class PersonMovementRValue : RMovementValueBase<PersonMovementRDimension>
    {
        /// <summary>
        /// Тип операции персонала.
        /// </summary>
        [DisplayName("Операция")]
        [Description("Тип операции персонала")]
        public virtual PersonOperationType PersonOperationType 
        { get; set; }

        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        [Description("Сотрудник")]
        public virtual Person Person
        { get; set; }

        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Устройство")]
        public virtual IndividualDevice IndividualDevice
        { get; set; }
    }
}