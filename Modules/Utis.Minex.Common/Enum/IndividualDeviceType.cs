namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип индивидуального мобильного устройства.
    /// </summary>
    [DisplayName("Тип индивидуального мобильного устройства")]
    public enum IndividualDeviceType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = MobileDeviceType.Default,

        /// <summary>
        /// Радиоблок.
        /// </summary>
        [DisplayName("Метка")]
        Rfu = MobileDeviceType.Rfu,

        /// <summary>
        /// Пейджер.
        /// </summary>
        [DisplayName("Пейджер")]
        Pager = MobileDeviceType.Pager,

        /// <summary>
        /// Самоспасатель.
        /// </summary>
        [DisplayName("Самоспасатель")]
        SelfRescuer = MobileDeviceType.SelfRescuer,

        /// <summary>
        /// Газоанализатор.
        /// </summary>
        [DisplayName("Газоанализатор")]
        Ga = MobileDeviceType.Ga,
    }
}