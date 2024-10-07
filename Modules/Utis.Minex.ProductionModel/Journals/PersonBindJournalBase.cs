using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Каталог с привязкой к сотруднику
    /// </summary>
    public class PersonBindJournalBase : JournalClose, IPersonBindJournalBase
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person
        { get; set; }

        public virtual PersonBindType PersonBindType { get; set; }

        IPerson IPersonBindJournalBase.Person
        { get => Person; set => Person = value as Person; }
    }
}
