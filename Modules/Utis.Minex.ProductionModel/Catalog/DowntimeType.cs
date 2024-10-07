using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog
{
    [DisplayName("Тип простоя транспорта")]
    public class DowntimeType : CatalogBase
    {
        /// <summary>
        /// Идентификатор типа простоя
        /// </summary>
        [DisplayName("Идентификатор типа простоя")]
        public virtual int DowntimeTypeId { get; set; }
    }
}