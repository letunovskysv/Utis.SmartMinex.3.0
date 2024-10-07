//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TaskManager – Сервис управления модулями (микросервисами).
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Сервис управления модулями (микросервисами).</summary>
sealed class TaskManager : SmartModule, IStartup
{
    #region Declarations

    readonly RuntimeService _rtm;
    /// <summary> Признак наличия базы данных.</summary>
    readonly bool _hasdb = true;

    /// <summary> Конфигурация модулей из файла runtimeconfig.template.json.</summary>
    /// <remarks> Определение модулей содержится в файле конфигурации *.runtimeconfig.json..</remarks>
    readonly ConcurrentDictionary<long, TModule> _startlist= [];

    #endregion Declarations

    public TaskManager(IRuntime runtime) : base(runtime)
    {
        Messages = [MSG.Started, MSG.InstallModule, MSG.UninstallModule, MSG.RunModule, MSG.Start, MSG.Stop, MSG.MetadataLoaded,
            MSG.Log, MSG.InformMessage, MSG.WarningMessage, MSG.ErrorMessage];

        Name = "Диспетчер задач";
        _rtm = (RuntimeService)runtime;

        _rtm.Objects.Select<TModule>()
            .Where(mi => mi.ModuleType != null && mi.Start == RuntimeStartMode.Auto && !mi.ModuleType.GetInterfaces().Contains(typeof(IStartup)))
            .OrderBy(mi => mi.Ordinal).ToList().ForEach(m => _startlist.TryAdd(m.Id, m));
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.RunModule:
                {
                    var modtype = m.Data is Type t1 ? t1 : m.Data is object?[] args && args.Length > 0 && args[0] is Type t2 ? t2 : null;
                    if (modtype != null && modtype.GetInterfaces().Contains(typeof(IModule)))
                        await _rtm.StartModule(modtype, false, m.Data is object?[] prms && prms.Length > 1 ? prms[1..] : null);
                }
                break;

            case MSG.Started: // Запустим все необходимые модули из конфигурационного файла -->
                await RunModules(stoppingToken);
                if (!_hasdb) Runtime.Send(MSG.Completed, ProcessId);
                break;

            case MSG.InstallModule:
            case MSG.UninstallModule:
            case MSG.Start:
            case MSG.Stop:
                break;

            case MSG.MetadataLoaded: // Запустим все необходимые модули из БД -->
                if (m.Data is TNode node)
                {
                    _rtm.Code = node.Code;
                    _rtm.Name = node.Name;
                }
                _rtm.Objects.Where<TModule>(m => m.FromDatabase && m.Start == RuntimeStartMode.Auto).ForEach(m => _startlist.TryAdd(m.Id, m));
                await RunModules(stoppingToken);
                Runtime.Send(MSG.Completed, ProcessId);
                break;

            case MSG.Log:
                Log((int)m.LParam, (LogLevel)m.HParam, m.Data);
                break;

            case MSG.InformMessage:
                Log((int)m.LParam, LogLevel.Information, m.Data);
                break;

            case MSG.WarningMessage:
                Log((int)m.LParam, LogLevel.Warning, m.Data);
                break;

            case MSG.ErrorMessage:
                Log((int)m.LParam, LogLevel.Error, m.Data);
                break;
        }
    }

    async Task RunModules(CancellationToken stoppingToken)
    {
        int cnt = 0;
        int attempt = 10;
        while (--attempt > 0 && _startlist.Count > 0)
        {
            foreach (var info in _startlist.Values.ToList())
            {
                cnt++;
                var awaiter = _rtm.StartModule(info.ModuleType, info, attempt == 1).ConfigureAwait(false).GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    cnt--;
                    if (awaiter.GetResult())
                        _startlist.TryRemove(info.Id, out _);
                });
            }
            int timeout = 300; // 15 сек, максимальное время ожидания запуска модулей
            while (timeout-- > 0 && cnt > 0) await Task.Delay(50, stoppingToken);
        }
    }

    void Log(int pid, LogLevel level, object? data)
    {
        if (data is Exception ex)
            _rtm.GetLogger(pid).Log(level, ex, string.Empty);
        else
            _rtm.GetLogger(pid).Log(level, data?.ToString());
    }
}
