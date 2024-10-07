//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ModuleBase – Базовый модуль.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public delegate void ProcessMessageEventHandler(TMessage m);

/// <summary> Базовый модуль.</summary>
public abstract class SmartModule : IModule, IDiagnostic, IDisposable
{
    #region Declarations

    protected readonly IRuntime Runtime;
    /// <summary> Признак принудительного выполнения цикла.</summary>
    protected bool ForcedLoop = false;

    /// <summary> Внутренняя  системная шина.</summary>
    readonly ConcurrentQueue<TMessage> _esb = new();
    readonly AutoResetEvent _sync = new(false);
    readonly Stopwatch _elapsed = new();
    volatile RuntimeStatus _status = RuntimeStatus.None;
    long _cycle;
    bool _disposed = false;

    public int[] Messages { get; set; } = [];

    public event EventHandler Subscribe;
    public event EventHandler Unsubscribe;
    public event StatusChangedEventHandler StatusChanged;

    #endregion Declarations

    #region Properties

    public long Id { get; set; }
    public int ProcessId { get; set; }
    public string Name { get; set; } = default!;

    public RuntimeStatus Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                Task.Run(() => StatusChanged?.Invoke(this, value));
            }
        }
    }

    /// <summary> Последняя ошибка.</summary>
    public Exception? LastError { get; set; }

    #endregion Properties

    #region IDiagnostic implementation

    public long MessageCount { get; private set; }

    public long ElapsedMilliseconds => _elapsed.ElapsedMilliseconds;

    public string ExecTime => _elapsed.Elapsed.ToString("hh\\:mm\\:ss");

    public void Statistics(StringBuilder output) => throw new NotImplementedException();

    #endregion IDiagnostic implementation

    #region Constructor

    public SmartModule(IRuntime runtime)
    {
        Runtime = runtime;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) // Освобождаем управляемые ресурсы -->
        {            
        }
        _disposed = true;
    }

    ~SmartModule() => Dispose(false);

    #endregion Constructor

    #region IRuntime methods

    public void ProcessMessage(TMessage m)
    {
        if ((Status & RuntimeStatus.Loop) > 0)
        {
            _esb.Enqueue(m);
            _sync.Set();
        }
    }

    public Task StartProcess(CancellationToken stoppingToken) => Task.Run(() =>
    {
        _elapsed.Start();
        Status = RuntimeStatus.Starting;
        var success = false;
        try
        {
            success = OnStart();
        }
        catch (Exception ex)
        {
            Runtime.Send(MSG.ErrorMessage, ProcessId, 0, new RuntimeException(this, "Ошибка запуска модуля «" + Name + "»: ", ex));
        }
        if (success)
            Subscribe?.Invoke(this, EventArgs.Empty);
        else
            Status = RuntimeStatus.Stopped;

        _elapsed.Stop();
    }, stoppingToken);

    public Task StopProcess(CancellationToken stoppingToken) => Task.Run(() =>
    {
        Unsubscribe?.Invoke(this, EventArgs.Empty);
        OnStop();
        _sync.Dispose();
        Status = RuntimeStatus.Stopped;
        Dispose();
    }, stoppingToken);

    public virtual Task ExecuteProcessAsync(CancellationToken stoppingToken) => Task.Factory.StartNew(async () =>
    {
        var emptyMsg = new TMessage(MSG.None);
        Status = RuntimeStatus.Running;
        while ((ForcedLoop || _sync.WaitOne()) && (_status & RuntimeStatus.Loop) > 0)
        {
            _elapsed.Start();
            try
            {
                if (_esb.IsEmpty)
                    await OnExecuteAsync(emptyMsg, stoppingToken);
                else
                    while (_esb.TryDequeue(out TMessage m))
                    {
                        MessageCount++;
                        if (m.Msg == MSG.Kill)
                        {
                            if (m.LParam == ProcessId)
                                Status = RuntimeStatus.StopPending;
                        }                        else await OnExecuteAsync(m, stoppingToken);
                    }
            }
            catch (Exception ex)
            {
                Status |= RuntimeStatus.Failed;
                Runtime.Send(MSG.ErrorMessage, ProcessId, 0, ex);
            }
            _elapsed.Stop();
        }
        Status = RuntimeStatus.StopPending;
        await StopProcess(stoppingToken);
    }, stoppingToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

    public bool SetProperty(string propertyName, object value, out string message)
    {
        message = string.Empty;
        return false;
    }

    public void SendDirect(TMessage m)
    {
        _esb.Enqueue(m);
        _sync.Set();
    }

    /// <summary> Задержка процесса в миллисекундах с учётом затраченного на цикл времени.</summary>
    protected async Task DoEventsAsync(int msTimeout, CancellationToken stoppingToken)
    {
        msTimeout = Math.Max(50, msTimeout - (int)(_elapsed.ElapsedMilliseconds - _cycle));
        _elapsed.Stop();
        await Task.Delay(msTimeout, stoppingToken);
        _cycle = _elapsed.ElapsedMilliseconds;
        _elapsed.Start();
    }

    #endregion IRuntime methods

    #region Behavior

    /// <summary> Остановить модуль.</summary>
    public void Stop() => Status = RuntimeStatus.StopPending;

    public virtual bool OnStart() => true;

    public virtual Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken) => Task.CompletedTask;

    public virtual void OnStop() { }

    #endregion Behavior
}
