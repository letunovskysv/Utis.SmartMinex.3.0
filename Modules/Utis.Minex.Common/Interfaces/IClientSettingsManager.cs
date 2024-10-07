
namespace Utis.Minex.Common.Settings
{
    using Utis.Minex.Common.Interfaces;

    /// <summary>
    /// Настройки диспетчера.
    /// </summary>
    public interface IClientSettingsManager : 
        IDistanceLocalCacheSettings,
        IGrpcSettings,
        IUserThresholdSettings,
        IDBServicesSettings,
        ISslClientSettings
    {
        /// <summary>
        /// В общем журнале, по умолчанию использовать динамическию загрузку.
        /// </summary>
        [DisplayName("В общем журнале, по умолчанию использовать динамическию загрузку")]
        bool JournalDynamicDefault
        { get; set; }

        /// <summary>
        /// Размер пакета динамической загрузки журнала.
        /// </summary>
        [DisplayName("Размер пакета динамической загрузки журнала")]
        int JournalDynamicBundleSize
        { get; set; }

        /// <summary>
        /// GRPC хост для модуля диагностики.
        /// </summary>
        [DisplayName("GRPC хост для модуля диагностики")]
        string DiagnosticModuleGrpcHost
        { get; set; }

        /// <summary>
        /// GRPC порт для модуля диагностики.
        /// </summary>
        [DisplayName("GRPC порт для модуля диагностики")]
        int DiagnosticModuleGrpcPort
        { get; set; }

        /// <summary>
        /// Не отображать сообщения от устройств старее, чем указанное количество часов.
        /// </summary>
        [DisplayName("Не отображать сообщения от устройств старее, чем указанное количество часов")]
        int DeviceMessageShowTime
        { get; set; }

        /// <summary>
        /// Не отображать сообщений кроме устройств старее, чем указанное количество часов.
        /// </summary>
        [DisplayName("Не отображать сообщения кроме устройств старее, чем указанное количество часов")]
        int MessageShowTime
        { get; set; }

        /// <summary>
        /// Период после которого при аварии по шахте, 
        /// при отсутствии данных по позиционированию человек в списоке спасения становится красным.
        /// </summary>
        [Setting("5")]
        int DataOutOfDateLimitExceeded
        { get; set; }

        /// <summary>
        /// Показывать статус соединения с ПУКС.
        /// </summary>
        [DisplayName("Показывать статус соединения с ПУКС")]
        bool ShowPUKSConnectionStatus
        { get; set; }

        /// <summary>
        /// Уровень детализации графики.
        /// </summary>
        [DisplayName("Уровень детализации графики")]
        string GraphicDetailLevel
        { get; set; }

        /// <summary>
        /// Расстояние скрытой зоны постового от места установки.
        /// </summary>
        [DisplayName("Расстояние скрытой зоны постового от места установки")]
        int GuardDistanceZone
        { get; set; }


        /// <summary>
        /// Отображение дополнительного уведомления об отсутствии связи с СП
        /// </summary>
        [DisplayName("Отображение дополнительного уведомления об отсутствии связи с СП")]
        [Setting("True")]
        public bool ShowAppServDisconMsg
        { get; set; }
    }
}