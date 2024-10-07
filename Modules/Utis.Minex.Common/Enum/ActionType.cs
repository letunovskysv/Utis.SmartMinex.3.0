namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы передачи
    /// </summary>
    [DisplayName("Типы передачи")]
    public enum ActionType
    {
        /// <summary>
        /// Запрос
        /// </summary>
        [DisplayName("Запрос")]
        Request = 0,

        /// <summary>
        /// Ответ
        /// </summary>
        [DisplayName("Ответ")]
        Response = 1
    }
}