
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус выдачи индивидуального устройства.
    /// </summary>
    [DisplayName("Статус выдачи индивидуального устройства")]
    public enum IndividualDeviceIssueState
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [DisplayName("Не определено")]
        None = 0,

        /// <summary>
        /// Выдано.
        /// </summary>
        [DisplayName("Выдано")]
        Given = 1,

        /// <summary>
        /// Сдано.
        /// </summary>
        [DisplayName("Сдано")]
        Return = 2,
    }
}