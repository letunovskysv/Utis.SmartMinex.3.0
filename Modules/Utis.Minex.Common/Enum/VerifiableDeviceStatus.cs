
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус устройства, подлежащего поверке.
    /// </summary>
    [DisplayName("Статус устройств, подлежащих поверке")]
    public enum VerifiableDeviceStatus
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

        /// <summary>
        /// На поверке.
        /// </summary>
        [DisplayName("На поверке")]
        [Description("На поверке")]
        Verification = 4,
    }
}
