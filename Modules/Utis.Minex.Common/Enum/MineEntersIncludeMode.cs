using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Режим поиска входов в шахту (для каких записей искать)
    /// </summary>
    public enum MineEntersIncludeMode
    {
        /// <summary>
        /// Не искать входы
        /// </summary>
        None = 0,

        /// <summary>
        /// Только если последнее перемещение было в шахте
        /// </summary>
        OnlyForShaft = 1,

        /// <summary>
        /// Если последнее перемещение было в шахте или выход из шахты
        /// </summary>
        ForShaftAndOuts = 2
    }
}
