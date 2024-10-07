namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Причина отбрасывания позиции
    /// </summary>
    [DisplayName("Причина отбрасывания позиции")]
    public enum ReasonDiscardedAccurateRfidEvent
    {
        /// <summary>
        /// Несколько возможных позиций
        /// </summary>
        [DisplayName("Несколько возможных позиций")]
        SeveralPositions = 1,

        /// <summary>
        /// Ограничение по скорости
        /// </summary>
        [DisplayName("Ограничение по скорости")]
        SpeedLimit = 2,

        /// <summary>
        /// Высокая погрешность
        /// </summary>
        [DisplayName("Высокая погрешность")]
        HighError = 3,

        /// <summary>
        /// Невозможно определить координаты
        /// </summary>
        [DisplayName("Невозможно определить координаты")]
        NotFound = 4,
    }
}
