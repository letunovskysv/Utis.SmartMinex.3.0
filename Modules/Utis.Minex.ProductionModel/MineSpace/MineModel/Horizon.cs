
namespace Utis.Minex.ProductionModel.MineSpace.MineModel
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Справочник горизонтов.
    /// </summary>
    [DisplayName("Справочник горизонтов")]
    public class Horizon : MineBase, IHorizon
    {
        /// <summary>
        /// Тип горизонта.
        /// </summary>
        [DisplayName("Тип горизонта")]
        public virtual HorizonType HorizonType 
        { get; set; }
               
        /// <summary>
        /// Признак нахождения под землей.
        /// </summary>
        [DisplayName("Признак нахождения под землей")]
        public virtual bool IsMine 
        { get; set; }
                
        /// <summary>
        /// Уровень.
        /// </summary>
        [DisplayName("Уровень")]
        public virtual int? Level
        { get; set; }
    }
}