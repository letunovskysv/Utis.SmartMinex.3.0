namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние соединения с Транспортным Модулем
    /// </summary>
    [DisplayName("Состояние соединения с Транспортным Модулем")]
    public enum TransportModuleConnectionState
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [DisplayName("Не определено")]
        Default = 0,

        /// <summary>
        /// Соединение отсутствует.
        /// </summary>
        [DisplayName("Соединение отсутствует")]
        Disconnected = 1,

        /// <summary>
        /// Соединение в норме.
        /// </summary>
        [DisplayName("Соединение в норме")]
        Connected = 2,
    }
}
