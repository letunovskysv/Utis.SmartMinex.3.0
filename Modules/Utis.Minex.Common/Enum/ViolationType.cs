using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип нарушения
    /// </summary>
    [DisplayName("Тип нарушения")]
    [Flags]
    public enum ViolationType : byte
    {
        Default = 0,

        /// <summary>
        /// Не было выдачи светильника
        /// </summary>
        [DisplayName("Нет выдачи светильника")]
        NoGiven = 1,

        /// <summary>
        /// Нет спуска в шахту
        /// </summary>
        [DisplayName("Нет спуска в шахту")]
        NoInShaft = 2,

        /// <summary>
        /// Нет подъёма из шахты
        /// </summary>
        [DisplayName("Нет подъёма из шахты")]
        NoOutShaft = 4,


        /// <summary>
        /// Нет сдачи светильника
        /// </summary>
        [DisplayName("Нет сдачи светильника")]
        NoReturn = 8,
    }
}
