using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Каталог с привязкой к сотруднику
    /// </summary>
    [DisplayName("Каталог с привязкой к сотруднику")]
    public interface IPersonBindJournalBase : IJournalClose
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        [DisplayName("Сотрудник")]
        IPerson Person
        { get; set; }

        /// <summary>
        /// Тип привязки
        /// </summary>
        [DisplayName("Тип привязки")]
        PersonBindType PersonBindType
        { get; set; }
    }
}
