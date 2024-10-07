namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Разрыв/сцепление транспорта
    /// </summary>
    [DisplayName("Разрыв/сцепление транспорта")]
    public enum TransportBreakState : byte
    {
        /// <summary>
        /// По умолчанию
        /// </summary>
        [DisplayName("По умолчанию")]
        Default = 0,

        /// <summary>
        /// Разрыв
        /// </summary>
        [DisplayName("Разрыв")]
        Broken = 1,

        /// <summary>
        /// Сцепление
        /// </summary>
        [DisplayName("Сцепление")]
        Unbroken = 2,
    }
}