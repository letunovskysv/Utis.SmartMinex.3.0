namespace Utis.Minex.ProductionModel
{
    using System.Collections.Generic;
        using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Права доступа к отчетам.
    /// </summary>
    [DisplayName("Права доступа к отчетам")]
    [Description("Права доступа к отчетам")]
    [RegisterChanges(true)]
    public class ReportAccessRights : CatalogBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль")]
        [RegisterChangesOnCreate(true)]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Отчет.
        /// </summary>
        [DisplayName("Отчеты")]
        [Description("Отчеты")]
        [RegisterChangesOnCreate(true)]
        public virtual IEnumerable<int> Reports
        { get; set; }
    }
}