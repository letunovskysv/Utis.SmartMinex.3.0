
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    public abstract class PersonBindResponsibleJournal : PersonBindJournal
    {
        /// <summary>
        /// Сотрудник внесший запись в журнал.
        /// </summary>
        [DisplayName("Сотрудник внесший запись в журнал")]
        public virtual Person PersonSetBind
        { get; set; }
    }
}
