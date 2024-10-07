
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип события позиции транспорта.
    /// </summary>
    [DisplayName("Тип события позиции транспорта")]
    public enum TransportPositionEventType : byte
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        [DisplayName("Оповещение")]
        Default            = 0,

        /// <summary>
        /// Приближение.
        /// </summary>
        [DisplayName("Приближение")]
        Approach           = 1,

        /// <summary>
        /// Максимальное сближение.
        /// </summary>
        [DisplayName("Максимальное сближение")]
        MaximumСloser      = 2,

        /// <summary>
        /// Отдаление.
        /// </summary>
        [DisplayName("Отдаление")]
        Disappear          = 3,

        /// <summary>
        /// Приближение (без расстояния).
        /// </summary>
        [DisplayName("Приближение (без расстояния)")]
        ApproachNoDistance = 4,

        /// <summary>
        /// Отдаление (без расстояния).
        /// </summary>
        [DisplayName("Отдаление (без расстояния)")]
        DisappearNoDistance = 5,
    }
}