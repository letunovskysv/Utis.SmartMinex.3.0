
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип события пейджера.
    /// </summary>    
    [DisplayName("Тип события пейджера")]
    public enum PagerEventType
    {
        ///<summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        DefaultPagerEventType = 0,

        ///<summary>
        /// Подтверждение получения тестового сообщения пейджером.
        /// </summary>
        [DisplayName("Доставлено тестовое сообщение")]
        AutoConfirmText = 1,

        ///<summary>
        /// Подтверждение получения вибрационного сообщения пейджером.
        /// </summary>
        [DisplayName("Доставлено вибрационное сообщение")]
        AutoConfirmVibro = 2,

        ///<summary>
        /// Подтверждение получения сообщения человеком.
        /// </summary>
        [DisplayName("Подтверждение сообщения")]
        ButtonConfirm = 3,

        ///<summary>
        /// Сообщение от человека.
        /// </summary>
        [DisplayName("Сообщение от человека")]
        FromPerson = 4,

        ///<summary>
        /// Удаление соообщения по таймауту, при отсутствии успешной передачи сообщения пейджеру.
        /// </summary>
        [DisplayName("Удаление соообщения")]
        DeleteMessage = 5,
    }
}