using System.Collections.Generic;
using Utis.Minex.Common.Attributes;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    public enum ResourceType
    {
        //----------------------------------------------------

        Default = -1,
        None    = 0,

        //----------------------------------------------------
        //Вкладка "Администрирование"/"Интеграция"

        [DisplayName("Справочник кроссов (СПГТ)")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        CrossCatalogDTO = 201,

        [DisplayName("Справочник кроссов (КСИП)")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        CrossCatalogExDTO = 202,

        //----------------------------------------------------
        //Вкладка "Администрирование"/"Сопоставление для событий"

        [DisplayName("Статусы событий")]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        MapStatePriorityEventDTO = 205,

        //----------------------------------------------------
        //Вкладка "Администрирование"/"Типы вызовов"

        [DisplayName("Типы вызовов")]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Update)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        CallTypeDTO = 206,

        //----------------------------------------------------
        //Вкладка "Администрирование"/"Безопасность"->"Журналы безопасности"

        [DisplayName("Журнал авторизации")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        NoteSignInDTO = 303,

        [DisplayName("Журнал изменений статусов событий")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        MapStatePriorityEventChangeHistoryDTO = 2001,

        //Журнал изменения ролей
        //Журнал изменения пользователей
        //Журнал изменения доступа к справочникам и журналам
        //Журнал изменения доступа к уведомлениям о событиях
        //Журнал изменения доступа к отчетам
        //Журнал изменения доступа к элементам модуля Графика
        //Журнал изменения доступа к модулю управления Транспортом
        //Журнал изменения доступа к элементам АРМ Ламповщика
        //Журнал изменения доступа пользователей к ламповой
        [DisplayName("Журналы безопасности")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.Administration)]
        JournalChangeRecordDTO = 708,

        //----------------------------------------------------
        //Вкладка "Пользователи и доступ"/"Справочники"

        [DisplayName("Пользователи")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        UserDataDTO = 302,

        [DisplayName("Роли пользователей")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        RoleDTO = 301,

        //----------------------------------------------------
        //Вкладка "Пользователи и доступ"/"Управление доступом"

        [DisplayName("Доступ пользователей к ламповой")]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Create, RoleActionType.Delete)]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        UserBindDeviceRoomDTO = 309,

        [DisplayName("Доступ к элементам АРМ Ламповщика")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        LampmanRightsDTO = 306,

        [DisplayName("Доступ к элементам модуля Графика")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        GraphicModuleRightsDTO = 305,

        [DisplayName("Доступ к модулю управления транспортом")]
		[ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        TransportModuleRightsDTO = 999,

        [DisplayName("Доступ к отчетам")]
		[ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        ReportAccessRightsDTO = 304,        

        [DisplayName("Доступ к справочникам и журналам")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        MatrixAccessRightsDTO = 307,

        [DisplayName("Доступ к уведомлениям о событиях")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        MatrixEventProcessingRightsDTO = 308,

        [DisplayName("Доступ к управлению зонами")]
		[ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        ZoneControlAccessRightsDTO = 311,

        //----------------------------------------------------
        //Вкладка "Пользователи и доступ"/"Безопасность"

        [DisplayName("Запрещенные пароли")]
        [ResourceTypeCategory(ResourceCategory.UsersAndAccess)]
        PasswordBlackListRecordDTO = 310,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Конфигурация (ССД)"->"Справочники"

        [DisplayName("Сервера ССД")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Update, RoleActionType.Delete)]
        DAServerDTO = 401,

        [DisplayName("Линии")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LineConfigDTO = 402,

        [DisplayName("Порты")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MediaConverterPortDTO = 403,

        [DisplayName("Настройки портов")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PortSettingsDTO = 404,

        [DisplayName("Считыватели")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ReaderDTO = 816,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Схема ИМР"->"Справочники"

        [DisplayName("Зоны")]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Update)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ZoneDTO = 501,

        [DisplayName("Выработки")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        WorkingDTO = 502,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Схема ИМР"->"Журналы"

        [DisplayName("Связка Зона-Устройство")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ZoneBindDeviceJournalDTO = 504,

        [DisplayName("Типы зон")]
        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        ZoneTypeDTO = 505,

        [DisplayName("Привязки типов зон к зонам")]
        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        ZoneTypeJournalDTO = 506,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Транспорт"->"Справочники"

        [DisplayName("Причины простоя транспорта")]
		[ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ReasonDowntimeDTO = 604,

        [DisplayName("Типы простоя транспорта")]
		[ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DowntimeTypeDTO = 605,

        [DisplayName("Составы электровозов")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TrainJournalDTO = 607,

        [DisplayName("Транспорт")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportDTO = 601,

        [DisplayName("Модели транспорта")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportModelDTO = 602,

        [DisplayName("Производители транспорта")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        VendorDTO = 603,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Транспорт"->"Журналы"

        [DisplayName("Журнал простоев транспорта")]
		[ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DowntimeDTO = 705,

        // UMS-2787 - Скрыть журнал антинаезда транспорта
        [Enabled(false)]
        [DisplayName("Журнал антинаезда транспорта")]
        AnticollisionJournalDTO = 702,

        [DisplayName("Журнал перемещений транспорта")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportMovementDTO = 701,

        [DisplayName("Журнал зон ответственности участков")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ZoneResponsibilityBindDivisionDTO = 710,

        [DisplayName("Журнал регистрации разрывов транспорта")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportBreakEventPriorityDTO = 707,

        [DisplayName("Журнал посадки/высадки машинистов и пассажиров")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportPersonsEventPriorityDTO = 709,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Транспорт"->"Журналы привязок"

        [DisplayName("Журнал распределённой техники")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransportBindPersonDivisionDTO = 704,

        [DisplayName("Журнал привязок устройств к транспорту")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DeviceBindTransportDTO = 703,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Журналы изменения"

        [DisplayName("Журнал изменения простоев")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read)]        
        DowntimeJournalChangesDTO = 706,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Персонал"->"Справочники"

        [DisplayName("Персонал")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonDTO = 801,

        [DisplayName("Персональные карты")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonalCardDTO = 802,

        [DisplayName("Подразделения")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DivisionDTO = 805,

        [DisplayName("Должности")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        JobTitleDTO = 806,

        [DisplayName("Подразделения с условиями труда, приравненными к подземным условиям")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PayrollByLampIssueDivisionDTO = 821,

        [DisplayName("Принадлежность к ВГК")]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Create, RoleActionType.Delete)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonVGKDTO = 941,

        [DisplayName("Принадлежность к ВР")]

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Create, RoleActionType.Delete)]
        PersonExploseWorkDTO = 942,

        [DisplayName("Стажеры")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonTraineeDTO = 976,

        [DisplayName("Привязки сотрудников к стажёрам")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        TraineeMentorDTO = 977,

		[ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [DisplayName("Менеджер смен")]
        ShiftManagerDTO = 1005,

        [DisplayName("Справочник ламповых")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        IndividualDevicesRoomDTO = 819,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Персонал"->"Журналы"

        [DisplayName("Журнал перемещений персонала")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonMovementRValueDTO = 903,

        [DisplayName("Журнал квитации событий")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        AckEventDTO = 907,

        [DisplayName("Журнал действий диспетчера")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DispatcherCommandDTO = 908,

        [DisplayName("Журнал ручных подъёмов персонала")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        NoteManualLiftingDTO = 909,

        [DisplayName("Журнал сдачи/выдачи индивидуальных устройств")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        IndividualDeviceRValueDTO = 901,

        [DisplayName("Журнал неуспешной выдачи/сдачи светильников")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        IndividualDeviceFailedJournalDTO = 918,

        [DisplayName("Журнал нарушения смен")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ShiftViolationJournalDTO = 1002,

        [DisplayName("Журнал нарушителей опасных зон")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ZoneEventPriorityDTO = 943,

        [DisplayName("Журнал недопуска стажёров в шахту")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        NonAdmissionTrainee = 919,

        [Enabled(false)]
        [DisplayName("Отброшенные события точного позиционирования")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        DiscardedAccurateRfidEventDTO = 924,

        [Enabled(false)]
        [DisplayName("Журнал разрывов точного позиционирования")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        WorkingBreakeJournal = 904,
        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Персонал"->"Журналы привязок"

        [DisplayName("Привязки персональных карт")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonCardBindRegisterDTO = 803,

        [DisplayName("Постоянные привязки устройств")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        IndividualDeviceBindRValueDTO = 902,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Персонал"->"Журналы событий"

        [DisplayName("Аварийные вызовы")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        EmergencyEventPriorityDTO = 911,

        [DisplayName("Обездвиживание сотрудника")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        FreezeEventTelemetryDTO = 935,

        [DisplayName("Метан (ПДК)")]

        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MethaneLevelAndPerson = 937,

        [DisplayName("Метан (PPM)")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MethanePpmAndPerson = 938,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Справочники"

        [DisplayName("Радиоблоки")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        RFUnitDTO = 807,

        [DisplayName("Метки")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        RfidDeviceDTO = 809,

        [DisplayName("Стационарные АТО")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MarkPointDTO = 811,

        [DisplayName("Считыватели неконтролирующие АТО")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ReadersDontControlMarkPointDTO = 822,

        [DisplayName("Мобильные АТО")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MobileMarkPointDTO = 812,

        [DisplayName("Мобильные устройства регистрации")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MobileRegDeviceDTO = 813,

        [DisplayName("Светильники")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LampDTO = 814,

        [DisplayName("Типы светильников")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LampTypeDTO = 815,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы"

        //[DisplayName("Журнал сдачи/выдачи индивидуальных устройств")]
        //IndividualDeviceRegisterDTO = 901,

        [DisplayName("Журнал перемещения АТО")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MarkPointMovementJournalDTO = 939,

        [DisplayName("Журнал отсутствия связи с УРПТ-ИС-Т")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MobileRegDeviceOfflineJournalDTO = 945,

        [DisplayName("Журнал перемещения мобильных АТО")]

        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MobileMarkPointMovements = 926,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы привязок"

        //[DisplayName("Постоянные привязки устройств")]
        //IndividualDeviceBindRegisterDTO = 902,

        [DisplayName("Привязки встраиваемых устройств к лампам")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LampDeviceBindRValueDTO = 905,

        [DisplayName("Устройства подключённые к блоку питания")]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Create, RoleActionType.Delete)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PowerSupplyBindDeviceDTO = 1007,

        [DisplayName("Привязки считывателей к линиям")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ReaderToLineChangedEventPriorityDTO = 944,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы событий"

        [DisplayName("Сводный журнал событий")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        EventLog = 910,

        [DisplayName("Текущие неисправности устройств")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DeviceStatesView = 5001,

        [DisplayName("Индикация светофоров")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]        
        TrafficLightEventPriorityDTO = 998,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы событий"->"Считыватели"

        [DisplayName("Состояния считывателей")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DeviceStateEventPriorityDTO = 913,

        [DisplayName("Состояния антенн считывателей")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        AntennaStateEventPriorityDTO = 914,

        [DisplayName("Состояния опроса считывателей")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        SurveyPriorityEventDTO = 915,

        [DisplayName("Контроль считывателей (транспортом)")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ReaderStateControlByTransportEventPriorityDTO = 940,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы событий"->"Линии"

        [DisplayName("Состояния обрыва линий")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LineStateAndReaders = 916,

        [DisplayName("Состояния портов линий")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PortStateAndReaders = 1008,

        [DisplayName("Состояния опроса линий")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        LineSurveyAndReaders = 1009,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы событий"->"СУБР"

        [DisplayName("Состояния соединения с ПУКС")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PuksConnectedEventPriorityDTO = 920,

        [DisplayName("Сообщения от ПУКС (СУБР)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PuksMessageEventPriorityDTO = 921,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Журналы событий"->"Стационарные АТО"

        [DisplayName("Контроль АТО (транспортом)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MarkPointTransportFixationStatusDTO = 923,


        [DisplayName("Фиксация АТО (транспортом)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MarkPointTransportAccurateRfidDTO = 925,

        [DisplayName("Контроль местонахождения АТО")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        MarkPointInMoveEventPriorityDTO = 946,

        //----------------------------------------------------
        //Вкладка "Справочники и журналы"/"Устройства"->"Телементрия"

        [DisplayName("Сила тока")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        AmperageEventTelemetryDTO = 927,

        // UMS-2515 Временно скрыто до полной реализации
        [Enabled(false)]
        [DisplayName("Емкость батареи")]
        CapacityEventTelemetryDTO = 928,

        [DisplayName("Источники питания")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PowerSupplyEventTelemetryDTO = 929,

        [DisplayName("Процент заряда батареи")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ChargePercentEventTelemetryDTO = 930,

        [DisplayName("Уровень заряда батареи")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        ChargeLevelEventTelemetryDTO = 931,

        [DisplayName("Состояния батарей")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        BatteryStateEventTelemetryDTO = 932,

        [DisplayName("Состояния крышки")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        CoverStateEventTelemetryDTO = 933,

        [DisplayName("Температура крышки")]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        CapTemperatureEventTelemetryDTO = 934,

        //----------------------------------------------------

        //упраздняется
        [DisplayName("Пейджеры")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PagerDTO = 817,

        //упраздняется
        [Enabled(false, true)]
        [DisplayName("Текст пейджера")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PagerTextDTO = 818,

        [DisplayName("Изменение привязки светильников к ламповым")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Update)]
        LampBindingChange = 820,

        //----------------------------------------------------

        [Enabled(false, true)]
        [DisplayName("Доставка сообщений на пейджер")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        PagerEventPriorityDTO = 912,

        //----------------------------------------------------
        #region Управление зонами

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Менеджер опасных зон")]
        ZoneDangerousJournalDTO = 906,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление списком разрешений зон ВР")]
        ZoneExplosion = 2011,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление зонами ВР/постовых в редакторе")]
        ZoneExplosionEditor = 2002,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление назначением постовых")]

        [ResourceTypeAccessAction(RoleActionType.Read, RoleActionType.Create, RoleActionType.Delete)]
        ZoneGuard = 2003,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление опасными зонами")]
        ZoneDangerous = 2005,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление опасными зонами в редакторе")]
        ZoneDangerousEditor = 2006,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Управление зонами зонального позиционирования в редакторе")]
        ZonalPositioningEditor = 2008,

        [ResourceTypeCategory(ResourceCategory.ZoneControl)]
        [DisplayName("Журнал изменений по опасным зонам")]
        ZoneDangerousActivityJournalDTO = 2010,

        #endregion Управление зонами
        //----------------------------------------------------
        #region Интеграционные справочники (3000-3100)

        [DisplayName("Интегр. справочник подразделений (Apms)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DivisionFromApmsDTO = 3002,

        [DisplayName("Интегр. справочник должностей (Apms)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        JobTitleFromApmsDTO = 3003,
                
        [DisplayName("Интегр. справочник персонала (Apms)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonFromApmsDTO = 3004,

        [DisplayName("Интегр. журнал уведомлений о спуске подъеме")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DeascentsFromStppDTO = 3005,

        [DisplayName("Интегр. справочник подразделений (Sigur)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        DivisionFromSigurDTO = 3006,

        [DisplayName("Интегр. справочник должностей (Sigur)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        JobTitleFromSigurDTO = 3007,

        [DisplayName("Интегр. справочник персонала (Sigur)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        PersonFromSigurDTO = 3008,

        [DisplayName("Интегр. справочник категории должностей (Sigur)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        JobCategoryFromSigurDTO = 3009,

        [DisplayName("Интегр. справочник «Инструктор-Стажер» (Sigur)")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TraineeMentorFromSigurDTO = 3010,

        #endregion Интеграционные справочники (3000-3100)

        //----------------------------------------------------
        [Enabled(false, true)]
        [DisplayName("Динамический отчет 'Люди в шахте'")]
        Test = 4000,

        //Межсистемная интеграция
        [DisplayName("Справочник смежных рудников")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        JoinedMineDTO = 3020,

        [DisplayName("Справочник переходных зон")]
        [ResourceTypeCategory(ResourceCategory.CatalogsAndJournals)]
        TransitionZoneDTO = 3021,

        #region Графика (5000-6000)

        [Enabled(false)]
        [DisplayName("Обозреватель 3D")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        Viewer3D = 4001,

        [Enabled(false)]
        [DisplayName("Обозреватель истории")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        PlayBack = 4002,

        [Enabled(false)]
        [DisplayName("Редактор 2D")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        SchemeEditor = 4003,

        [Enabled(false)]
        [DisplayName("Редактор 3D")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        Editor3D = 4004,

        [Enabled(false)]
        [DisplayName("Сообщения об Аварии")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        EmergencyCall = 4010,

        [Enabled(false)]
        [DisplayName("Сброс сообщения об аварии")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        EmergencyReset = 4011,

        [Enabled(false)]
        [DisplayName("Отправка сообщения на пэйджер")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        PagerCall = 4012,

        [Enabled(false)]
        [DisplayName("Индивидуальные вызовы")]
        [ResourceTypeCategory(ResourceCategory.Graphics)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        IndividualCalls = 4013,


        #endregion Графика (5000-6000)

        #region Транспорт

        [Enabled(false)]
        [DisplayName("Открытые простои транспорта")]
        [ResourceTypeCategory(ResourceCategory.Transport)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        OpenedDowntimeControl,

        [Enabled(false)]
        [DisplayName("Распределение транспорта")]
        [ResourceTypeCategory(ResourceCategory.Transport)]
        [ResourceTypeAccessAction(RoleActionType.Read)]
        TransportChiefControl,

        #endregion Транспорт

        #region Отчеты (6000-7000)

        [DisplayName("Нарушители режима (по времени)")]
        [GroupPath("Персонал;Нарушители")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        TimeExceed = 6001, //Нарушители режима по времени

        [Enabled(false, false)]
        [GroupPath("Персонал;Нарушители")]
        [DisplayName("Нарушители смен")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        ShiftViolation = 6002, //Нарушители смен

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Свободные светильники")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        FreeLamps = 6003, //Свободные светильники

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Выданные светильники")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        GivenLamps = 6004, //Выданные светильники

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Невыданные светильники")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        NotGivenLamps = 6005, //Навыданные светильники

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Сводный отчет регистрации отметок и нарушений")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        ConsolidatedLamps = 6006, //Сводный отчет по светильникам

        [Enabled(false, false)] //Доступен только в ламповщике, добавляется вручную
        [GroupPath("Отчеты ламповой")]
        [DisplayName("Статистика по светильникам и персоналу")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        LampStatistic = 6007, // Статистика по светильникам и персоналу

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Подъемы вручную")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        ManualLifting = 6008, //Подъемы вручную

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Люди в шахте")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PeopleInMine = 6009, //Люди в шахте

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Люди на поверхности")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PeopleOnSurface = 6010,

        [Enabled(false, false)] // пока не нужен
        [DisplayName("Список персонала")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PeopleList = 6011,

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Несданные светильники")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        NotReturnedLamps = 6012,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Нахождение в опасной зоне (персонал)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        DangerousZoneBreakPerson = 6013,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Нахождение в горной выработке (персонал)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PresentInMinePerson = 6014,

        [GroupPath("Транспорт;Перемещение")]
        [DisplayName("Нахождение в горной выработке (транспорт)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PresentInMineTransport = 6015,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Маршрут персонала")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonRoute = 6016,

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Справочник светильников")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        LampList = 6017,

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Сотрудники ВГК в шахте")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PeopleVgkInMine = 6018,

        [GroupPath("Транспорт;Перемещение")]
        [DisplayName("Маршрут транспорта")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        TransportRoute = 6019,

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Время в шахте")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        TimeInMine = 6020,

        [GroupPath("Персонал;Нарушители")]
        [DisplayName("Нарушители режима (по отметкам)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        ViolatorsForPeriod = 6021,

        [GroupPath("Транспорт")]
        [DisplayName("Посадка-высадка (по сотруднику)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        BoardingByPerson = 6022,

        [GroupPath("Транспорт")]
        [DisplayName("Посадка-высадка (по транспорту)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        BoardingByTransport = 6023,

        [GroupPath("Устройства")]
        [DisplayName("Контроль АТО (транспортом)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        MarkpointTransportFixation = 6024,

        [GroupPath("Устройства")]
        [DisplayName("История перемещения АТО")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        MarkpointMovement = 6025,

        [GroupPath("Устройства")]
        [DisplayName("История состояний работы устройств позиционирования")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        DeviceStateHistory = 6026,

        [GroupPath("Устройства")]
        [DisplayName("Состояние работы устройств позиционирования")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        DeviceState = 6027,

        [GroupPath("Персонал;Перемещение")]
        [Enabled(false, true)]
        [DisplayName("Переходы между несвязанными выработками")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        WorkingBreak = 6028,

        [GroupPath("Персонал")]
        [DisplayName("Аварийные вызовы")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        EmergencyCalls = 6029,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Маршрут персонала (по анкерам)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonRouteByAnchor = 6030,

        [GroupPath("Транспорт;Перемещение")]
        [DisplayName("Нахождение в опасной зоне (транспорт)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        DangerousZoneBreakTransport = 6031,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Регистрация персонала на зональных считывателях")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonRegByZonalAnchor = 6032,


        [GroupPath("Транспорт;Перемещение")]
        [DisplayName("Перемещение транспорта по АТО")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        TransportMovementByAto = 6033,

        [GroupPath("Устройства")]
        [DisplayName("Фиксация АТО анкерами")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        AtoFixationByAnchor = 6034,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Выход сотрудников из шахты")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonMineExits = 6035,

        [GroupPath("Персонал")]
        [DisplayName("Списки спасения")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        EmergencyEvents = 6036,

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Переходы на смежные рудники (персонал)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        JoinedMineTransitionsPerson = 6037,

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Люди на смежных рудниках")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonsInJoinedMines = 6038,

        [GroupPath("Транспорт;Перемещение")]
        [DisplayName("Переходы на смежные рудники (транспорт)")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        JoinedMineTransitionsTransport = 6039,

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Справочник виртуальных светильников")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        VirtualLampList = 6040,

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Нахождение постовых на постах")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        GuardsAtPosts = 6041,

        [GroupPath("Персонал;Нахождение в шахте")]
        [DisplayName("Сотрудники без движения")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        FreezePerson = 6042,

        [GroupPath("Отчеты ламповой")]
        [DisplayName("Список персонала и закреплённые светильники")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonsAndFixedLamps = 6043, //Список персонала и закреплённые светильники

        [GroupPath("Персонал;Перемещение")]
        [DisplayName("Персонал в районе анкера")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        PersonNearAnchor = 6044,

        [GroupPath("Персонал")]
        [DisplayName("Аварийная сводка")]
        [ResourceTypeCategory(ResourceCategory.Reports)]
        CurrentEmergencyInfo = 6046,

        #endregion Отчеты (6000-7000)
    }
}
