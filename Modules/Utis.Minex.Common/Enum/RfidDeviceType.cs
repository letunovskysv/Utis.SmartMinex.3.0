
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы (классы) устройств позиционирования.
    /// </summary>
    /// <remarks>Тип используется при получении данных с сервера сбора данных.</remarks>
    [DisplayName("Типы устройств позиционирования с меткой")]
    public enum RfidDeviceType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Радиоблок.
        /// </summary>
        [DisplayName("Метка")]
        Rfu = 4,

        /// <summary>
        /// МУР.
        /// </summary>
        [DisplayName("МУР")]
        Mur = 5,

        /// <summary>
        /// УРС.
        /// </summary>
        [DisplayName("УРС")]
        Urs = 6,

        /// <summary>
        /// УРПТ считыватель.
        /// </summary>
        [DisplayName("УРПТ")]
        Urpt = 7,

        /// <summary>
        /// АТО автономная точка отметки.
        /// </summary>
        [DisplayName("АТО")]
        Ato = 8,

        /// <summary>
        /// Пейджер.
        /// </summary>
        [DisplayName("Пейджер")]
        Pager = 9,

        /// <summary>
        /// Пульт запроса маршрута (ПЗМ)
        /// </summary>
        [DisplayName("ПЗМ")]
        RouteRequestConsole = 16,

        /// <summary>
        /// Анкер.
        /// </summary>
        [DisplayName("Анкер")]
        Anchor = 25,

        /// <summary>
        /// Самоспасатель.
        /// </summary>
        [DisplayName("Самоспасатель")]
        SelfRescuer = 33,

        /// <summary>
        /// АФАТП.
        /// </summary>
        [DisplayName("АФАТП")]
        OmnidirectionalAnchor = 35,

        /// <summary>
        /// Газовый анализатор.
        /// </summary>
        [DisplayName("Газовый анализатор")]
        Ga = 512,

        /// <summary>
        /// Метка NFC.
        /// </summary>
        [DisplayName("Метка NFC")]
        NFC = 513,
    }
}