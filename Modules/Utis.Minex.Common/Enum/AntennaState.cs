
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статусы антенн.
    /// </summary>
    [DisplayName("Статусы антенн")]
    public enum AntennaState
    {
        /// <summary>
        /// Исправна.
        /// </summary>
        [DisplayName("Исправна")]
        [Description("Исправна")]
        Good = DeviceState.Good,

        /// <summary>
        /// Отказ.
        /// </summary>
        [DisplayName("Отказ")]
        [Description("Отказ")]
        Fault = DeviceState.Fault,

        /// <summary>
        /// Короткозамкнута.
        /// </summary>
        [DisplayName("Короткозамкнута")]
        [Description("Короткозамкнута")]
        Shortened,

        /// <summary>
        /// Не используется.
        /// </summary>
        [DisplayName("Не используется")]
        [Description("Не используется")]
        Unused,
    }
}