namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние индикации светофора
    /// </summary>
    [DisplayName("Состояние индикации светофора")]
    public enum  TrafficLightState
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("По умолчанию")]
        DefaultTrafficLightState = 0,
        
        /// <summary>
        /// Горит красный - проезд запрещён
        /// </summary>
        [DisplayName("Красный")]
        [Description("Горит красный - проезд запрещён")]
        RedLight = 1,

        /// <summary>
        /// Горит зелёный - проезд разрешён
        /// </summary>
        [DisplayName("Зелёный")]
        [Description("Горит зелёный - проезд разрешён")]
        GreenLight = 2,

        /// <summary>
        /// Попеременно моргают красный-зелёный - неисправен
        /// </summary>
        [DisplayName("Попеременное моргание")]
        [Description("Попеременно моргают красный-зелёный - неисправен")]
        RedGreenBlink = 3,

        /// <summary>
        /// Моргает зелёный - ожидается переключение на красный
        /// </summary>
        [DisplayName("Моргающий зеленый")]
        [Description("Моргает зелёный - ожидается переключение на красный")]
        GreenBlink = 4,

        /// <summary>
        /// Моргает красный - ожидается переключение на зелёный
        /// </summary>
        [DisplayName("Моргающий красный")]
        [Description(" Моргает красный - ожидается переключение на зелёный")]
        RedBlink = 5,
    }
}
