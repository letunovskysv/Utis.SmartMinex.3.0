using System;

namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

        #endregion

    /// <summary>
    /// Справочник персонала.
    /// </summary>
    [DisplayName("Персонал")]
    [Description("Справочник персонала")]
    public class Person : CatalogBase, IPerson
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        [DisplayName("Фамилия")]
        public virtual string Lastname 
        { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DisplayName("Имя")]
        public virtual string Firstname 
        { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DisplayName("Отчество")]
        public virtual string Middlename 
        { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DisplayName("Дата рождения")]
        public virtual DateTime? BirthDate 
        { get; set; }

        /// <summary>
        /// Пол (0 - муж., 1 - жен.)
        /// </summary>
        [DisplayName("Пол")]
        [Description("Пол (0 - муж., 1 - жен.)")]
        public virtual PersonSex Sex 
        { get; set; }

        /// <summary>
        /// Табельный номер.
        /// </summary>
        [DisplayName("Табельный номер")]
        public virtual string Tabnum 
        { get; set; }

        /// <summary>
        /// Дата увольнения.
        /// </summary>
        [DisplayName("Дата увольнения")]
        public virtual DateTime? FireDate 
        { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division 
        { get; set; }

        /// <summary>
        /// Профессия/должность.
        /// </summary>
        [DisplayName("Профессия/должность")]
        public virtual JobTitle JobTitle 
        { get; set; }

        /// <summary>
        /// Разряд.
        /// </summary>
        [DisplayName("Разряд")]
        public virtual byte? Rank 
        { get; set; }

        /// <summary>
        /// Фото.
        /// </summary>
        [DisplayName("Фото")]
        public virtual ObjectRaw Photo
        { get; set; }

        /// <summary>
        /// Режим сменности.
        /// </summary>
        [DisplayName("Режим сменности")]
        public virtual ShiftMode ShiftMode
        { get;set;  }
        IDivision IPerson.Division { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IJobTitle IPerson.JobTitle { get => JobTitle; set => JobTitle = value as JobTitle; }
    }
}