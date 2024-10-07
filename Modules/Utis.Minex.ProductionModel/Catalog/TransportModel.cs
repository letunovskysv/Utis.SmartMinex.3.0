
namespace Utis.Minex.ProductionModel.Catalog
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Справочник моделей транспорта.
    /// </summary>
    [DisplayName("Справочник моделей транспорта")]
    public class TransportModel : CatalogBase
    {
        /// <summary>
        /// Идентификатор модели.
        /// </summary>
        [DisplayName("Идентификатор модели")]
        public virtual int TransportModelType
        { get; set; }

        /// <summary>
        /// Краткое обозначение.
        /// </summary>
        [DisplayName("Краткое обозначение")]
        public virtual string ShortName 
        { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        [DisplayName("Производитель")]
        public virtual Vendor Vendor
        { get; set; }

        /// <summary>
        /// Тип транспорта.
        /// </summary>
        [DisplayName("Тип транспорта")]
        public virtual TransportType TransportType
        { get; set; }
    }
}