
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус устройства.
    /// </summary>
    [DisplayName("Статус устройства")]
    public enum DeviceStatus
    {
        /// <summary>
        /// Не установлен.
        /// </summary>
        [DisplayName("--")]
        [Description("--")]
        NotSet = 0,

        /// <summary>
        /// В эксплуатации.
        /// </summary>
        [DisplayName("В эксплуатации")]
        [Description("В эксплуатации")]
        Exploitation = 1,

        /// <summary>
        /// В ремонте.
        /// </summary>
        [DisplayName("В ремонте")]
        [Description("В ремонте")]
        Repair = 2,

        /// <summary>
        /// Списан.
        /// </summary>
        [DisplayName("Списан")]
        [Description("Списан")]
        Decommissioned = 3,
    }
}
