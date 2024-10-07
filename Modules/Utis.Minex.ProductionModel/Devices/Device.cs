namespace Utis.Minex.ProductionModel.Devices
{    
    using Utis.Minex.Common;

    /// <summary>
    /// Устройство инфраструктуры позиционирования.
    /// </summary>
    [DisplayName("Устройство инфраструктуры позиционирования")]
    public abstract class Device : CatalogBase, IDevice
    {        
        /// <summary>
        /// Заводской номер.
        /// (Не использовать термин "Серийный номер" - везде печатается "Заводской номер").
        /// </summary>
        [DisplayName("Заводской номер")]
        public virtual long SerialNumber 
        { get; set; }
    }
}