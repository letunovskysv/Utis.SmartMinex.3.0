
namespace Utis.Minex.ProductionModel.Register.Dimension
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Срез регистра команд на пейджер.
    /// </summary>
    [DisplayName("Срез регистра команд на пейджер")]
    public class PagerCommandRDimension : RDimensionBase
    {
        /// <summary>
        /// Пейджер.
        /// </summary>
        [DisplayName("Пейджер")]
        public virtual Pager Pager 
        { get; set; }
    }
}