using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog
{
    [DisplayName("Причина простоя")]
    public class ReasonDowntime : CatalogBase
    {
        /// <summary>
        /// Идентификатор причины простоя
        /// </summary>
        [DisplayName("Идентификатор причины простоя")]
        public virtual int ReasonDowntimeId { get; set; }

        /// <summary>
        /// Тип простоя
        /// </summary>
        [DisplayName("Тип простоя")]
        public virtual DowntimeType DowntimeType { get; set; }
    }
}