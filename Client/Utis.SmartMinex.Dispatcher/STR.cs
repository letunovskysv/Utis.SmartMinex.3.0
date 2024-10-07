//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: STR –
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Client;

/// <summary> Служба управления пользовательскими сессиями.</summary>
public static class STR
{
    public readonly static string CatalogPage = "Справочник/";
    public readonly static string ReportPage = "Отчёт/";
    public readonly static string StartCenterPage = "/Диспетчер";
    public readonly static string SchemaPage = ""; // default
    public readonly static string EditorPage = "/Редактор";
    public readonly static string Exit = "Завершить работу…";
    public readonly static string About = "О программе…";
    public readonly static string Settings = "Настройки…";

    public readonly static string LoadingData = "Загрузка данных...";
    public readonly static string NoRecordsDisplay = "Нет данных для вывода.";
    public readonly static string ClearFilterText = "Очистить";
    public readonly static string SchemaSaveTitle = "Сохранение";
    public readonly static string SchemaSaveErrorTitle = "Ошибка сохранения: ";
    public readonly static string SchemaSaved = "Мнемосхема «{0}» успешно сохранена!";
    public readonly static string SchemaPublishTitle = "Публикация";
    public readonly static string SchemaPublishErrorTitle = "Ошибка публикации: ";
    public readonly static string SchemaPublished = "Мнемосхема «{0}» успешно опубликована!";
    public readonly static string SchemaImported = "Мнемосхема успешно импортирована!";
    public readonly static string SchemaImportedFault = "Ошибка загрузки мнемосхемы! ";
    public readonly static string SchemaChangedTitle = "Изменение мнемосхемы";
    public readonly static string SchemaChanged = "Мнемосхема изменена! Нажмите F5 для обновления мнемосхемы.";
    public readonly static string SchemaNotFound = "План-схема недоступна!";
    public readonly static string SchemaEditNotEnoughRights = "Для редактирования нужно обладать правами администратора!";
    public readonly static string PropertySaveTitle = "Сохранение свойств";
    public readonly static string PropertyInvalidData = "Не обрабатываемый тип данных.";
    public readonly static string PanelManagerError = "Ошибка панели управления.";
    public readonly static string SchemaTargetNotFound = "Не найден объект привязки графического элемента «{0}». Войдите в редактор и установите свойство Target графического элемента.";
    public readonly static string SelectLayerTitle = "Выбор слоя для новых элементов";
    public readonly static string BindedFaultTitle = "Ошибка привязки устройства";
    public readonly static string SuiteNotOptions = "Не настроен контроллер!";
    public readonly static string FindPersonTitle = "Поиск сотрудника по ФИО или номеру светильника:";
    public readonly static string TakeLampTitle = "Выдача/привязка светильника сотруднику";
    public readonly static string GiveLampTitle = "Сдача/отвязка светильника сотрудником";

    public readonly static string DownloadDataTitle = "Выгрузка данных";
    public readonly static string DownloadData = "Выгрузка данных успешна!";
    public readonly static string UploadDataTitle = "Загрузка данных";
    public readonly static string UploadData = "Загрузка данных успешна! Обновите справочник.";
    public readonly static string UploadDataFault = "Ошибка загрузки данных! ";
    public readonly static string CreateNewDeviceFaultTitle = "Ошибка создания устройства";

    public readonly static string AccessDeniedTitle = "Ограничение доступа";
    public readonly static string ControlDeniedForCentral = "Управление устройствами недоступно на центральном узле!";

    public readonly static string AlarmsUnackNotFound = "Нет необработанных тревожных событий.";
    public readonly static string AlarmsUnackCount = "Необработанных тревожных событий: ";

    public readonly static string CameraOnline = "Онлайн";
    public readonly static string CameraArchive = "Архив";
    public readonly static string ErrorCameraViewOnline = "Ошибка просмотра видео";
    public readonly static string ErrorCameraViewArchive = "Ошибка просмотра видеоархива";
    public readonly static string IncorrectCameraSettings = "Неверные настройки телекамеры!";
    public readonly static string VideoNotFoundInLocalArchive = "Запрашиваемое видео отсутствует в локальном видеоархиве.";
    public readonly static string VideoChannelNotFound = "Не найден канал воспроизведения!";

    public readonly static string ErrorAddElement_NodeNotFound = "Ошибка отрисовки графического элемента «{1}» (#{0}). Не найден узел привязки #{2}.";

    public readonly static string OK = "ОК";
    public readonly static string Apply = "Применить";
    public readonly static string ERROR = "Ошибка";
    public readonly static string DASH = "—";
    public readonly static string ProviderNotFound = "<Не найден>";

    public readonly static string ServerNotAvaliable = "Сервер недоступен. Проверьте подключение!";
}
