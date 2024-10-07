namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// статус сообщения на пейджер
    /// </summary>
    [DisplayName("статус сообщения на пейджер")]
    public enum PagerCommandState
    {
        /// <summary>
        /// Отправлено
        /// </summary>
        [DisplayName("Отправлено")]
        Sent = 0,

        /// <summary>
        /// Доставлено
        /// </summary>
        [DisplayName("Доставлено")]
        Delivered = 1,

        /// <summary>
        /// Прочтено
        /// </summary>
        [DisplayName("Прочтено")]
        Read = 2,

        /// <summary>
        /// Сообщение от персонала шахты
        /// </summary>
        [DisplayName("Сообщение от персонала шахты")]
        FromPerson = 3,

        /// <summary>
        /// Ошибка доставки
        /// </summary>
        [DisplayName("Ошибка доставки")]
        Failure = 4
    }
}