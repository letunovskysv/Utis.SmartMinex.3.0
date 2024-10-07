using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый класс журналов
    /// </summary>
    public abstract class Journal : VersionObjectBase, IJournal
    {
        /// <summary>
        /// Дата/время записи.
        /// </summary>
        [DisplayName("Дата/время записи")]
        public virtual DateTime DateTime
        { get; set; }
    }

    /// <summary>
    /// Журнал с закрытием записей
    /// </summary>
    public abstract class JournalClose : Journal, IJournalClose 
    {
        /// <summary>
        /// Дата/время закрытия записи.
        /// </summary>
        [DisplayName("Дата/время закрытия записи")]
        public virtual DateTime? DateClose
        { get; set; }
    }
}