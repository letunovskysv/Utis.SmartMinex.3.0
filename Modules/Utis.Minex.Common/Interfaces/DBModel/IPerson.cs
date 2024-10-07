using System;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Справочник персонала.
    /// </summary>
    [DisplayName("Персонал")]
    [Description("Справочник персонала")]
    public interface IPerson : IObjectNamed
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        [DisplayName("Фамилия")]
        string Lastname
        { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DisplayName("Имя")]
        string Firstname
        { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DisplayName("Отчество")]
        string Middlename
        { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DisplayName("Дата рождения")]
        DateTime? BirthDate
        { get; set; }

        /// <summary>
        /// Пол (0 - муж., 1 - жен.)
        /// </summary>
        [DisplayName("Пол")]
        [Description("Пол (0 - муж., 1 - жен.)")]
        PersonSex Sex
        { get; set; }

        /// <summary>
        /// Табельный номер.
        /// </summary>
        [DisplayName("Табельный номер")]
        string Tabnum
        { get; set; }

        /// <summary>
        /// Дата увольнения.
        /// </summary>
        [DisplayName("Дата увольнения")]
        DateTime? FireDate
        { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        IDivision Division
        { get; set; }

        /// <summary>
        /// Профессия/должность.
        /// </summary>
        [DisplayName("Профессия/должность")]
        IJobTitle JobTitle
        { get; set; }

        /// <summary>
        /// Разряд.
        /// </summary>
        [DisplayName("Разряд")]
        byte? Rank
        { get; set; }
    }
}
