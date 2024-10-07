
namespace Utis.Minex.ProductionModel.MineSpace.MineModel
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

        #endregion

    /// <summary>
    /// Справочник горных выработок.
    /// </summary>
    [DisplayName("Выработки")]
    [Description("Справочник горных выработок")]
    public class Working : MineBase
    {
        /// <summary>
        /// Код типа горной выработки.
        /// </summary>
        [DisplayName("Тип горной выработки")]
        [Description("Код типа горной выработки")]
        public virtual MineType MineType 
        { get; set; }

        /// <summary>
        /// Дата/время начала.
        /// </summary>
        [DisplayName("Дата/время начала")]
        public virtual System.DateTime BeginDate
        { get; set; }

        /// <summary>
        /// Дата/время окончания.
        /// </summary>
        [DisplayName("Дата/время окончания")]
        public virtual System.DateTime? EndDate
        { get; set; }
    }
}