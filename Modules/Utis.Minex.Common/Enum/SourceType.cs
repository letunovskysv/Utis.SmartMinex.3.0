namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Источники аварии.
    /// </summary>
    [DisplayName("Источник аварии")]
    public enum SourceType
    {
        /// <summary>
        /// Сброс аварийного вызова
        /// </summary>
        [DisplayName("Сброс аварийного вызова")]
        AlarmNotAccept = 0,

        /// <summary>
        /// СУБР (от передатчика).
        /// </summary>
        [DisplayName("СУБР")]
        SUBR = 1,

        /// <summary>
        /// СПГТ (от СЧ).
        /// </summary>
        [DisplayName("Считыватель")]
        SPGT = 2,

        /// <summary>
        /// Газоанализ (ГА).
        /// </summary>
        [DisplayName("Газоанализ (ГА)")]
        GA = 3,

        /// <summary>
        /// TEG (авария от анкера).
        /// </summary>
        [DisplayName("Анкер")]
        RTLS = 4,

        /// <summary>
        /// Работник.
        /// </summary>
        [DisplayName("Работник")]
        Person = 5,

        /// <summary>
        /// Источник не определён.
        /// </summary>
        [DisplayName("Источник не определён")]
        Undefined = 7,

        /// <summary>
        /// Сервер приложения
        /// </summary>
        [DisplayName("Система")]
        System = 8,

        /// <summary>
        /// Диспетчер
        /// </summary>
        [DisplayName("Диспетчер")]
        Dispatcher = 9,
    }
}