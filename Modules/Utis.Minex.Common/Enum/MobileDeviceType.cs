
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип мобильного (перемещаемого) устройства.
    /// </summary>
    [DisplayName("Типы моб. устройств")]
    [Description("Тип мобильного (перемещаемого) устройства")]
    public enum MobileDeviceType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("по умолчанию")]
        Default = RfidDeviceType.Default,

        /// <summary>
        /// Радиоблок.
        /// </summary>
        [DisplayName("Метка")]
        Rfu = RfidDeviceType.Rfu,

        /// <summary>
        /// Пейджер.
        /// </summary>
        [DisplayName("Пейджер")]
        Pager = RfidDeviceType.Pager,

        /// <summary>
        /// Самоспасатель.
        /// </summary>
        [DisplayName("Самоспасатель")]
        SelfRescuer = RfidDeviceType.SelfRescuer,

        /// <summary>
        /// Газоанализатор.
        /// </summary>
        [DisplayName("Газоанализатор")]
        Ga = RfidDeviceType.Ga,

        /// <summary>
        /// МУР.
        /// </summary>
        [DisplayName("МУР")]
        Mur = RfidDeviceType.Mur,

        /// <summary>
        /// АТО автономная точка отметки.
        /// </summary>
        [DisplayName("АТО")]
        Ato = RfidDeviceType.Ato,

        /// <summary>
        /// Анкер.
        /// </summary>
        [DisplayName("Анкер")]
        Anchor = RfidDeviceType.Anchor,

        /// <summary>
        /// АФАТП.
        /// </summary>
        [DisplayName("АФАТП")]
        OmnidirectionalAnchor = RfidDeviceType.OmnidirectionalAnchor,

        /// <summary>
        /// Пульт запроса маршрута (ПЗМ)
        /// </summary>
        [DisplayName("ПЗМ")]
        RouteRequestConsole = RfidDeviceType.RouteRequestConsole,
    }
}