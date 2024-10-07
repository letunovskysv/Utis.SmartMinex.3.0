
namespace Utis.Minex.ProductionModel.Register.Dimension.Bind
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Срез привязок карт к сотрудникам.
    /// </summary>
    [DisplayName("Срез привязок карт к сотрудникам")]
    public class PersonCardBindRDimension : RBindDimensionBase
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person 
        { get; set; }
    }
}