
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип тега.
    /// </summary>
    [DisplayName("Тип тега")]
    public enum ProxyTagType : byte
    {
        //TODO прописать, что явялется ключом для каждого типа, проверить, нужны ли DisplayName
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Коллекция последних позиций меток.
        /// </summary>
        [DisplayName("Коллекция последних позиций меток")]
        LastPositions = 3,

        /// <summary>
        /// Добавить или обновить позицию метки.
        /// </summary>
        [DisplayName("Добавить или обновить позицию метки")]
        AddOrUpdatePosition = 4,

        /// <summary>
        /// Событие аварийного вызова по шахте, с приоритетом.
        /// </summary>
        [DisplayName("Событие аварийного вызова по шахте, с приоритетом")]
        EmergencyCallEventPriority = 5,

        /// <summary>
        /// Событие аварии в шахте.
        /// </summary>
        [DisplayName("Событие аварии в шахте")]
        EmergencyEventPriority = 6,

        /// <summary>
        /// Событие состояния поставщика данных.
        /// </summary>
        [DisplayName("Событие состояния поставщика данных")]
        DataProviderStateEventPriority = 7,

        /// <summary>
        /// Состояние опроса линии.
        /// </summary>
        [DisplayName("Состояние опроса линии")]
        LineSurveyPriorityEvent = 9,

        /// <summary>
        /// Состояние опроса.
        /// </summary>
        [DisplayName("Состояние опроса")]
        SurveyPriorityEvent = 10,

        /// <summary>
        /// Событие процента зарядки аккумуляторной батареи.
        /// </summary>
        [DisplayName("Событие процента зарядки аккумуляторной батареи")]
        ChargePercentEventTelemetry = 11,

        /// <summary>
        /// Событие типа источника питания.
        /// </summary>
        [DisplayName("Событие типа источника питания")]
        PowerSupplyEventTelemetry = 12,

        /// <summary>
        /// Событие уровня заряда аккумуляторной батареи.
        /// </summary>
        [DisplayName("Событие уровня заряда аккумуляторной батареи")]
        ChargeLevelEventTelemetry = 13,

        /// <summary>
        /// Событие доставки сообщения на пейджер.
        /// </summary>
        [DisplayName("Событие доставки сообщения на пейджер")]
        PagerEventPriority = 14,

        /// <summary>
        /// Событие получения сообщения от ПУКС (СУБР).
        /// </summary>
        [DisplayName("Событие получения сообщения от ПУКС (СУБР)")]
        PuksMessageEventPriority = 15,

        /// <summary>
        /// Событие границы опасной зоны.
        /// </summary>
        [DisplayName("Событие границы опасной зоны")]
        ZoneEventPriority = 16,

        /// <summary>
        /// Состояние обрыва линии связи.
        /// </summary>
        [DisplayName("Состояние обрыва линии связи")]
        LineStateEventPriority = 17,

        /// <summary>
        /// Событие значения метана в кадегории ПДК.
        /// </summary>
        [DisplayName("Событие значения метана в кадегории ПДК")]
        MethaneLevelEventTelemetry = 18,

        /// <summary>
        /// Событие обездвиживания.
        /// </summary>
        [DisplayName("Событие обездвиживания")]
        FreezeEventTelemetry = 19,

        /// <summary>
        /// Событие крышки.
        /// </summary>
        [DisplayName("Событие крышки")]
        CoverStateEventTelemetry = 20,

        /// <summary>
        /// Состояние оборудования позиционирования.
        /// </summary>
        [DisplayName("Состояние оборудования позиционирования")]
        DeviceStateEventPriority = 21,

        /// <summary>
        /// Состояние антенны.
        /// </summary>
        [DisplayName("Состояние антенны")]
        AntennaStateEventPriority = 22,

        GasEvent = 23,

        /// <summary>
        /// Событие отказа портов линии.
        /// </summary>
        [DisplayName("Событие портов линии")]
        PortStateEventPriority = 24,

        /// <summary>
        /// Состояние соединения с ПУКС (СУБР).
        /// </summary>
        [DisplayName("Состояние соединения с ПУКС (СУБР)")]
        PuksConnectedEventPriority = 25,

        /// <summary>
        /// Событие маршрута.
        /// </summary>
        [DisplayName("Событие маршрута")]
        RouteEventPriority = 26,

        /// <summary>
        /// Событие наличия линии у считывателя.
        /// </summary>
        [DisplayName("Событие наличия линии у считывателя")]
        ReaderLineHasLinePriority = 27,

        /// <summary>
        /// Выдача устройства человеку.
        /// </summary>
        [DisplayName("Выдача устройства человеку")]
        PersonIssue = 28,

        //TODO Подлежит удалению как только плейбэк перейдёт на новые рельсы
        /// <summary>
        /// Привязка устройства к человеку.
        /// </summary>
        [DisplayName("Привязка устройства к человеку")]
        PersonBind = 29,

        /// <summary>
        /// Событие появления не закрытого простоя.
        /// </summary>
        [DisplayName("Событие появления не закрытого простоя")]
        DowntimeNotClosed = 31,

        /// <summary>
        /// Состав транспорта, ключ - id транспорта.
        /// </summary>
        [DisplayName("Состав транспорта")]
        TransportCompound = 32,

        /// <summary>
        /// Привязка машиниста к транспорту.
        /// </summary>
        [DisplayName("Привязка машиниста к транспорту")]
        TransportBindPersonDivision = 33,

        /// <summary>
        /// Событие контроля АТО (транспортом).
        /// </summary>
        [DisplayName("Событие контроля АТО (транспортом)")]
        MarkPointTransportFixationStatus = 34,

        /// <summary>
        /// Событие индикации светофора
        /// </summary>
        [DisplayName("Событие индикации светофора")]
        TrafficLightEventPriority = 36,

        /// <summary>
        /// Событие разрыва/сцепления транспорта.
        /// </summary>
        [DisplayName("Событие разрыва/сцепления транспорта")]
        TransportBreakEventPriority = 37,

        /// <summary>
        /// Событие привязки устройства к блоку питания
        /// </summary>
        [DisplayName("Привязка устройства к блоку питания")]
        PowerSupplyBindDevice = 38,

        /// <summary>
        /// Смена линии у анкера
        /// </summary>
        [DisplayName("Смена линии у анкера")]
        ReaderToLineChangedEventPriority = 39,

        /// <summary>
        /// Событие списка людей на транспорте.
        /// </summary>
        [DisplayName("Событие списка людей на транспорте")]
        TransportPersonsEventPriority = 40,

        /// <summary>
        /// Движение стационарной АТО
        /// </summary>
        [DisplayName("Движение стационарной АТО")]
        MarkPointInMoveEventPriority = 41,

        /// <summary>
        /// Отброшенная позиция
        /// </summary>
        [DisplayName("Отброшенная позиция")]
        DiscardedAccurateRfidEvent = 42,        
        
        /// <summary>
        /// Состояние соединения с Транспортным Модулем
        /// </summary>
        [DisplayName("Состояние соединения с Транспортным Модулем")]
        TransportModuleConnectionEventPriority = 43,

        /// <summary>
        /// Событие активации опасной зоны
        /// </summary>
        [DisplayName("Событие активации опасной зоны")]
        ZoneDangerousEventPriority = 44
    }
}