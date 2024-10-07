
namespace Utis.Minex.ProductionModel.Register.Dimension
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

        #endregion

    /// <summary>
    /// Журнал привязки технологических объектов к орг. структуре.
    /// </summary>
    [DisplayName("Журнал привязки технологических объектов к орг. структуре")]
    public class MineDivisionRDimension : RDimensionBase
    {
        /// <summary>
        /// Подраздление.
        /// </summary>
        [DisplayName("Подраздление")]
        public virtual Division Division 
        { get; set; }
    }
}