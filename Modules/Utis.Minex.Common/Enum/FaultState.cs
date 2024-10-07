namespace Utis.Minex.Common.Enum
{
    [DisplayName("Состояние работы портов линии")]
    public enum FaultState
    {
        /// <summary>
        /// Отказ портов на линии
        /// </summary>
        [DisplayName("Отказ портов")]
        Fault = 0,

        /// <summary>
        /// Работа портов на линии восстановлена
        /// </summary>
        [DisplayName("Работа портов восстановлена")]
        Good = 1,
    }
}