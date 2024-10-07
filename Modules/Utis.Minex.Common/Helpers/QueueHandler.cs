using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Utis.Minex.Common.Helpers
{
    #region Using
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Handlers;
    using Utis.Minex.Common.Interfaces;
    #endregion

    /// <summary>
    /// Представляет очередь асинхронной обработки списка элементов.
    /// </summary>
    /// <typeparam name="T">Тип элементов в списке.</typeparam>
    public class QueueHandler<T> : BaseHandler, IDisposable
    {
        #region Constructors

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов.
        /// </summary>
        private QueueHandler(Action<T> action, string queueHandlerName)
        {
            if (queueHandlerName.IsNullOrEmpty())
                throw new ArgumentException("Имя очереди не должно быть пустым!", nameof(queueHandlerName));

            _actionProcessItem = action;

            _handlerName = queueHandlerName;            
            _canBeLogged = true;
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов.
        /// </summary>
        public QueueHandler(Action<T> action, IServerInputOutput console, string queueHandlerName)
            : this(action, queueHandlerName)
        {
            _console = console;
            _safetyHandler = new(console, queueHandlerName, _queue);
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов.
        /// </summary>
        public QueueHandler(Action<T> action, IPureLogger logger, string queueHandlerName)
            : this(action, queueHandlerName)
        {
            _logger = logger;
            _safetyHandler = new(logger, queueHandlerName, _queue);
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов.
        /// </summary>
        public QueueHandler(Action<T> action, IServerInputOutput console, string queueHandlerName, ThreadPriority threadPriority)
            : this(action, console, queueHandlerName)
        {
            _threadPriority = threadPriority;
        }


        #endregion

        #region IDisposable

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                try
                {
                    _shouldStopAndClear = true;
                    _wakeEvent?.Set();

                    _task?.Wait();
                    _task?.Dispose();

                    _wakeEvent?.Dispose();
                    _safetyHandler?.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.WriteException(ex);
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~QueueHandler()
        {
            Dispose(false);
        }

        #endregion

        #region Queue

        private readonly ThreadPriority? _threadPriority = null;

        /// <summary>
        /// Внутренняя очередь.
        /// </summary>
        private readonly ConcurrentQueue<T> _queue = new();

        private readonly SafetyHandler _safetyHandler;

        private T _lastProcessItem;

        /// <summary>
        /// Пуста ли очередь.
        /// </summary>
        public bool IsEmpty => _queue.IsEmpty;

        /// <summary>
        /// Количество элементов в очереди.
        /// </summary>
        public int Count => _queue.Count;

        #endregion

        #region Task

        /// <summary>
        /// Задача обработки.
        /// </summary>
        private Task _task;
        private object _taskLock = new();

        /// <summary>
        /// Флаг остановки с разбором.
        /// </summary>
        private volatile bool _shouldStop = false;

        /// <summary>
        /// Флаг остановки без разбора очереди до конца.
        /// </summary>
        private volatile bool _shouldStopAndClear = false;

        /// <summary>
        /// Событие уведомляющее ожидающий поток о необходимости пробуждении.
        /// </summary>
        private readonly AutoResetEvent _wakeEvent
            = new(false);

        #endregion

        #region Add

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="item">Элемент.</param>
        public void Add(T item)
        {
            if (item != null)
            {
                if (_shouldStop || _shouldStopAndClear)
                {
                    WriteLog($"Попытка добавления в остановленную очередь '{_handlerName}'", LogMessageType.Debug);
                    return;
                }

                _queue.Enqueue(item);
                _wakeEvent.Set();
                RestartIfNeed();
            }
        }

        #endregion

        #region Start

        /// <summary>
        /// Запуск.
        /// </summary>
        public void Start(bool writeConsole = true)
        {
            if (writeConsole)
                WriteLog($"Очередь '{_handlerName}' - запуск");

            Stop(false);

            _shouldStop = false;
            _shouldStopAndClear = false;

            lock (_taskLock)
                StartTask();

            if (writeConsole)
                WriteLog($"Очередь '{_handlerName}' - запущена");
        }

        private void RestartIfNeed()
        {
            if (_shouldStopAndClear || _shouldStop)
                return;

            if (_task == null)
                lock (_taskLock)
                    if (_task == null)
                    {
                        StartTask();
                    }                        
        }

        private void StartTask()
        {
            WriteLog($"{_handlerName} start");
            if (_threadPriority.HasValue)
            {
                TaskScheduler tSheduler;
                switch (_threadPriority.Value)
                {
                    case ThreadPriority.Lowest:
                        tSheduler = PriorityScheduler.Lowest;
                        break;
                    case ThreadPriority.Normal:
                        tSheduler = PriorityScheduler.Normal;
                        break;
                    case ThreadPriority.Highest:
                        tSheduler = PriorityScheduler.Highest;
                        break;
                    case ThreadPriority.BelowNormal:
                        tSheduler = PriorityScheduler.BelowNormal;
                        break;
                    case ThreadPriority.AboveNormal:
                        tSheduler = PriorityScheduler.AboveNormal;
                        break;
                    default:
                        tSheduler = PriorityScheduler.Normal;
                        break;
                }
                _task = Task.Factory.StartNew(RoutineProcessItems, CancellationToken.None, TaskCreationOptions.LongRunning, tSheduler);
            }
            else
                _task = Task.Factory.StartNew(RoutineProcessItems, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        #endregion

        #region Stop

        /// <summary>
        /// Остановка с полным разбором очереди.
        /// </summary>
        public void Stop(bool writeConsole = true)
        {
            _shouldStop = true;
            _wakeEvent.Set();

            if (writeConsole)
            {
                while (_task?.Wait(1000) == false)
                {
                    WriteLog($"Очередь '{_handlerName}' - ожидание остановки,  осталось {_queue.Count} элементов, последний, взятый в работу: {_lastProcessItem?.ToString()}");
                }
            }
            else
            {
                _task?.Wait();
            }

            if (writeConsole)
            {
                WriteLog($"Очередь '{_handlerName}' - остановлена");
            }
        }

        #endregion

        #region Clear

        /// <summary>
        /// Очистить очередь не дожидаясь её разбора.
        /// </summary>
        public void Clear(bool writeConsole = true)
        {
            _shouldStopAndClear = true;
            _wakeEvent.Set();
            while (_task?.Wait(1000) == false)
            {
                if (writeConsole)
                    WriteLog($"Очередь '{_handlerName}' - ожидание очистки");
            }
            _queue.Clear();

            if (writeConsole)
                WriteLog($"Очередь '{_handlerName}' - очищена");
        }

        #endregion

        #region RoutineProcessItems

        /// <summary>
        /// Обработка элементов в очереди.
        /// </summary>
        private void RoutineProcessItems()
        {
            while (!_shouldStop || !_queue.IsEmpty)
            {
                if (_shouldStopAndClear)
                {
                    break;
                }

                if (!_queue.IsEmpty)
                {
                    Interlocked.Exchange(ref _loopsWithEmptyQueue, 0);

                    int notifyCount = 0;
                    long totalProcess = 0;
                    DateTime lastNotify = DateTime.Now;
                    while (_queue.TryDequeue(out var item) && !_shouldStopAndClear)
                    {
                        if (notifyCount > 999)
                        {
                            var periodInSeconds = Math.Round((DateTime.Now - lastNotify).TotalSeconds, 3);
                            WriteLog($"В очереди ещё '{_handlerName}' - '{_queue.Count}' элементов; Обработано без остановки '{totalProcess}' элементов за {periodInSeconds} с", LogMessageType.Debug);
                            notifyCount = 0;
                            lastNotify = DateTime.Now;
                        }
                        _lastProcessItem = item;
                        _safetyHandler.SetActionStart(item);
                        TryCatchLog(() =>
                        {
                            _actionProcessItem?.Invoke(item);
                        });
                        _safetyHandler.SetActionEnd(item);
                        notifyCount++;
                        totalProcess++;
                    }
                }
                else
                {
                    var loops = Interlocked.Increment(ref _loopsWithEmptyQueue);
                    if (loops >= 10)
                    {
                        lock (_taskLock)
                            _task = null;

                        WriteLog($"{_handlerName} pause");
                        return;
                    }

                    _wakeEvent.WaitOne(500);
                }
            }
        }

        private volatile int _loopsWithEmptyQueue = 0;

        /// <summary>
        /// Пользовательский обработчик элемента извлеченного из очереди.
        /// </summary>
        private readonly Action<T> _actionProcessItem;

        #endregion
    }
}