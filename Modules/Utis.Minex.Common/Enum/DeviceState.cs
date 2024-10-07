
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние устройств инфраструктуры позиционирования.
    /// </summary>
    /// <remarks>
    /// Используется для определения состояния всех устройств позиционирования.
    /// </remarks>
    [DisplayName("Состояние устройств инфраструктуры позиционирования")]
    public enum DeviceState
    {
        /// <summary>
        /// Исправен.
        /// </summary>
        [DisplayName("Исправен")]
        [Description("Исправен")]
        Good = 0,

        /// <summary>
        /// Отказ.
        /// </summary>
        [DisplayName("Отказ")]
        [Description("Отказ")]
        Fault = 1,
    }
}