
namespace Utis.Minex.ProductionModel.Register.Value
{
    #region Using
    
    using Utis.Minex.Common;

    using Utis.Minex.ProductionModel.Register.Dimension;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    /// <summary>
    /// Журнал привязки технологических объектов к орг. структуре.
    /// </summary>
    [DisplayName("Журнал привязки технологических объектов к орг. структуре")]
    public class MineDivisionRValue : RValueBase<MineDivisionRDimension>
    {
        /// <summary>
        /// Рудник.
        /// </summary>
        [DisplayName("Рудник")]
        public virtual MineBase Mine 
        { get; set; }
    }
}