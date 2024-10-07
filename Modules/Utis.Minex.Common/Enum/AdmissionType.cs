
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Перечень допусков.
    /// </summary>
    [DisplayName("Допуск")]
    [Description("Тип допуска")]
    public enum AdmissionType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        [Description("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// Медицинское освидетельствование состояния здоровья.
        /// </summary>
        [DisplayName("Медосмотр")]
        [Description("Медицинское освидетельствование состояния здоровья")]
        Health = 1,

        /// <summary>
        /// Инструктаж по технике безопасности.
        /// </summary>
        [DisplayName("Инструктаж по ТБ")]
        [Description("Инструктаж по технике безопасности")]
        SafetyInstructions = 2,

        /// <summary>
        /// Прохождение квалификационного экзамена.
        /// </summary>
        [DisplayName("Квалификация")]
        [Description("Прохождение квалификационного экзамена")]
        Qualification = 3,

        /// <summary>
        /// Наличия выданных СИЗ.
        /// </summary>
        [DisplayName("Наличия выданных СИЗ")]
        [Description("Наличия выданных СИЗ")]
        AvailabilityIPM = 4,

        /// <summary>
        /// Больничный.
        /// </summary>
        [DisplayName("Больничный")]
        [Description("Больничный")]
        SickLeave = 5,
    }
}