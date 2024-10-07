
namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

        #endregion

    /// <summary>
    /// Cправочник профессий/должностей.
    /// </summary>
    [DisplayName("Справочник профессий/должностей")]
    public class JobTitle : CatalogBase, IJobTitle
    {        
        /// <summary>
        /// Сокращенное наименоваение должности.
        /// </summary>
        [DisplayName("Должность")]
        [Description("Сокращенное наименование должности")]
        public virtual string ShortName 
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
        public virtual JobCategory JobCategory
        { get; set; }
    }
}