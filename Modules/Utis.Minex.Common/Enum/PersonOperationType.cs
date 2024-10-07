
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип операции перемещения персонала.
    /// </summary>
    [DisplayName("Тип операции перемещения персонала")]
    public enum PersonOperationType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [EnumDetailEditable(false)]
        [DisplayName("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// Вход в шахту.
        /// </summary>
        [DisplayName("Вход в шахту")]
        InShaft = 1,

        /// <summary>
        /// Выход из шахты.
        /// </summary>
        [DisplayName("Выход из шахты")]
        OutShaft = 2,

        /// <summary>
        /// В шахте.
        /// </summary>
        [DisplayName("В шахте")]
        Shaft = 3,

        /// <summary>
        /// Поверхность.
        /// </summary>
        [DisplayName("Поверхность")]
        Surface = 4,

    }
}