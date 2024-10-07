using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Cправочник профессий/должностей.
    /// </summary>
    [DisplayName("Справочник профессий/должностей")]
    public interface IJobTitle : IObjectNamed
    {
        /// <summary>
        /// Сокращенное наименоваение должности.
        /// </summary>
        [DisplayName("Должность")]
        [Description("Сокращенное наименование должности")]
        string ShortName
        { get; set; }

        ///// <summary>
        ///// Квалификация ИТР (инженерно-технический работник).
        ///// </summary>
        //[DisplayName("Квалификация ИТР")]
        //public virtual JobQualification JobQualification
        //{ get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        [DisplayName("Категория")]
        JobCategory JobCategory
        { get; set; }
    }
}
