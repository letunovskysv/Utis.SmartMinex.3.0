using System.Configuration;
using System.Collections.Generic;

namespace Utis.Minex.Common.Settings
{
    #region Using

    using Utis.Minex.Common.Interfaces;

    #endregion

    public interface IServerSettingsManager : 
        IDistanceLocalCacheSettings,
        IGrpcSettings, 
        IDBServicesSettings,
        ISslServerSettings,
        IUTProtoSettings,
        ISettingsManagerBase
    {
        #region PrmsDbConnection

        /// <summary>
        /// Таймаут соединения с БД (в секундах).
        /// </summary>
        [DisplayName("Таймаут соединения с БД")]
        int DBCommandTimeOut
        { get; set; }

        /// <summary>
        /// Создавать базы данных по указанным в строках подключения, если не существуют.
        /// </summary>
        [DisplayName("Создавать базы данных по указанным в строках подключения, если не существуют")]
        bool CreateIfNotExistDatabase
        { get; set; }

        /// <summary>
        /// Строка подключения к MetadataDB.
        /// </summary>
        [DisplayName("Строка подключения к MetadataDB")]
        string MetadataDBConnection
        { get; set; }

        /// <summary>
        /// Строка подключения к ProductionDB.
        /// </summary>
        [DisplayName("Строка подключения к ProductionDB")]
        string ProductionDBConnection
        { get; set; }

        /// <summary>
        /// Строка подключения к InteractionDB.
        /// </summary>
        [DisplayName("Строка подключения к InteractionDB")]
        string InteractionDBConnection
        { get; set; }

        /// <summary>
        /// Строка подключения к DataAcquisitionDB.
        /// </summary>
        [DisplayName("Строка подключения к DataAcquisitionDB")]
        string DataAcquisitionDBConnection
        { get; set; }

        #endregion

        #region PrmsInteractionThroughTables

        /// <summary>
        /// Интеграционное взаимодействие с APMS.
        /// </summary>
        [DisplayName("Интеграционное взаимодействие с APMS")]
        bool UseInteractionApms
        { get; set; }

        /// <summary>
        /// Опция, которая включает новый функционал интеграционной логики (с 2-х уровневыми подразделениями) и отключает старый
        /// </summary>
        [DisplayName("Включить двух-уровневую иерархию подразделений для интеграции")]
        bool UseTwoLevelDivisionsApms
        { get; set; }

        /// <summary>
        /// Передавать данные о спусках и подъемах в APMS.
        /// </summary>
        [DisplayName("Передавать данные о спусках и подъемах в APMS")]
        bool UseDeascentsFromStpp
        { get; set; }

        /// <summary>
        /// Интеграционное взаимодействие с SIGUR.
        /// </summary>
        [DisplayName("Интеграционное взаимодействие с SIGUR")]
        bool UseInteractionSigur
        { get; set; }

        /// <summary>
        /// Обрабатывать данные по связке инструктор-стажер из SIGUR.
        /// </summary>
        [DisplayName("Обрабатывать данные по связке инструктор-стажер из SIGUR")]
        bool UseTraineeMentorFromSigur
        { get; set; }

        /// <summary>
        /// Опция при которой, в случае отсутствия дивизиона в перечне "RedirectDivision" - игнорировать персоны и сам дивизион.
        /// </summary>
        [DisplayName("Режектить подразделения покоторым отсутствуют данные в таблице перенаправления")]
        bool UseRejectByNoDataOfRedirectDivision
        { get; set; }

        /// <summary>
        /// Персонал из интеграции только для чтения.
        /// </summary>
        [DisplayName("Персонал из интеграции только для чтения")]
        bool PersonByIntegrationReadOnly
        { get; set; }

        [DisplayName("Защита от брутфорса API авторизации")]
        public bool IPBrutProtection
        { get; set; }

        [DisplayName("Запрет на редактирование кода СУБР светильника")]
        bool SUBRCodeReadOnly
        { get; set; }

        #endregion

        #region PrmsSPGT41

        /// <summary>
        /// Имя СПГТ-41.
        /// </summary>
        [DisplayName("Имя СПГТ-41")]
        string SPGT41ExternalSystemName
        { get; set; }

        /// <summary>
        /// Строка подключения к БД СПГТ-41.
        /// </summary>
        [DisplayName("Строка подключения к БД СПГТ-41")]
        string SPGT41DBConnectionString
        { get; set; }

        #endregion

        #region PrmsPCLampModule

        /// <summary>
        /// Хост службы службы обмена старших ламповщиков.
        /// </summary>
        [DisplayName("Хост службы службы обмена старших ламповщиков")]
        string PCLampModuleHost
        { get; set; }

        /// <summary>
        /// Порт службы обмена старших ламповщиков.
        /// </summary>
        [DisplayName("Порт службы обмена старших ламповщиков")]
        int PCLampModulePort
        { get; set; }

        #endregion

        #region PrmsStorageAtoStates

        /// <summary>
        /// Порог ожидания с момента последнего события регистрации АТО.
        /// </summary>
        [DisplayName("Порог ожидания с момента последнего события регистрации АТО")]
        int MarkPointLostInMinutes
        { get; set; }

        /// <summary>
        /// Интервал времени до регистрации простоя.
        /// </summary>
        [DisplayName("Интервал времени до регистрации простоя")]
        int DowntimeThresholdInMinutes
        { get; set; }

        /// <summary>
        /// Минимальная частота получения данных для регистрации автоматического простоя.
        /// </summary>
        [DisplayName("Минимальная частота получения данных для регистрации автоматического простоя")]
        int DowntimeDataDensityControlInMinutes
        { get; set; }

        /// <summary>
        /// Погрешность имерения дистанции для регистрации автоматического простоя.
        /// </summary>
        [DisplayName("Погрешность измерения дистанции для регистрации автоматического простоя")]
        int DowntimeDistanceMeasurementError
        { get; set; }

        /// <summary>
        /// Порог ожидания с момента последнего события регистрации АТО.
        /// </summary>
        [DisplayName("Порог ожидания с момента последнего события регистрации АТО")]
        int MarkPointLostByTransportInMinutes
        { get; set; }

        /// <summary>
        /// Порог ожидания с момента последнего события регистрации стационарного считывателя транспортом.
        /// </summary>
        [DisplayName("Порог ожидания с момента последнего события регистрации стационарного считывателя транспортом")]
        int ReaderStateControlByTransportInMinutes
        { get; set; }

        #endregion

        #region PrmsInteractionThroughTables

        /// <summary>
        /// Период обработки поступивших данных из интеграционных таблиц.
        /// </summary>
        [DisplayName("Период обработки поступивших данных из интеграционных таблиц")]
        int InSecondsWakeTimeoutInteractionCatalog
        { get; set; }

        #endregion

        #region LogFolders

        /// <summary>
        /// Путь к папке логирования ошибок валидации.
        /// </summary>
        [DisplayName("Путь к папке логирования ошибок валидации")]
        string ValidationLogFolderPath
        { get; set; }

        /// <summary>
        /// Путь к папке сохранения архива логов ошибок валидации.
        /// </summary>
        [DisplayName("Путь к папке сохранения архива логов ошибок валидации")]
        string ValidationCollectLogFolderPath
        { get; set; }

        #endregion

        #region PropertiesAndFields

        /// <summary>
        /// Кол-во секунд до генерации отмены индивидуального вызова
        /// </summary>
        [DisplayName("Кол-во секунд до генерации отмены индивидуального вызова")]
        int IndividualCallCancellationDelay
        { get; set; }

        /// <summary>
        /// Кол-во секунд до генерации отмены индивидуального вызова СУБР
        /// </summary>
        [DisplayName("Кол-во секунд до генерации отмены индивидуального вызова СУБР")]
        int IndividualCallSubrCancellationDelay
        { get; set; }

        /// <summary>
        /// Флаг для включения автоматической генерации автоподтверждения аварийного вызова (по событию позиционирования).
        /// </summary>
        [DisplayName("Автоматическая генерация подтверждения аварийного вызова по событию позиционирования")]
        bool EmulateAutoConfirm
        { get; set; }

        /// <summary>
        /// Обработка событий точного позиционирования в модуле обработки событий анкеров.
        /// </summary>
        [DisplayName("Обработка событий точного позиционирования в модуле обработки событий анкеров")]
        bool AccurateRfidEventEnabled
        { get; set; }

        /// <summary>
        /// Обработка событий наезда в модуле обработки событий анкеров.
        /// </summary>
        [DisplayName("Обработка событий наезда в модуле обработки событий анкеров")]
        bool AnchorHittingEventEnabled
        { get; set; }

        /// <summary>
        /// Откидывать события точного позиционирования старее последнего на N-секунд.
        /// </summary>
        [DisplayName("Откидывать события точного позиционирования старее последнего на N-секунд")]
        int IgnoreAccurateOlderSeconds
        { get; set; }

        /// <summary>
        /// Скрыть метки указанного типа RfidDeviceType.
        /// </summary>
        [DisplayName("Скрыть метки указанного типа RfidDeviceType")]
        string HideLabelsOfType
        { get; set; }

        /// <summary>
        /// Считать RSSI гарантией положения метки в одиночной выработке.
        /// </summary>
        [DisplayName("Считать RSSI гарантией положения метки в одиночной выработке.")]
        public bool GuaranteedPositionBySingleAnchorRSSI
        { get; set; }

        /// <summary>
        /// Автоматически проверяет или обновляет схему в базе данных.
        /// </summary>
        [DisplayName("Автоматически проверяет или обновляет схему в базе данных.")]
        bool UseAutoUpdateSchemaInDataBase
        { get; set; }

        /// <summary>
        /// Максимальная скорость перемещения персонала.
        /// </summary>
        [DisplayName("Максимальная скорость перемещения персонала")]
        float PersonMaxSpeed
        { get; set; }

        /// <summary>
        /// Максимальная скорость перемещения транспорта.
        /// </summary>
        [DisplayName("Максимальная скорость перемещения транспорта")]
        float TransportMaxSpeed
        { get; set; }

        /// <summary>
        /// Интервал демпфирования событий точного позиционирования, с.
        /// </summary>
        [DisplayName("Интервал демпфирования событий точного позиционирования, с.")]
        int AccurateEventsDumperTime
        { get; set; }

        /// <summary>
        /// Интервал, по прошествии которого не учитывать предыдущее положение метки.
        /// </summary>
        [DisplayName("Интервал, по прошествии которого не учитывать предыдущее положение метки")]
        int IgnorePreviousPositionAfter
        { get; set; }

        /// <summary>
        /// Объём кэша журнала перемещений персонала, в тысячах.
        /// </summary>
        [DisplayName("Объём кэша журнала перемещений персонала, в тысячах")]
        int PersonMovementCacheCapacity
        { get; set; }

        /// <summary>
        /// Объём инициализации кэша журнала перемещений персонала при старте, в тысячах.
        /// </summary>
        [DisplayName("Объём инициализации кэша журнала перемещений персонала при старте, в тысячах")]
        int PersonMovementCacheOnStartCapacity
        { get; set; }

        /// <summary>
        /// Валидировать ли данные при работе с каталогами.
        /// </summary>
        [DisplayName("Валидировать ли данные при работе с каталогами")]
        bool UseValidation
        { get; set; }

        /// <summary>
        /// Использовать LyriX.
        /// </summary>
        [DisplayName("Использовать LyriX")]
        bool UseLyriX
        { get; set; }

        /// <summary>
        /// Хост модуля Grpc.
        /// </summary>
        [DisplayName("Хост модуля Grpc")]
        string GrpcModuleHost
        { get; set; }

        /// <summary>
        /// Порт модуля Grpc.
        /// </summary>
        [DisplayName("Порт модуля Grpc")]
        int GrpcModulePort
        { get; set; }

        /// <summary>
        /// Порт транспортного модуля
        /// </summary>
        [DisplayName("Порт транспортного модуля")]
        int TransportModulePort
        { get; set; }

        /// <summary>
        /// Максимальный разряд профессий.
        /// </summary>
        [DisplayName("Максимальный разряд профессий")]
        byte MaxProfessionRank
        { get; set; }

        /// <summary>
        /// Допустимая погрешность несоответствия замеров анкеров в метрах.
        /// (Между замерами с двух анкеров всегда есть некоторое несовпадение,
        /// допустимое несовпадение = фактическое минимальное несовпадение + допустимая погрешность несоответствия замеров анкеров.)
        /// </summary>
        [DisplayName("Допустимая погрешность несоответствия замеров анкеров")]
        byte MaxAllowErrDistancesMismatch
        { get; set; }

        /// <summary>
        /// Вывод из шахты по событию сдачи светильника
        /// </summary>
        [DisplayName("Вывод из шахты по событию сдачи светильника")]
        bool OutShaftByLampReturn
        { get; set; }

        /// <summary>
        /// Обработка событий от Анкеров с дистанцией -1 в качестве событий зонального позиционирования
        /// </summary>
        [DisplayName("Обработка зональных событий от Анкеров")]
        bool AnchorZonalMode
        { get; set; }

        /// <summary>
        /// Интервал игнорирования событий обездвиживания, с.
        /// </summary>
        [DisplayName("Интервал игнорирования событий обездвиживания, с.")]
        int TimeFreezeIgnore
        { get; set; }

        /// <summary>
        /// Интервал игнорирования событий опасной зоны, с.
        /// </summary>
        [DisplayName("Интервал игнорирования событий опасной зоны, с.")]
        int TimeZoneDangerousIgnore
        { get; set; }

        /// <summary>
        /// Использовать очистку секционных таблиц по истечению времени хранения
        /// </summary>
        [DisplayName("Использовать очистку секционных таблиц по истечению времени хранения")]
        public bool UsePartitionsCleaning
        { get; set; }

        /// <summary>
        /// Обрабатывать ли исторические данные позиционирования
        /// </summary>
        [DisplayName("Обрабатывать ли исторические данные позиционирования")]
        public bool HistoricalAccurateRfidEventHandler
        { get; set; }

        /// <summary>
        /// Погрешность расстояния от анкера до фиксированной АТО
        /// </summary>
        [DisplayName("Погрешность расстояния от анкера до фиксированной АТО")]
        public int MarkPointDistanceMeasurementError
        { get; set; }

        /// <summary>
        /// Количество измерений для высчитывания среднего расстояния до АТО
        /// </summary>
        [DisplayName("Количество измерений для высчитывания среднего расстояния до АТО")]
        public int MarkPointEnoughCountMeasurement
        { get; set; }

        /// <summary>
        /// Параллельная обработка событий точного позиционирования
        /// </summary>
        [DisplayName("Параллельная обработка событий точного позиционирования")]
        bool ParallelProcessAccurateEvent
        { get; set; }

        /// <summary>
        /// Максимальное время отставания данных точного позиционирования для обработки с высоким приоритетом
        /// </summary>
        [DisplayName("Максимальное время отставания данных точного позиционирования для обработки с высоким приоритетом")]
        int AccurateRealtimeHandlerDepthOnStart
        { get; set; }

        /// <summary>
        /// Автоматическая высадка человека из транспорта
        /// </summary>
        [DisplayName("Автоматическая высадка человека из транспорта")]
        bool AutoTransportPassengerDropOff
        { get; set; }

        /// <summary>
        /// Вклинивание в журнал перемещения
        /// </summary>
        [DisplayName("Вклинивание в журнал перемещения")]
        bool WedgeInEnabled
        { get; set; }

        /// <summary>
        /// Время после которого метки посереют на клиентах
        /// </summary>
        [DisplayName("Время после которого метки посереют на клиентах")]
        int TokenActualTimeInSeconds
        { get; set; }

        /// <summary>
        /// Позиционирование УРПТ-ИС-Т по АТО
        /// </summary>
        [DisplayName("Позиционирование УРПТ-ИС-Т по АТО")]
        bool TransportPositionByMarkPoint
        { get; set; }

        /// <summary>
        /// Фиксировация выхода из шахты неопределённой транспортной метки (без привязки к транспорту),
        /// при отсутствии событий позиционирования за заданный интервал времени
        /// </summary>
        [DisplayName("Интервал времени в минутах для фиксация выхода у транспортной метки (без привязки к транспорту)")]
        int UnknownTransportOutShaftByTime 
        { get; set; }

        /// <summary>
        /// Период отправки отброшенной позиции на клиент (в секундах)
        /// </summary>
        [DisplayName("Период отправки отброшенной позиции на клиент (в секундах)")]
        int DiscardedPositionReceiveFrequency
        { get; set; }

        /// <summary>
        /// Опция примагничивания персонала к анкерам (в метрах)
        /// </summary>
        [DisplayName("Опция примагничивания персонала к анкерам (в метрах)")]
        int AnchorMagnetPerson
        { get; set; }

        /// <summary>
        /// Опция примагничивания транспорта к анкерам (в метрах)
        /// </summary>
        [DisplayName("Опция примагничивания транспорта к анкерам (в метрах)")]
        int AnchorMagnetTransport
        { get; set; }


        /// <summary>
        /// Опция примагничивания меток к анкерам
        /// </summary>
        [DisplayName("Время группировки событий позиционирования для поиска задействованных анкеров, мс")]
        int TimeGroupAnchorRfidEvents
        { get; set; }

        /// <summary>
        /// Допустимое количество углов от анкера до метки при расчёте позиционирования
        /// </summary>
        [DisplayName("Допустимое количество углов от анкера до метки при расчёте позиционирования")]
        int CountAnglesAccurateEvent
        { get; set; }

        /// <summary>
        /// Пароль для защиты Excel отчетов от изменения
        /// </summary>
        [DisplayName("Пароль для защиты Excel отчетов от изменения")]
        string ExcelReportsPassword { get; set; }

        /// <summary>
        /// Контроль разрыва состава/транспорта
        /// </summary>
        [DisplayName("Контроль разрыва состава/транспорта")]
        bool TransportBreakControl { get; set; }

        /// <summary>
        /// Отсрочка передачи данных о спусках/подъемах в КСИП (в часах)
        /// </summary>
        [DisplayName("Отсрочка передачи данных о спусках/подъемах в КСИП (в часах)")]
        int DeascentsSendDelayHours { get; set; }

        #endregion

        #region GetAllKeys

        Dictionary<string, string> GetAllKeys();

        #endregion

        #region GetValueByParameterName
        object GetValueByParameterName(string paramName);
        #endregion
    }
}