
namespace Utis.Minex.ProductionModel.Catalog
{
    using Utis.Minex.Common;

    /// <summary>
    /// Соответствие импортированных справочников внутренним (СПГТ 41).
    /// </summary>
    [DisplayName("Кросскаталог")]
    public class CrossCatalog : CatalogBase
    {
        /// <summary>
        /// Наименование сущности в ПТК ГД.
        /// </summary>
        [DisplayName("Наименование сущности")]
        public virtual string Entity 
        { get; set; }

        /// <summary>
        /// Внешний идентификатор.
        /// </summary>
        [DisplayName("Внешний идентификатор")]
        public virtual long ExternalId 
        { get; set; }

        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        [DisplayName("Внутренний идентификатор")]
        public virtual long InternalId 
        { get; set; }

        /// <summary>
        /// Внешняя система.
        /// </summary>
        [DisplayName("Внешняя система")]
        public virtual ExternalSystem ExternalSystem 
        { get; set; }
    }

    /// <summary>
    /// Соответствие импортированных справочников внутренним (ExternalSystem).
    /// </summary>
    [DisplayName("Кросскаталог")]
    public class CrossCatalogEx : CatalogBase
    {
        /// <summary>
        /// Наименование сущности в ПТК ГД.
        /// </summary>
        [DisplayName("Наименование сущности")]
        public virtual string Entity 
        { get; set; }

        /// <summary>
        /// Внешний идентификатор.
        /// </summary>
        [DisplayName("Внешний идентификатор")]
        public virtual long ExternalId 
        { get; set; }

        /// <summary>
        /// Внешний строковый идентификатор (Guid).
        /// </summary>
        [DisplayName("Внешний Guid")]
        public virtual string ExternalGuid
        { get; set; }

        /// <summary>
        /// Внешний строковый идентификатор (Guid).
        /// </summary>
        [DisplayName("Внешний Guid перенаправления")]
        public virtual string RedirectExternalGuid
        { get; set; }

        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        [DisplayName("Внутренний идентификатор")]
        public virtual long InternalId 
        { get; set; }

        /// <summary>
        /// Внешняя система.
        /// </summary>
        [DisplayName("Внешняя система")]
        public virtual ExternalSystem ExternalSystem 
        { get; set; }
    }
}