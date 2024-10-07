using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.MineSpace
{
    /// <summary>
    /// Справочник переходных зон (в/из смежных рудников)
    /// </summary>
    [DisplayName("Справочник переходных зон")]
    public class TransitionZone : CatalogBase
    {
        /// <summary>
        /// Смежный рудник, к которому относится зона
        /// </summary>
        [DisplayName("Смежный рудник")]
        [Description("Смежный рудник, к которому относится зона")]
        public virtual JoinedMine JoinedMine { get; set; }

        /// <summary>
        /// Зона
        /// </summary>
        [DisplayName("Зона")]
        [Description("Зона (из схемы ИМР)")]
        public virtual Zone Zone { get; set; }
    }
}
