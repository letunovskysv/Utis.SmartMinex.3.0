using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.MineSpace;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    /// <summary>
    /// Справочник организационной структуры смежных рудников.
    /// </summary>
    [DisplayName("ОргСтруктура")]
    [Description("Справочник организационной структуры смежных рудников")]
    public class JoinedMine : CatalogBase
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        [DisplayName("Подразделение")]
        [Description("Подразделение, к которому будут принадлежать все метки, входящие в диапазон")]
        public virtual Division Division { get; set; }

        /// <summary>
        /// Пул номеров меток (нижняя граница)
        /// </summary>
        [DisplayName("Метки № (от)")]
        [Description("Пул номеров меток (нижняя граница)")]
        public virtual int LabelsFrom { get; set; } = 0;

        /// <summary>
        /// Пул номеров меток (верхняя граница)
        /// </summary>
        [DisplayName("Метки № (до)")]
        [Description("Пул номеров меток (верхняя граница)")]
        public virtual int LabelsTo { get; set; } = 0;
    }
}
