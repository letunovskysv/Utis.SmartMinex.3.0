using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Journals
{
    public abstract class DateOutJournal : VersionObjectBase
    {
        /// <summary>
        /// Дата/время начала
        /// </summary>
        [DisplayName("Дата/время начала")]
        public virtual System.DateTime BeginDate
        { get; set; }

        /// <summary>
        /// Дата/время окончания
        /// </summary>
        [DisplayName("Дата/время окончания")]
        public virtual System.DateTime? EndDate
        { get; set; }
    }
}