
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Пол сотрудника.
    /// </summary>
    [DisplayName("Пол сотрудника")]
    public enum PersonSex
    {
        /// <summary>
        /// Мужчина.
        /// </summary>
        [DisplayName("Мужчина")]
        Male = 0,

        /// <summary>
        /// Женщина.
        /// </summary>
        [DisplayName("Женщина")]
        Female = 1,

        /// <summary>
        /// Не указан (значение по умолчанию).
        /// </summary>
        [DisplayName("Не указан")]
        None = 3,
    }
}