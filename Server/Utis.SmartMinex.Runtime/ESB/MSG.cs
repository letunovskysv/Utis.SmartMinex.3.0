//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MSG – Константы. Сообщения системной очереди сообщений.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

/// <summary> Константы. Сообщения системной очереди сообщений.</summary>
public static class MSG
{
    public static string ToString(int msg) =>
        typeof(MSG).GetFields().FirstOrDefault(f => (int)f.GetValue(null) == msg)?.Name ?? msg.ToString("X");

    public const int None = 0x0000;

    /// <summary> Выполняется после окончания запуска всех служб.</summary>
    public const int StartServer = 0x0001;
    /// <summary> Выполняется при остановке объектового сервере.</summary>
    public const int StopServer = 0x0002;
    /// <summary> Установить модуль/службу в Систему.</summary>
    public const int InstallModule = 0x0003;
    /// <summary> Удалить модуль/службу из Системы.</summary>
    public const int UninstallModule = 0x0004;
    /// <summary> Выполнить (создать и запустить) микросервис.</summary>
    /// <remarks> LParam = PID процесса из которого послано сообщение.</remarks>
    public const int RunModule = 0x0005;
    /// <summary> Запустить созданный ранее созданный микросервис. LParam = Id процесса.</summary>
    public const int Start = 0x0006;
    /// <summary> Остановить микросервис без выгрузки процесса. LParam = Id процесса.</summary>
    public const int Stop = 0x0007;
    /// <summary> Остановить и выгрузить микросервис. LParam = Id процесса.</summary>
    /// <remarks> Это сообщение для всех подключаемых модулей.</remarks>
    public const int Kill = 0x0008;
    /// <summary> Выполняется после запуска главного процеса выполнения.</summary>
    public const int Started = 0x0009;
    /// <summary> Выполняется после запуска всех модулей.</summary>
    public const int Completed = 0x000a;

    /// <summary> LParam = Id процесса.</summary>
    public const int ErrorMessage = 0x000c;
    /// <summary> LParam = Id процесса.</summary>
    public const int CriticalMessage = 0x000d;
    /// <summary> LParam = Id процесса.</summary>
    public const int WarningMessage = 0x000e;
    /// <summary> LParam = Id процесса.</summary>
    public const int InformMessage = 0x000f;

    /// <summary> Отправка сообщения во внешний брокер сообщений. Исходящее сообщение.</summary>
    /// <remarks> LParam = Id процесса.</remarks>
    public const int BrokerMessageOut = 0x001c;
    /// <summary> Входящее сообщения из внешнего брокера сообщений.</summary>
    /// <remarks> LParam = Id процесса.</remarks>
    public const int BrokerMessageIn = 0x001d;

    /// <summary> Клиентское сообщение для подключённого пользователя. Используется для уведомлений пользователя о событиях в системе, обычно ошибок.</summary>
    /// <remarks> LParam = Id процесса; HParam = Тип сообщения; Data = ClientMessage.</remarks>
    public const int ClientMessage = 0x0010;
    /// <summary> Приём консольной команды.</summary>
    /// <remarks> LParam = ИД терминальной сессии; HParam = ИД процесса (модуля).</remarks>
    public const int ConsoleCommand = 0x0011;
    /// <summary> Запись в системный журнал событий.</summary>
    /// <remarks> LParam = Action; HParam = ИД АРМ ТБ.</remarks>
    public const int EventsLog = 0x0012;
    /// <summary> Запись в журнал безопасности.</summary>
    /// <remarks> LParam = Action; HParam = ИД АРМ ТБ.</remarks>
    public const int SecurityLog = 0x0013;
    /// <summary> Вывод в окно терминала по протоколу <em>Telnet</em>. HParam = ИД session.</summary>
    /// <remarks> LParam = ИД процесса (модуля); HParam = ИД терминальной сессии; Data = text/int - 0x484F4C44 HOLD, 0x46524545 FREE.</remarks>
    public const int Terminal = 0x0014;
    /// <summary> Вывод в окно терминала по протоколу <em>Telnet</em> без форматирования. HParam = ИД session.</summary>
    /// <remarks> LParam = ИД процесса (модуля); HParam = ИД терминальной сессии; Data = text/int - 0x484F4C44 HOLD, 0x46524545 FREE.</remarks>
    public const int TerminalDirect = 0x0015;

    /// <summary> Прерывание терминальной операции.</summary>
    /// <remarks> LParam = ???; HParam = ИД терминальной сессии.</remarks>
    public const int Cancel = 0x0016;
    /// <summary> Логирование.</summary>
    /// <remarks> LParam = ИД процесса (модуля); HParam = LogLevel; Data = сообщение.</remarks>
    public const int Log = 0x0017;

    /// <summary> Обслуживание базы данных.</summary>
    public const int MaintenanceDB = 0x0018;
    /// <summary> Команда на перезапуск службы объектового сервера.</summary>
    public const int RestartAppServer = 0x52535452;
    /// <summary> Выполнить пользовательский сценарий (скрипт).</summary>
    /// <remarks> LParam = 0x505954484F4E (Питон); HParam = ИД процесса модуля; Data = Скрипт. </remarks>
    public const int Script = 0x0019;
    /// <summary> Конфигурация (метаданные загружены).</summary>
    public const int MetadataLoaded = 0x001a;
    /// <summary> Изменён объект конфигурации (метаданных).</summary>
    /// <remarks> LParam = ИД объекта конфигурации; HParam = ???; Data = Объект конфигурации. </remarks>
    public const int ObjectModified = 0x001b;

    /// <summary> .</summary>
    /// <remarks> LParam = ИД расписания (события); HParam = ?; Data = ? </remarks>
    public const int ScheduleEventFired = 0x0065;

    /// <summary> Изменение состояния устройства.</summary>
    public const int DeviceStateChanged = 0x0100;

    /// <summary> Нижняя граница пользовательских сообщений.</summary>
    /// <remarks> Используется для обмена пользовательскими сообщениями внутри модулей. Рекомендуется складывать это означение с ProccessId и номером по порядку в рамках процеса.</remarks>
    public const int Custom = 0x70000000;

    /// <summary> Тестовое сообщение.</summary>
    public const int Test = 0x7FFFFFFF;
}