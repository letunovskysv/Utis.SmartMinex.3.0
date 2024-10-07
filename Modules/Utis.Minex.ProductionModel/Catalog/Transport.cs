using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Catalog
{
    /// <summary>
    /// Транспорт.
    /// </summary>
    [DisplayName("Транспорт")]
    public class Transport : CatalogBase
    {
        /// <summary>
        /// Краткое обозначение.
        /// </summary>
        [DisplayName("Краткое обозначение")]
        public virtual string ShortName 
        { get; set; }

        /// <summary>
        /// Модель транспорта.
        /// </summary>
        [DisplayName("Модель транспорта")]
        public virtual TransportModel TransportModel 
        { get; set; }
        
        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division 
        { get; set; }

        /// <summary>
        /// Подразделение регистрации.
        /// </summary>
        [DisplayName("Подразделение регистрации")]
        public virtual Division LocationDivision
        { get; set; }

        /// <summary>
        /// Инвентарный номер.
        /// </summary>
        [DisplayName("Инвентарный номер")]
        public virtual string InvNumber 
        { get; set; }

        /// <summary>
        /// Серийный номер.
        /// </summary>
        [DisplayName("Серийный номер")]
        public virtual string SerNumber 
        { get; set; }

        /// <summary>
        /// Внутренний номер.
        /// </summary>
        [DisplayName("Внутренний номер")]
        public virtual string Number 
        { get; set; }

        /// <summary>
        /// Идентификатор транспорта из SAP.
        /// </summary>
        [DisplayName("Идентификатор транспорта из SAP")]
        public virtual long SapTransportId
        { get; set; }

        
    }
}