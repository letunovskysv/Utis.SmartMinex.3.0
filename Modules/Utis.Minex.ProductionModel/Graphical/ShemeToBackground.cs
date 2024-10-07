using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Graphical
{
    /// <summary>
    /// Связь подложки с схемой
    /// </summary>
    [DisplayName("Связь подложки с схемой")]
    public class ShemeToBackground : VersionObjectBase
    {
        /// <summary>
        /// Схема
        /// </summary>
        [DisplayName("Схема")]
        public virtual MIMSheme MIMSheme { get; set; }

        /// <summary>
        /// Подложка схемы ИМР
        /// </summary>
        [DisplayName("Подложка схемы ИМР")]
        public virtual ShemeBackgroundImage ShemeBackgroundImage { get; set; }
    }
}