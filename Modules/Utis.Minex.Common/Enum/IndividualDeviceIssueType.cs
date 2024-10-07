
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип выдачи/сдачи индивидуального устройства.
    /// </summary>
    [DisplayName("Тип выдачи/сдачи индивидуального устройства")]
    public enum IndividualDeviceIssueType
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [DisplayName("Не определено")]
        None = 0,

        /// <summary>
        /// Через УРС.
        /// </summary>
        [DisplayName("Через УРС")]
        ByURS = 1,

        /// <summary>
        /// Вручную.
        /// </summary>
        [DisplayName("Вручную")]
        Manual = 2,
    }
}