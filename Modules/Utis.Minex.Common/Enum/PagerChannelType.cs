namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип канала передачи данных пейджеру
    /// </summary>
    [DisplayName("Тип канала передачи данных пейджеру")]
    public enum PagerChannelType
    {
        /// <summary>
        /// По умолчанию (не определено)
        /// </summary>
        [DisplayName("По умолчанию (не определено)")]
        [Description("По умолчанию (не определено)")]
        Default = 0,

        /// <summary>
        /// Через анкер
        /// </summary>
        [DisplayName("Через анкер")]
        [Description("Через анкер")]
        Anchor = 1,

        /// <summary>
        /// Через СУБР
        /// </summary>
        [DisplayName("Через СУБР")]
        [Description("Через СУБР")]
        SUBR = 2,

        /// <summary>
        /// Все доступные каналы
        /// </summary>
        [DisplayName("Все доступные каналы")]
        [Description("Все доступные каналы")]
        All = 3
    }
}