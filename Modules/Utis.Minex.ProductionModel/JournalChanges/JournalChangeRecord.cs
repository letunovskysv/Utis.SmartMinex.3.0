using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.JournalChanges
{
    /// <summary>
    /// Запись об изменении данных
    /// </summary>
    [DisplayName("Запись об изменении объекта")]
    public class JournalChangeRecord : VersionObjectBase
    {
        /// <summary>
        /// Измененные данные объекта
        /// </summary>
        [DisplayName("Измененные данные")]
        public virtual ISet<PropertyChangeHistory> ChangedProperties
        { get; set; } = new HashSet<PropertyChangeHistory>();

        /// <summary>
        /// Новая запись
        /// </summary>
        [DisplayName("Логин")]
        public virtual string UserName { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [DisplayName("ФИО")]
        public virtual string FullName { get; set; }

        /// <summary>
        /// Тип изменений
        /// </summary>
        [DisplayName("Тип изменений")]
        public virtual EntityActionType EntityActionType
        { get; set; }

        /// <summary>
        /// Измененный объект
        /// </summary>
        [DisplayName("Измененный объект")]
        public virtual ObjectBase ChangedObject
        { get; set; }

        /// <summary>
        /// Измененный объект
        /// </summary>
        [DisplayName("Тип измененного объекта")]
        public virtual string ChangedObjectType
        { get; set; }

        
    }
}
