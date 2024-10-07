//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: RuntimeService – Среда выполнения системной платформы.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Utis.SmartMinex.Core.Runtime;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Сервис выполнения системной платформы.</summary>
public sealed class RuntimeService : IRuntime, IDiagnostic
{
    #region Declarations

    readonly ILogger _logger;
    readonly Stopwatch _elapsed = new();
    CancellationToken _cancelToken;
    int _processIdCount = 1;

    readonly IServiceProvider _services;
    /// <summary> Системная шина предприятия. Очередь сообщений.</summary>
    readonly ConcurrentQueue<TMessage> _esb = new();
    /// <summary> Системная шина предприятия. Менеджер расписаний.</summary>
    readonly RuntimeSchedule<TMessage> _schedule = new();
    /// <summary> Запущенные модули в системе. Диспетчер задач.</summary>
    readonly ConcurrentDictionary<int, IService> _modules = new();
    /// <summary> Диспетчер системной шины предприятия ESB.</summary>
    readonly ConcurrentDictionary<int, ProcessMessageEventHandler> _processes = new();
    /// <summary> Логирование модулей.</summary>
    readonly ConcurrentDictionary<int, ILogger> _loggers = [];

    #endregion Declarations

    #region Properties

    public long Id { get; set; }
    public int ProcessId { get; set; }
    public string Code { get; internal set; }
    public string Name { get; internal set; } = default!;
    public string Version { get; set; } = default!;
    public RuntimeStatus Status { get; set; }
    public DateTime Started { get; } = DateTime.Now;
    public string WorkingDirectory { get; }

    public ObjectCollection Objects { get; } = new ObjectCollection();
    public List<IModule> Modules => GetModules();

    #endregion Properties

    #region IDiagnostic implementation

    public long MessageCount { get; private set; }

    public long ElapsedMilliseconds => _elapsed.ElapsedMilliseconds;

    public string ExecTime => _elapsed.Elapsed.ToString("hh\\:mm\\:ss");

    public void Statistics(StringBuilder output) => throw new NotImplementedException();

    #endregion IDiagnostic implementation

    #region Constructors

    public RuntimeService(IServiceProvider services, ILogger<RuntimeService> logger, IConfiguration config)
    {
        _services = services;
        _logger = logger;
        var ver = Assembly.GetEntryAssembly().GetName().Version;
        Version = ver.ToString(ver.Revision == 0 ? 3 : 4);
        WorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        var cfg = config.GetRuntime();
        Code = cfg?["code"] ?? "001";
        Name = cfg?["name"] ?? "Среда выполнения системной платформы";

        Objects.AddRange(config.GetModules(WorkingDirectory)); // Конфигурация из файла runtimeconfig.template.json
    }

    #endregion Constructors

    #region Executing

    public async Task ExecuteAsync(CancellationToken tkn)
    {
        Status = RuntimeStatus.Starting;
        _cancelToken = tkn;

        _modules.TryAdd(1, this);
        foreach (var modtype in GetStartupModules())
            await StartModule(modtype, false);

        _schedule.Fire += (o, m) => Send(m);
        _schedule.Start();
        await Task.Delay(100, tkn);

        Status = RuntimeStatus.Running;
        Send(MSG.Started, ProcessId);

        while (!tkn.IsCancellationRequested && (Status & RuntimeStatus.Loop) > 0)
        {
            _elapsed.Start();
            while (!tkn.IsCancellationRequested && _esb.TryDequeue(out TMessage m) && _processes.TryGetValue(m.Msg, out var onExecuteAsync))
                onExecuteAsync?.Invoke(m);

            _elapsed.Stop();
            await Task.Delay(10, tkn);
        }
    }

    #endregion Executing

    #region Modules

    internal async Task<bool> StartModule(Type moduleType, TModule info, bool forced, params object?[]? args)
    {
        if (moduleType != null && TryAddSingleton(moduleType, info, forced, out var mod, args))
        {
            _loggers.TryAdd(mod.ProcessId, _services.GetService(typeof(ILogger<>).MakeGenericType(mod.GetType())) as ILogger);
            mod.Subscribe += OnSubscribe;
            mod.Unsubscribe += OnUnsubscribe;
            mod.StatusChanged += OnModuleStatusChanged;
            await mod.StartProcess(_cancelToken);
            return true;
        }
        return false;
    }

    internal async Task<bool> StartModule(Type moduleType, bool forced, params object?[]? args) =>
        await StartModule(moduleType, Objects.FirstOrDefault(oi => oi is TModule mi && mi.ModuleType != null && mi.ModuleType.Equals(moduleType)) as TModule, forced, args);

    internal void StoptModule(IModule? module)
    {
        if (module != null)
            Send(MSG.Kill, module.ProcessId);
    }

    internal void StoptModule(int idProcess) =>
        StoptModule(_modules.Values.FirstOrDefault(m => m is IModule && m.ProcessId == idProcess) as IModule);

    /// <summary> Возвращает список типов обязательных модулей автоматически запускаемых при старте Системы до запуска системной шины.</summary>
    /// <remarks> Данные классы содержат интерфейс IStartup.</remarks>
    List<Type> GetStartupModules() =>
        Assembly.GetExecutingAssembly().GetTypes()
            .Where(mt => mt.GetInterfaces().Contains(typeof(IStartup))
                && (Objects.FirstOrDefault(oi => oi is TModule mi && mi.ModuleType != null && mi.ModuleType.Equals(mt)) is not TModule mi || mi.Start == RuntimeStartMode.Auto)
                && mt.GetInterfaces().Contains(typeof(IModule))).ToList();

    /// <summary> Create & start of the module instance once.</summary>
    bool TryAddSingleton(Type moduleType, TModule? info, bool forced, out IModule module, params object?[]? args)
    {
        try
        {
            var parameters = moduleType.GetConstructors().First().GetParameters();
            var prms = new object[parameters.Length];
            int n = 0;
            for (int i = 0; i < prms.Length; i++)
            {
                var prm = parameters[i];
                var nullable = prm.CustomAttributes.FirstOrDefault() is CustomAttributeData ca
                    && ca.AttributeType == typeof(System.Runtime.CompilerServices.NullableAttribute)
                    && ca.ConstructorArguments[0].Value.Equals((byte)2);

                var injectionType = GetService(prm.ParameterType);
                if (injectionType == null)
                {
                    var ptype = prm.ParameterType;
                    if (ptype.IsInterface && forced)
                        prms[i] = default!;
                    else
                    {
                        object? pval = info?.Parameters?.FirstOrDefault(p => p.Key.Equals(prm.Name, StringComparison.OrdinalIgnoreCase)).Value;
                        if (ptype.IsClass && pval != null && pval.ToString().StartsWith('{')) // JSON value
                            pval = JsonConvert.DeserializeObject(pval.ToString(), ptype);
                        else if (ptype == typeof(bool))
                            pval = bool.TryParse(pval?.ToString(), out var valb) && valb;

                        prms[i] = (args.Length > n && ptype == args[n].GetType())
                            ? args[n]
                            : (pval != null)
                                ? (ptype.IsEnum && Enum.TryParse(ptype, pval.ToString(), true, out object enumval))
                                    ? enumval
                                    : ptype == typeof(int?) && pval is string ? int.Parse(pval.ToString()) : pval
                             : ptype.Equals(typeof(string))
                                ? default(string)
                                : Activator.CreateInstance(ptype);
                    }
                    n++;
                }
                else prms[i] = injectionType;
            }
            if (Activator.CreateInstance(moduleType, prms) is IModule mod)
            {
                module = mod;
                module.Name ??= info?.Name ?? mod.GetType().FullName ?? mod.GetType().Name;
                module.ProcessId = ++_processIdCount;
                _modules.TryAdd(module.ProcessId, module);
                return true;
            }
        }
        catch { }
        module = default!;
        return false;
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    object? GetService(Type serviceType) =>
    _modules.Values.FirstOrDefault(s => s.GetType().Equals(serviceType) || s.GetType().GetInterfaces().Contains(serviceType))
        ?? _services.GetService(serviceType);

    /// <summary> Возвращает модуль по ИД процесса./summary>
    internal IModule? GetModule(int idProcess) =>
        _modules.Values.FirstOrDefault(m => m is IModule && m.ProcessId == idProcess) as IModule;

    List<IModule> GetModules() =>
        _modules.Values.Where(m => m is IModule).Select(m => (IModule)m).ToList();

    #endregion Modules

    #region Events

    /// <summary> Выполняется, когда модуль создан и выполнена инициализация модуля, отработал метод Start().</summary>
    void OnSubscribe(object? sender, EventArgs e)
    {
        if (sender is IModule mod)
        {
            _processes.AddOrUpdate(MSG.Kill, mod.ProcessMessage, (_, e) => e += mod.ProcessMessage); // Это сообщение для всех подключаемых модулей
            mod.Messages.ToList().ForEach(msg => _processes.AddOrUpdate(msg, mod.ProcessMessage, (_, e) => e += mod.ProcessMessage));
            mod.ExecuteProcessAsync(_cancelToken);
        }
    }

    /// <summary> Выполняется, когда модуль остановлен, до вызова метода Stop().</summary>
    void OnUnsubscribe(object? sender, EventArgs e)
    {
        if (sender is IModule mod)
        {
            _processes[MSG.Kill] -= mod.ProcessMessage;
            mod.Messages.ToList().ForEach(msg => _processes[msg] -= mod.ProcessMessage);
            _modules.Remove(mod.ProcessId, out _);
            _loggers.TryRemove(mod.ProcessId, out _);

            mod.Subscribe -= OnSubscribe;
            mod.Unsubscribe -= OnUnsubscribe;
        }
    }

    void OnModuleStatusChanged(IModule module, RuntimeStatus status)
    {
        switch (status)
        {
            case RuntimeStatus.Starting:
            case RuntimeStatus.Running:
            case RuntimeStatus.StopPending:
            case RuntimeStatus.Pause:
            case RuntimeStatus.Failed:
                GetLogger(module.ProcessId).LogInformation($"{status}[{module.ProcessId}]: {module.Name}");
                break;

            case RuntimeStatus.Stopped:
                GetLogger(module.ProcessId).LogInformation($"{status}[{module.ProcessId}]: {module.Name}");
                module.StatusChanged -= OnModuleStatusChanged;
                break;

            default:
                GetLogger(module.ProcessId).LogInformation($"Unknown{status}[{module.ProcessId}]: {module.Name}");
                break;
        }
    }

    internal ILogger GetLogger(int idProcess) =>
        _loggers.TryGetValue(idProcess, out var logger) ? logger : _logger;

    #endregion Events

    #region ESB Messages

    public void Send(TMessage m)
    {
        ++MessageCount;
        _esb.Enqueue(m);
    }

    // Common messages

    public void Send(int type) =>
        Send(type, 0, 0, null);

    public void Send(int type, long lparam) =>
        Send(type, lparam, 0, null);

    public void Send(int type, long lparam, long hparam) =>
        Send(type, lparam, hparam, null);

    public void Send(int type, long lparam, long hparam, object? data) =>
        Send(new TMessage(type, lparam, hparam, data));

    public void Send(int type, long lparam, long hparam, params object?[]? data) =>
        Send(new TMessage(type, lparam, hparam, data));

    // Schedule messages

    int Send(TMessage m, ScheduleOptions pars)
    {
        if (_schedule.Add(m, pars) is int idSchedule)
            return idSchedule;

        Send(m);
        return 0;
    }

    public int Schedule(TMessage m, long delay) =>
        Send(m, new ScheduleOptions { InitialDelay = delay });

    public int Schedule(TMessage m, long delay, long period) =>
        Send(m, new ScheduleOptions { InitialDelay = delay, Period = period });

    public int Schedule(TMessage m, DateTime dateTime) =>
        Send(m, new ScheduleOptions { DateTime = dateTime });

    public int Schedule(int type, long lparam, long hparam, object? data, long delay) =>
        Send(new TMessage(type, lparam, hparam, data), new ScheduleOptions { InitialDelay = delay });

    public int Schedule(int type, long lparam, long hparam, object? data, long delay, long period) =>
        Send(new TMessage(type, lparam, hparam, data), new ScheduleOptions { InitialDelay = delay, Period = period });

    public int Schedule(int type, long lparam, long hparam, object? data, DateTime dateTime) =>
        Send(new TMessage(type, lparam, hparam, data), new ScheduleOptions { DateTime = dateTime });

    public bool RemoveTask(int id) =>
        _schedule.Remove(id);

    public bool ResetTask(int id) =>
        _schedule.Reset(id);

    public bool Modify(int id, TMessage m, long delay) =>
        _schedule.Modify(id, m, new ScheduleOptions { InitialDelay = delay });

    public bool Modify(int id, TMessage m, long delay, long period) =>
        _schedule.Modify(id, m, new ScheduleOptions { InitialDelay = delay, Period = period });

    public bool Modify(int id, TMessage m, DateTime dateTime) =>
        _schedule.Modify(id, m, new ScheduleOptions { DateTime = dateTime });

    #endregion ESB Messages
}
