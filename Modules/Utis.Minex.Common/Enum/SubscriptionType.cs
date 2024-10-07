namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип подписки
    /// </summary>
    [DisplayName("Тип подписки")]
    public enum SubscriptionType
    {
        /// <summary>
        /// Игнорировать
        /// </summary>
        [DisplayName("Игнорировать")]
        Ignore = 0,

        /// <summary>
        /// Подписаться
        /// </summary>
        [DisplayName("Подписаться")]
        Subscribe = 1,

        /// <summary>
        /// Отписаться
        /// </summary>
        [DisplayName("Отписаться")]
        Unsubscribe = 2
    }
}