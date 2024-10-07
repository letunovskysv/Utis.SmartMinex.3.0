
namespace Utis.Minex.ProductionModel.MineSpace
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    /// <summary>
    /// Справочник зон.
    /// </summary>
    [DisplayName("Справочник зон")]
    public class Zone : MineBase, IZone
    {        
        /// <summary>
        /// Описание зоны.
        /// </summary>
        [DisplayName("Описание")]
        [Description("Описание зоны")]
        public virtual string Description
        { get; set; }
                
        /// <summary>
        /// Признак локальной зоны.
        /// </summary>
        [DisplayName("Локальная")]
        [Description("Признак локальной зоны")]
        public virtual bool? IsLocal
        { get; set; }
                
        /// <summary>
        /// Признак нахождения зоны внутри участка.
        /// </summary>
        [DisplayName("Внутри участка")]
        [Description("Признак нахождения зоны внутри участка")]
        public virtual bool? InsideArea 
        { get; set; }
                
        /// <summary>
        /// Принадлежность к зоне родителю.
        /// </summary>
        [DisplayName("Родитель")]
        [Description("Принадлежность к зоне родителю")]
        public virtual Zone ParentZone 
        { get; set; }

        /// <summary>
        /// Признак зоны зонального позиционирования
        /// </summary>
        [DisplayName("Признак зоны зонального позиционирования")]
        [Description("Признак зоны зонального позиционирования")]
        public virtual bool IsZonalPositioning
        { get; set; }

        IZone IZone.ParentZone 
        { 
            get => ParentZone; 
            set => ParentZone = value as Zone;
        }
    }
}