namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Действие с АТО
    /// </summary>
    [DisplayName("Действие с АТО")]
    public enum MarkPointOperationType
    {
        Default = 0,

        /// <summary>
        /// Установка
        /// </summary>
        [DisplayName("Установка")]
        Mounting = 1,

        /// <summary>
        /// Демонтаж
        /// </summary>
        [DisplayName("Демонтаж")]
        DeMounting = 2,

        /// <summary>
        /// Контроль
        /// </summary>
        [DisplayName("Контроль")]
        Check = 3
    }
}