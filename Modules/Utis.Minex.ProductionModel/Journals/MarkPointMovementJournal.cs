using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал перемещения АТО
    /// </summary>
    [DisplayName("Журнал перемещения АТО")]
    public class MarkPointMovementJournal : DateOutJournal
    {
        /// <summary>
        /// АТО
        /// </summary>
        [DisplayName("АТО")]
        public virtual MarkPoint MarkPoint { get; set; }

        /// <summary>
        /// Типы размещения АТО
        /// </summary>
        [DisplayName("Типы размещения АТО")]
        public virtual MarkPointPlaceType PlaceType { get; set; }

        /// <summary>
        /// Выработки
        /// </summary>
        [DisplayName("Выработки")]
        public virtual string Workings { get; set; }
    }
}
