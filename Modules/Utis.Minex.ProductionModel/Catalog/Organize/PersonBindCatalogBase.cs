using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    /// <summary>
    /// Каталог с привязкой к сотруднику
    /// </summary>
    public abstract class PersonBindCatalogBase : CatalogBase
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person
        { get; set; }
    }
}
