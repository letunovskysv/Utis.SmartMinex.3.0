using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Graphical
{
    /// <summary>
    /// Подложка схемы ИМР
    /// </summary>
    [DisplayName("Подложка схемы ИМР")]
    public class ShemeBackgroundImage : VersionObjectBase
    {
        /// <summary>
        /// Данные изображения
        /// </summary>
        [DisplayName("Данные изображения")]
        public virtual byte[] Data
        { get; set; }
    }
}