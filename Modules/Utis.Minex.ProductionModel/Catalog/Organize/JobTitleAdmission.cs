
namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Нормы действия мероприятий допуска в шахту.
    /// </summary>
    [DisplayName("Допуски")]
    [Description("Нормы действия мероприятий допуска в шахту")]
    public class JobTitleAdmission : CatalogBase
    {
        /// <summary>
        /// Должность.
        /// </summary>
        [UniqueKey]
        [DisplayName("Должность")]
        public virtual JobTitle JobTitle
        { get; set; }

        /// <summary>
        /// Период действия допуска для данной должности.
        /// </summary>
        [DisplayName("Период")]
        [Description("Период действия допуска для данной должности")]
        public virtual Duration Duration 
        { get; set; }

        /// <summary>
        /// Тип мероприятия допуска.
        /// </summary>
        [UniqueKey]
        [DisplayName("Допуск")]
        [Description("Тип мероприятия допуска")]
        public virtual AdmissionType AdmissionType 
        { get; set; }
    }
}