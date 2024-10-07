
namespace Utis.Minex.ProductionModel.MineSpace.MineModel
{
    #region Using
    
    using Utis.Minex.Common;
    
    using Utis.Minex.ProductionModel.Catalog.Organize;

        #endregion

    /// <summary>
    /// Базовый класс технологического объекта (рудник, шахта, горизонт, выработка).
    /// </summary>
    [DisplayName("Базовый класс модели рудника")]
    public abstract class MineBase : CatalogBase, IMineBase
    {
        /// <summary>
        /// Родитель элемента технологической модели.
        /// </summary>
        [DisplayName("Родитель элемента технологической модели")]
        public virtual MineBase Parent 
        { get; set; }

        /// <summary>
        /// Подразделение, за которым закреплён технологический объект.
        /// </summary>
        [DisplayName("Подразделение, за которым закреплён технологический объект")]
        public virtual Division Division 
        { get; set; }

        IMineBase IMineBase.Parent
        { get => Parent; set => Parent = value as MineBase; }
        IDivision IMineBase.Division 
        { get => Division; set => Division = value as Division; }
    }
}