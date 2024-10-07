using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал зон ответственности участков
    /// </summary>
    [DisplayName("Журнал зон ответственности участков")]
    public class ZoneResponsibilityBindDivision : DateOutJournal
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division
        { get; set; }
        /// <summary>
        /// Зона ответственности
        /// </summary>
        [DisplayName("Зона ответственности")]
        public virtual ZoneResponsibility ZoneResponsibility
        { get; set; }
    }
}
