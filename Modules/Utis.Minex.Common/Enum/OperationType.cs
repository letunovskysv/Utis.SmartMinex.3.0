
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы операций.
    /// </summary>
    [DisplayName("Типы операций")]
    public enum OperationType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Создание.
        /// </summary>
        [DisplayName("Создание")]
        Create = 1,

        /// <summary>
        /// Чтение.
        /// </summary>
        [DisplayName("Чтение")]
        Read = 2,

        /// <summary>
        /// Обновление.
        /// </summary>
        [DisplayName("Обновление")]
        Update = 3,

        /// <summary>
        /// Удаление.
        /// </summary>
        [DisplayName("Удаление")]
        Delete = 4,

        /// <summary>
        /// Помечено как удалённое.
        /// При этом стоит помнить что MarkAsDelete это по сути есть Update,
        /// в котором указано что одно из обновлённых свойств "Deleted = true".
        /// </summary>
        [DisplayName("Помечено как удалённое")]
        MarkAsDelete = 5,
    }
}