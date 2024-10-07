using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Journals;
using Utis.Minex.ProductionModel.MineSpace.MineModel;

namespace Utis.Minex.ProductionModel.Catalog
{
    /// <summary>
    /// Размещение АТО
    /// </summary>
    [DisplayName("Размещение АТО")]
    public class MarkPointPlace : VersionObjectBase
    {
        /// <summary>
        /// Журнал перемещения АТО
        /// </summary>
        [DisplayName("Журнал перемещения АТО")]
        public virtual MarkPointMovementJournal MarkPointMovementJournal { get; set; }

        /// <summary>
        /// Справочник горных выработок
        /// </summary>
        [DisplayName("Справочник горных выработок")]
        public virtual Working Working { get; set; }
    }
}
