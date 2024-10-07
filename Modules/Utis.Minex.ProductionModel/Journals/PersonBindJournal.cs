using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Journals
{
    public abstract class PersonBindJournal : DateOutJournal
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public Person Person 
        { get; set; }
    }
}
