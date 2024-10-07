//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IRuntime – Среда выполнения конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel;
using System.Reflection;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public interface IRuntime : IService
{
    #region Properties

    string Code { get; }
    string Name { get; }
    string Version { get; }
    /// <summary> Дата/Время запуска сервера приложений.</summary>
    DateTime Started { get; }
    string WorkingDirectory { get; }

    #endregion Properties

    #region Messages

    void Send(TMessage m);
    void Send(int type);
    void Send(int type, long lparam);
    void Send(int type, long lparam, long hparam);
    void Send(int type, long lparam, long hparam, object? data);
    void Send(int type, long lparam, long hparam, params object?[]? data);

    /// <summary> Отправить сообщение с задержкой DELAY миллисекунд и периодом.</summary>
    int Schedule(int type, long lparam, long hparam, object? data, long delay, long period);
    int Schedule(int type, long lparam, long hparam, object? data, DateTime dateTime);

    /// <summary> Удалить задание.</summary>
    bool RemoveTask(int id);
    /// <summary> Сбросить задание.</summary>
    bool ResetTask(int id);
    bool Modify(int id, TMessage m, long delay);
    bool Modify(int id, TMessage m, long delay, long period);
    bool Modify(int id, TMessage m, DateTime dateTime);

    /// <summary> Отправить сообщение с задержкой DELAY миллисекунд.</summary>
    int Schedule(TMessage m, long delay);
    int Schedule(TMessage m, long delay, long period);
    int Schedule(TMessage m, DateTime dateTime);

    #endregion Messages
}

[Flags]
public enum RuntimeStatus
{
    [Description("Не установлен")]
    None = 0,
    [Description("Остановлена")]
    Stopped = 1,
    [Description("Попытка остановки")]
    StopPending = 2,
    [Description("Выполняется")]
    Running = 4,
    [Description("Попытка запуска")]
    Starting = 8,
    [Description("Приостановлена")]
    Pause = 16,
    [Description("Сервисный режим")]
    Service = 32,
    [Description("Ошибка выполнения")]
    Failed = 64,

    Loop = Running | Failed | Service
}

public static class RuntimeExtensions
{
    public static T SuppressException<T>(this object _, Func<T> invoke)
    {
        try
        {
            return invoke();
        }
        catch
        {
            return default!;
        }
    }

    /// <summary> Возвращает типы с указанным аттрибутом.</summary>
    public static List<Type> GetTypes<T>(this object _) where T : Attribute
    {
        var tkn = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
        return Assembly.GetExecutingAssembly()
            .GetReferencedAssemblies()
            .Where(a => a.GetPublicKeyToken()?.Where((n, i) => tkn[i] == n).Count() == tkn.Length)
            .SelectMany(a => Assembly.Load(a).GetTypes())
            .Concat(Assembly.GetExecutingAssembly().GetTypes())
            .Where(t => t.IsDefined(typeof(T), false)).ToList();
    }
}
