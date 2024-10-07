namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип источника аварийного события
    /// </summary>
    public enum EmergencyInitiatorType
    {
        /// <summary>
        /// Не определен
        /// </summary>
        [DisplayName("Не определен")]
        Default = 0,

        /// <summary>
        /// Светильник
        /// </summary>
        [DisplayName("Светильник")]
        Lamp = 1,

        /// <summary>
        /// Работник
        /// </summary>
        [DisplayName("Работник")]
        Person = 2,

        /// <summary>
        /// Диспетчер
        /// </summary>
        [DisplayName("Диспетчер")]
        Dispatcher = 3,

        /// <summary>
        /// Система
        /// </summary>
        [DisplayName("Система")]
        System = 4
    }
}
