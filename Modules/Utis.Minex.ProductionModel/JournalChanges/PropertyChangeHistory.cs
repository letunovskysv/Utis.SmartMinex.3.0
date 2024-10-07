using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.JournalChanges
{
    /// <summary>
    /// Запись об изменении данных
    /// </summary>
    [DisplayName("Запись об изменении данных")]
    public class PropertyChangeHistory : VersionObjectBase
    {
        /// <summary>
        /// Имя поля данных
        /// </summary>
        [DisplayName("Запись в журнале изменений")]
        public virtual JournalChangeRecord JournalChangeRecord { get; set; }
        /// <summary>
        /// Имя поля данных
        /// </summary>
        [DisplayName("Имя поля данных")]
        public virtual string PropertyName { get; set; }

        /// <summary>
        /// Тип поля данных
        /// </summary>
        [DisplayName("Тип поля данных")]
        public virtual string PropertyType { get; set; }

        /// <summary>
        /// Старое значение
        /// </summary>
        [DisplayName("Старое значение")]
        public virtual string OldValue { get; set; }

        /// <summary>
        /// Новое значение
        /// </summary>
        [DisplayName("Новое значение")]
        public virtual string NewValue { get; set; }
    }
}
