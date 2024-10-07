
namespace Utis.Minex.ProductionModel.Catalog.Organize
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

    #endregion

    /// <summary>
    /// Справочник организационной структуры подразделений предприятия.
    /// </summary>
    [DisplayName("ОргСтруктура")]
    [Description("Справочник организационной структуры подразделений предприятия")]
    public class Division : CatalogBase, IDivision
    {
        /// <summary>
        /// Головное подразделение.
        /// </summary>
        [DisplayName("Головное подразделение")]
        public virtual Division DivisionParent 
        { get; set; }
        
        /// <summary>
        /// Категория подразделения.
        /// </summary>
        [DisplayName("Категория")]
        [Description("Категория организационной единицы")]
        public virtual DivisionCategory DivisionCategory 
        { get; set; }

        /// <summary>
        /// Тип организационной единицы.
        /// </summary>
        [DisplayName("Основное")]
        [Description("Основное")]
        public virtual bool IsMainDivision
        { get; set; }

        /// <summary>
        /// Из интеграции.
        /// </summary>
        [DisplayName("Из интеграции")]
        [Description("Из интеграции")]
        public virtual bool IsFromIntegration { get; set; }
        /// <summary>
        /// Тип организационной единицы.
        /// </summary>
        [DisplayName("Режим сменности")]
        [Description("Режим сменности")]
        public virtual ShiftMode ShiftMode
        { get; set; }

        IDivision IDivision.DivisionParent
        { get => DivisionParent; set => DivisionParent = value as Division; }
    }    
}