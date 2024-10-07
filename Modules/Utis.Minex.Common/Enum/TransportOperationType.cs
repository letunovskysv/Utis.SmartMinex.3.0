namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип операции перемещения транспорта.
    /// </summary>
    [DisplayName("Тип операции перемещения транспорта")]
    public enum TransportOperationType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// Вход в шахту.
        /// </summary>
        [DisplayName("В шахте")]
        InShaft = 1,

        /// <summary>
        /// Выход из шахты.
        /// </summary>
        [DisplayName("Выход из шахты")]
        OutShaft = 2,
    }
}
