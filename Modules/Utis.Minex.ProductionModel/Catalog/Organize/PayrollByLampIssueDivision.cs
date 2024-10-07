using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    /// <summary>
    /// Справочник организационной структуры подразделений предприятия.
    /// </summary>
    [DisplayName("Подразделения с условиями труда, приравненными к подземным условиям")]
    [Description("Подразделения с условиями труда, приравненными к подземным условиям")]
    public class PayrollByLampIssueDivision : CatalogBase
    {
        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division
        { get; set; }
    }
}
