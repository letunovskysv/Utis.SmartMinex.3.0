using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Graphical
{
    public class MIMShemeBranch : NamedObjectBase
    {
        /// <summary>
        /// Тип ветки
        /// </summary>
        [DisplayName("Тип ветки")]
        public virtual BranchType BranchType { get; set; }

        /// <summary>
        /// Коментарий
        /// </summary>
        [DisplayName("Коментарий")]
        public virtual string Comment { get; set; }
    }
}