using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.MineSpace.MineModel
{
    using Utis.Minex.Common;

    /// <summary>
    /// Рудник.
    /// </summary>
    [DisplayName("Рудник, шахта")]
    public class Mine : MineBase
    {
        /// <summary>
        /// Горизонты рудника.
        /// </summary>
        [DisplayName("Горизонты рудника")]
        public virtual IList<Horizon> Horizons 
        { get; set; } = new List<Horizon>();
    }
}