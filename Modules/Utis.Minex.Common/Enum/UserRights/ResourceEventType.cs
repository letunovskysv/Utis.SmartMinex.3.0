
namespace Utis.Minex.Common
{
    public enum ResourceEventType
    {
        //----------------------------------------------------

        Default = -1,
        None    = 0,

        //----------------------------------------------------
        //обычные (PriorityEventBaseDTO)

        [DisplayName("Событие посещений зоны")]
        ZoneEventPriorityDTO = 1,

        [DisplayName("Событие аварийного сигнала")]
        EmergencyCallEventPriorityDTO = 2,

        [DisplayName("Аварийный вызов")]
        EmergencyEventPriorityDTO = 3,

        [DisplayName("Сообщение пейджера")]
        PagerEventPriorityDTO = 4,

        [DisplayName("Событие состояния соединения с ПУКС")]
        PuksConnectedEventPriorityDTO = 5,

        [DisplayName("Получение сообщения от ПУКС (СУБР)")]
        PuksMessageEventPriorityDTO = 6,

        [DisplayName("Состояние антенны")]
        AntennaStateEventPriorityDTO = 7,

        [DisplayName("Событие состояния поставщика данных")]
        DataProviderStateEventPriorityDTO = 8,

        [DisplayName("Состояние оборудования позиционирования")]
        DeviceStateEventPriorityDTO = 9,

        [DisplayName("Состояние линии связи")]
        LineStateEventPriorityDTO = 11,

        [DisplayName("Состояние порта линии")]
        PortStateEventPriorityDTO = 12,

        [DisplayName("Состояние опроса")]
        SurveyPriorityEventBaseDTO = 13,

        [DisplayName("Контроль считывателей (транспортом)")]
        ReaderStateControlByTransportPriorityDTO = 14,

        [DisplayName("Считыватель имеет линию")]
        ReaderHasLineEventPriorityDTO = 15,

        [DisplayName("Состояние опроса линии")]
        LineSurveyPriorityEventDTO = 16,

        [DisplayName("Состояние опроса считывателя")]
        SurveyPriorityEventDTO = 17,

        [DisplayName("Регистрация людей на транспорте")]
        TransportPersonsEventPriorityDTO = 18,

        [DisplayName("Событие состояния соединения с Транспортным Модулем")]
        TransportModuleConnectionEventPriorityDTO = 19,

        //----------------------------------------------------
        //телеметрия (TelemetryEventPriorityBaseDTO)

        [DisplayName("Событие силы тока")]
        AmperageEventTelemetryDTO = 101,

        [DisplayName("Событие состояния батареи")]
        BatteryStateEventTelemetryDTO = 102,

        [DisplayName("Событие ёмкости батареи оборудования")]
        CapacityEventTelemetryDTO = 103,

        [DisplayName("Событие температуры крышки")]
        CapTemperatureEventTelemetryDTO = 104,

        [DisplayName("Событие уровня зарядки аккумуляторной батареи")]
        ChargeLevelEventTelemetryDTO = 105,

        [DisplayName("Событие процента зарядки аккумуляторной батареи")]
        ChargePercentEventTelemetryDTO = 106,

        [DisplayName("Событие крышки")]
        CoverStateEventTelemetryDTO = 107,

        [DisplayName("Событие обездвиживания")]
        FreezeEventTelemetryDTO = 108,

        [DisplayName("Событие значения метана в категории ПДК")]
        MethaneLevelEventTelemetryDTO = 109,

        [DisplayName("Событие по метану в относительном значении")]
        MethanePPMEventTelemetryDTO = 110,

        [DisplayName("Событие движения")]
        MoveEventTelemetryDTO = 111,

        [DisplayName("Событие типа источника питания")]
        PowerSupplyEventTelemetryDTO = 112,

        [DisplayName("Событие напряжения")]
        VoltageEventTelemetryDTO = 113,

        [DisplayName("Событие контроля АТО (считывателем)")]
        MarkPointFixationStatusDTO = 114,

        [DisplayName("Событие разрыва/сцепления транспорта")]
        TransportBreakEventPriorityDTO = 115,

        [DisplayName("Событие индикации светофора")]
        TrafficLightEventPriorityDTO = 116,

        [DisplayName("Событие контроля АТО (транспортом)")]
        MarkPointTransportFixationStatusDTO = 117,

        [DisplayName("Контроль местонахождения АТО")]
        MarkPointInMoveEventPriorityDTO = 118,

        [DisplayName("Событие активации опасной зоны")]
        ZoneDangerousEventPriorityDTO = 119,

        //----------------------------------------------------
    }
}
