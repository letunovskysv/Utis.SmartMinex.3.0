namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние батареи
    /// </summary>
    [DisplayName("Состояние батареи")]
    public enum BatteryState : byte
    {
        /// <summary>
        /// Баттарея отвечает на запросы
        /// </summary>
        [DisplayName("Баттарея отвечает на запросы")]
        Responds = 0,

        /// <summary>
        /// Баттарея не отвечает на запросы
        /// </summary>
        [DisplayName("Баттарея не отвечает на запросы")]
        NotResponds = 1
    }
}