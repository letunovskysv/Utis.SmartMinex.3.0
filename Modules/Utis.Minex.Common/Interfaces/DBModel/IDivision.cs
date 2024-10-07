using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Справочник организационной структуры подразделений предприятия.
    /// </summary>
    [DisplayName("ОргСтруктура")]
    [Description("Справочник организационной структуры подразделений предприятия")]
    public interface IDivision : IObjectNamed
    {
        /// <summary>
        /// Головное подразделение.
        /// </summary>
        [DisplayName("Головное подразделение")]
        IDivision DivisionParent
        { get; set; }

        /// <summary>
        /// Категория подразделения.
        /// </summary>
        [DisplayName("Категория")]
        [Description("Категория организационной единицы")]
        DivisionCategory DivisionCategory
        { get; set; }

        /// <summary>
        /// Тип организационной единицы.
        /// </summary>
        [DisplayName("Основное")]
        [Description("Основное")]
        public bool IsMainDivision
        { get; set; }

        /// <summary>
        /// Из интеграции.
        /// </summary>
        [DisplayName("Из интеграции")]
        [Description("Из интеграции")]
        public bool IsFromIntegration 
        { get; set; }

        ///// <summary>
        ///// Тип организационной единицы.
        ///// </summary>
        //[DisplayName("Режим сменности")]
        //[Description("Режим сменности")]
        //ShiftMode ShiftMode
        //{ get; set; }
    }
}
