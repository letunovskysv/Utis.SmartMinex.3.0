using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Положение АТО
    /// </summary>    
    [DisplayName("Положение АТО")]
    public enum PositionMarkPoint : byte
    {
        ///<summary>
        /// Зафиксирована
        /// </summary>
        [DisplayName("Зафиксирована")]
        StandsStill = 0,

        ///<summary>
        /// В движении
        /// </summary>
        [DisplayName("В движении")]
        InMove = 1,

        ///<summary>
        /// Перемещена
        /// </summary>
        [DisplayName("Перемещена")]
        Moved = 2,

        ///<summary>
        /// Удалена
        /// </summary>
        [DisplayName("Удалена")]
        Removed = 3,
    }
}
