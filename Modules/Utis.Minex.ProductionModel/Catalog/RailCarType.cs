using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog
{
    /// <summary>
    /// Типы вагонов.
    /// </summary>
    [DisplayName("Типы вагонов")]
    public class RailCarType: NamedObjectBase
    {
        /// <summary>
        /// Объём вагона.
        /// </summary>
        [DisplayName("Объём вагона")]
        public virtual double Volume { get; set; }
    }
}
