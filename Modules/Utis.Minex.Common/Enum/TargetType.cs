namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип объекта
    /// </summary>
    [DisplayName("Тип объекта")]
    public enum TargetType
    {
        /// <summary>
        /// По умолчанию
        /// </summary>
        [DisplayName("По умолчанию")]
        Default = 0,

        /// <summary>
        /// Персонал
        /// </summary>
        [DisplayName("Персонал")]
        Person = 1,

        /// <summary>
        /// Транспорт
        /// </summary>
        [DisplayName("Транспорт")]
        Transport = 2
    }
}