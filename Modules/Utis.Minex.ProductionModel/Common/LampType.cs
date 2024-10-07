
namespace Utis.Minex.ProductionModel.Common
{
    using Utis.Minex.Common;

    /// <summary>
    /// Тип светильника.
    /// </summary>
    [DisplayName("Тип светильника")]
    public class LampType : CatalogBase
    {
        /// <summary>
        /// Производитель.
        /// </summary>
        [DisplayName("Производитель")]
        public virtual string Manufacturer 
        { get; set; }
    }
}