//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IModule – Интерфейс модуля.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public interface IService
{
    /// <summary> Идентификатор модуля.</summary>
    long Id { get; set; }

    /// <summary> Системный идентификатор процесса.</summary>
    int ProcessId { get; set; }

    /// <summary> Статус выполнения.</summary>
    RuntimeStatus Status { get; }
}

/// <summary> Интерфейс модуля.</summary>
public interface IModule : IService
{
    /// <summary> Наименование модуля.</summary>
    string Name { get; set; }

    /// <summary> Список типов сообщений на которые подписывается данный модуль.</summary>
    int[] Messages { get; }

    /// <summary> Метод входящего сообщения для данного модуля.</summary>
    void ProcessMessage(TMessage m);

    /// <summary> Начало выполнения модуля.</summary>
    Task StartProcess(CancellationToken stoppingToken);

    /// <summary> Окончание выполнения модуля.</summary>
    Task StopProcess(CancellationToken stoppingToken);

    /// <summary> Цикл выполнения модуля.</summary>
    Task ExecuteProcessAsync(CancellationToken stoppingToken);

    /// <summary> Отправка сообщения непосредственно модулю напрямую, миную общую очередь.</summary>
    void SendDirect(TMessage m);

    /// <summary> Установка свойства модуля с сохранением в БД, если необходимо.</summary>
    bool SetProperty(string propertyName, object value, out string message);

    #region Runtime events

    /// <summary> Событие при запуске модуля, вызывается в модуле Runtime.</summary>
    /// <remarks> Вызывается после успешного выполнения метода OnStart() до метода OnExecute().</remarks>
    event EventHandler Subscribe;

    /// <summary> Событие при остановке модуля, вызывается в модуле Runtime.</summary>
    /// <remarks> Вызывается после завершения метода OnExecute() до начала выполнения метода OnStop().</remarks>
    event EventHandler Unsubscribe;

    /// <summary> Уведомление о смене состояния модуля.</summary>
    event StatusChangedEventHandler StatusChanged;

    #endregion Runtime events
}

/// <summary> Признак автозапуска модуля при старте.</summary>
/// <remarks> Модуль запускается до старта обслуживания очереди сообщений.</remarks>
public interface IStartup
{ }

/// <summary> Интерфейс диагностики модуля.</summary>
public interface IDiagnostic
{
    /// <summary> Счётчик сообщений.</summary>
    long MessageCount { get; }
    /// <summary> Время выполнения процесса в милисекундах.</summary>
    long ElapsedMilliseconds { get; }
    /// <summary> Форматированное время выполнения [hh:mm:ss].</summary>
    string ExecTime { get; }
    /// <summary> Вывод статистики по указанному ИД процесса.</summary>
    void Statistics(StringBuilder output);
}

public delegate void StatusChangedEventHandler(IModule sender, RuntimeStatus status);