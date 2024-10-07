
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Специфичный запрос к БД.
    /// </summary>
    [DisplayName("Специфичный запрос к БД")]
    public enum CustomQueryType
    {
        /// <summary>
        /// Неопределено.
        /// </summary>
        [DisplayName("Неопределено")]
        Default = 0,

        /// <summary>
        /// Свободные, не привязанные светильники.
        /// </summary>
        [DisplayName("Свободные, не привязанные светильники")]
        FreeLamp = 1,

        /// <summary>
        /// Персонал и привязанный к нему светильник.
        /// </summary>
        [DisplayName("Персонал и привязанный к нему светильник")]
        PersonAndBindLamp = 2,

        /// <summary>
        /// Метан в долях ППМ и персонал.
        /// </summary>
        [DisplayName("Метан в долях ППМ и персонал")]
        MethanePpmAndPerson = 3,

        /// <summary>
        /// Метан в уровнях ПДК и персонал.
        /// </summary>
        [DisplayName("Метан в уровнях ПДК и персонал")]
        MethaneLevelAndPerson = 4,

        /// <summary>
        /// Состояние обрыва линий.
        /// </summary>
        [DisplayName("Состояние линий (обрывы)")]
        LineStateAndReaders = 6,

        /// <summary>
        /// Перемещения персонала с подразделениями.
        /// </summary>
        [DisplayName("Перемещения персонала с подразделениями")]
        PersonMovementAndDivision = 7,

        /// <summary>
        /// Состояния портов линий.
        /// </summary>
        [DisplayName("Состояния портов линий")]
        PortStateAndReaders = 8,

        /// <summary>
        /// Состояния опроса линий.
        /// </summary>
        [DisplayName("Состояния опроса линий")]
        LineSurveyAndReaders = 9,

        /// <summary>
        /// Последние перемещения транспорта.
        /// </summary>
        [DisplayName("Последние перемещения транспорта")]
        TransportLastMovements = 10,

        /// <summary>
        /// Последние перемещения персонала.
        /// </summary>
        [DisplayName("Последние перемещения персонала")]
        PersonLastMovements = 11,

        /// <summary>
        /// Последние значения спусков/подъемов персонала.
        /// </summary>
        [DisplayName("Последние значения спусков/подъемов персонала")]
        PersonInOutMineLastValues = 12,

        /// <summary>
        /// Запрос журнала перемещения трансопрта с фильтром на АТО.
        /// </summary>
        [DisplayName("Запрос журнала перемещения трансопрта с фильтром на АТО")]
        MobileMarkPointMovements = 13,

        /// <summary>
        /// Последние значения пар индивидуальное устройство-светильник.
        /// </summary>
        [DisplayName("Последние значения пар индивидуальное устройство-светильник")]
        LampsForIndividualDevices = 15,

        /// <summary>
        /// Транспорт, для которого были перемещения на заданный период.
        /// </summary>
        [DisplayName("Транспорт, для которого были перемещения на заданный период")]
        TransportInMine = 16,

        /// <summary>
        /// Количество переходов между выработками для персонала
        /// </summary>
        [DisplayName("Количество переходов между выработками для персонала")]
        PersonWorkingTransitionCount = 17,

        /// <summary>
        /// Количество переходов между выработками для транспорта
        /// </summary>
        [DisplayName("Количество переходов между выработками для транспорта")]
        TransportWorkingTransitionCount = 18,
        
        /// <summary>
        /// Перемещения персонала по считывателю (запрос используется из-за абстрактного класса считывателя)
        /// </summary>
        [DisplayName("Перемещения персонала по считывателю")]
        PersonMovementsByReader = 19,

        /// <summary>
        /// Люди и устройства в шахте за период
        /// </summary>
        [DisplayName("Люди и устройства в шахте за период")]
        PeopleInMineForPeriod = 20,
        
        /// <summary>
        /// Все ато, для которых были движения в сырых данных
        /// </summary>
        [DisplayName("Все ато, для которых были движения в сырых данных")]
        GetAtoLabelsFromAccurateRfidEvents = 21,

        /// <summary>
        /// Определить глубину, на которую запрашивать журнал сдач-выдач
        /// </summary>
        [DisplayName("Определить глубину, на которую запрашивать журнал сдач-выдач")]
        LastGiveOutDateForIndDevIds = 22,

        /// <summary>
        /// Первые подъемы и сдачи светильников после заданного времени
        /// </summary>
        [DisplayName("Первые подъемы и сдачи светильников после заданного времени")]
        FirstMineOutsAndTurnIns = 23,

        /// <summary>
        /// Уникальные id устройств из событий регистрации АТО
        /// </summary>
        [DisplayName("Уникальные id устройств из событий регистрации АТО")]
        GetTransportIdsFromMarkPointTransportAccurateRfid = 24,
    }

    /// <summary>
    /// Тип ответа от спецефичного запроса к БД.
    /// </summary>
    [DisplayName("Тип ответа от спецефичного запроса к БД")]
    public enum CustomQueryResultType
    {
        /// <summary>
        /// Неопределено.
        /// </summary>
        [DisplayName("Неопределено")]
        Default = 0,

        /// <summary>
        /// Список сущностей.
        /// </summary>
        [DisplayName("Список сущностей")]
        EntityList = 1,

        /// <summary>
        /// Список списков сущностей.
        /// </summary>
        [DisplayName("Список списков сущностей")]
        EntityInnerList = 2,

        /// <summary>
        /// Список массивов объектов.
        /// </summary>
        [DisplayName("Список массивов объектов")]
        ListObjectArray = 3,
    }

    /// <summary>
    /// Тип параметров к запросу.
    /// </summary>
    [DisplayName("Тип параметров к запросу")]
    public enum CustomQueryParametrType
    {
        /// <summary>
        /// Неопределено.
        /// </summary>
        [DisplayName("Неопределено")]
        Default = 0,

        /// <summary>
        /// Значения в строке.
        /// </summary>
        [DisplayName("Значения в строке")]
        CustomStringValue = 1,

        /// <summary>
        /// Список списков сущностей.
        /// </summary>
        [DisplayName("Выражения")]
        Expressions = 2,
    }
}