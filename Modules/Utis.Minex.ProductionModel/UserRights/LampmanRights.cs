namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Права доступа к АРМ Старшего ламповщика.
    /// </summary>
    [DisplayName("Права доступа к АРМ Старшего ламповщика")]
    [Description("Матрица доступа к АРМ Старшего ламповщика в зависимости от роли")]
    [RegisterChanges(true)]
    public class LampmanRights : CatalogBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль")]
        [RegisterChangesOnCreate(true)]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Доступ к меню "Персонал".
        /// </summary>
        [DisplayName("Меню Персонал")]
        [Description("Меню Персонал")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuPerson
        { get; set; }

        /// <summary>
        /// Доступ к меню "Светильники".
        /// </summary>
        [DisplayName("Меню Светильники")]
        [Description("Меню Светильники")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuLamp
        { get; set; }

        /// <summary>
        /// Доступ к меню "Типы светильников".
        /// </summary>
        [DisplayName("Меню типы светильников")]
        [Description("Меню типы светильников")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuLampType
        {get; set; }

        /// <summary>
        /// Доступ к меню "Радиоблоки".
        /// </summary>
        [DisplayName("Меню Радиоблоки")]
        [Description("Меню Радиоблоки")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuRFUnit
        { get; set; }

        /// <summary>
        /// Доступ к меню "Газоанализаторы".
        /// </summary>
        [DisplayName("Меню Газоанализаторы")]
        [Description("Меню Газоанализаторы")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuGasAnalyzer
        {get; set; }

        /// <summary>
        /// Доступ к меню "Радиостанции".
        /// </summary>
        [DisplayName("Меню Радиостанции")]
        [Description("Меню Радиостанции")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuRadio
        { get; set; }

        /// <summary>
        /// Доступ к меню "Метки".
        /// </summary>
        [DisplayName("Меню Метки")]
        [Description("Меню Метки")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuRfidDevice
        { get; set; }

        /// <summary>
        /// Доступ к меню "Отчеты".
        /// </summary>
        [DisplayName("Меню Отчеты")]
        [Description("Меню Отчеты")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableMenuReports
        { get; set; }
    }
}