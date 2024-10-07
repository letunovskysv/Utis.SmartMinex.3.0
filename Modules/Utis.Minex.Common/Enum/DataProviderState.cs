namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние поставщика данных.
    /// </summary>
    [DisplayName("Состояние поставщика данных")]
    public enum DataProviderState
    {
        /// <summary>
        /// Значение не определено.
        /// </summary>
        [DisplayName("Значение не определено")]
        Default = 0,

        /// <summary>
        /// Присоединён.
        /// </summary>
        [DisplayName("Присоединён")]
        Connected = 1,

        /// <summary>
        /// Зарегистрирован.
        /// </summary>
        [DisplayName("Зарегистрирован")]
        Registered = 2,

        /// <summary>
        /// Отсоединён.
        /// </summary>
        [DisplayName("Отсоединён")]
        Disconnected = 3,

        /// <summary>
        /// Подписан.
        /// </summary>
        [DisplayName("Подписан")]
        Subscribed = 4,

        /// <summary>
        /// Отписан.
        /// </summary>
        [DisplayName("Отписан")]
        Unsubscribed = 5,

        /// <summary>
        /// Предупреждение об ошибке.
        /// </summary>
        [DisplayName("Предупреждение об ошибке")]
        Warning = 6
    }
}