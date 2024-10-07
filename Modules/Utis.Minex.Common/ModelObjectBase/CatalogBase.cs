using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект справочника.
    /// </summary>
    [DisplayName("Базовый объект справочника")]
    public abstract class CatalogBase : NamedObjectBase, ICatalog
    {
        /// <summary>
        /// Инициализирует базовый объект справочника.
        /// </summary>
        public CatalogBase()
        {
            return;
        }

        /// <summary>
        /// Инициализирует базовый объект справочника.
        /// </summary>
        /// <param name="name">Наименование.</param>
        public CatalogBase(string name) : base(name)
        {
            return;
        }
    }
}