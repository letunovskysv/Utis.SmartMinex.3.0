using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Utis.Minex.Common.Handlers
{
    #region Using

    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

    #endregion

    #region UsingAlias

    using Timer = System.Timers.Timer;

    #endregion

    public class StackConcurrentHandler<T> : BaseHandler, IDisposable
    {
        #region Constructors

        /// <summary>
        /// Инициализирует очередь асинхронной обработки стэка элементов.
        /// </summary>
        /// <param name="checkTimeout">время периода проверки таймаута истечения от последнего добавления в стэк</param>
        /// <param name="lastAddTimeout">время от последнего добавления в стэк, после которого будет разобран элемент, в миллисекундах</param>
        private StackConcurrentHandler(
            string stackHandlerName,
            StackHandlerType stackHandlerType = StackHandlerType.Pop,
            int checkTimeout = 0,
            int lastAddTimeout = 0
            )
        {
            _handlerName = stackHandlerName;
            _stackHandlerType = stackHandlerType;
            
            if (checkTimeout > 0 && lastAddTimeout > 0)
            {
                _lastAddTimeout = lastAddTimeout;
                _lastAddStopwatch = new Stopwatch();
                _addTimeChecker = new Timer(checkTimeout)
                {
                    AutoReset = false
                };
                _addTimeChecker.Elapsed += (_, _) =>
                {
                    lock (_stopwatchLock)
                    {
                        if (_lastAddStopwatch.ElapsedMilliseconds > _lastAddTimeout)
                        {
                            _lastAddStopwatch.Reset();
                            _wakeEvent.Set();
                        }
                        else
                        {
                            _addTimeChecker.Start();
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки стэка элементов.
        /// </summary>
        /// <param name="checkTimeout">время периода проверки таймаута истечения от последнего добавления в стэк</param>
        /// <param name="lastAddTimeout">время от последнего добавления в стэк, после которого будет разобран элемент, в миллисекундах</param>
        public StackConcurrentHandler(
            IServerInputOutput console,
            string stackHandlerName,
            StackHandlerType stackHandlerType = StackHandlerType.Pop,
            int checkTimeout = 0,
            int lastAddTimeout = 0
            ) : this(stackHandlerName, stackHandlerType, checkTimeout, lastAddTimeout)
        {
            _console = console;
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки стэка элементов.
        /// </summary>
        /// <param name="checkTimeout">время периода проверки таймаута истечения от последнего добавления в стэк</param>
        /// <param name="lastAddTimeout">время от последнего добавления в стэк, после которого будет разобран элемент, в миллисекундах</param>
        public StackConcurrentHandler(
            IPureLogger logger,
            string stackHandlerName,
            StackHandlerType stackHandlerType = StackHandlerType.Pop,
            int checkTimeout = 0,
            int lastAddTimeout = 0
            ) : this(stackHandlerName, stackHandlerType, checkTimeout, lastAddTimeout)
        {
            _logger = logger;
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
                    _addTimeChecker?.Dispose();
                    _wakeEvent?.Dispose();
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

        ~StackConcurrentHandler()
        {
            Dispose(false);
        }

        #endregion

        private readonly StackHandlerType _stackHandlerType;
        private readonly int _lastAddTimeout;
        private readonly object _stopwatchLock = new();

        /// <summary>
        /// Внутренняя очередь.
        /// </summary>
        private readonly ConcurrentStack<T> _stack = new();

        /// <summary>
        /// Задача обработки.
        /// </summary>
        private Task _task { get; set; }

        /// <summary>
        /// Флаг остановки с разбором.
        /// </summary>
        private volatile bool _shouldStop;

        /// <summary>
        /// Флаг остановки без разбора очереди до конца.
        /// </summary>
        private volatile bool _shouldStopAndClear;

        /// <summary>
        /// Событие уведомляющее ожидающий поток о необходимости пробуждении.
        /// </summary>
        private readonly AutoResetEvent _wakeEvent = new(false);
        private readonly Timer _addTimeChecker;
        private readonly Stopwatch _lastAddStopwatch;

        /// <summary>
        /// Текущее количество элементов в стэке.
        /// </summary>
        public int Count => _stack.Count;

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        public void Push(T item)
        {
            if (_shouldStop || _shouldStopAndClear)
            {
                WriteLog($"Добавление в остановленный стэк '{_handlerName}'", LogMessageType.Warning);
            }

            TryCatchLog(() =>
            {              
                switch (_stackHandlerType)
                {
                    case StackHandlerType.PopAndClearNotAdd:
                    {
                        lock (_stopwatchLock)
                        {
                            if (!_lastAddStopwatch.IsRunning)
                            {
                                _stack.Push(item);
                            }
                        }
                        break;
                    }

                    default:
                    {
                        _stack.Push(item);
                        break;
                    }
                }

                SetOrStartTimer();
            });
        }

        /// <summary>
        /// Добавление элементов.
        /// </summary>
        public void PushRange(T[] items)
        {
            if (_shouldStop || _shouldStopAndClear)
            {
                WriteLog($"Добавление в остановленный стэк '{_handlerName}'", LogMessageType.Warning);
            }

            TryCatchLog(() =>
            {
                if (items.Any())
                {
                    switch (_stackHandlerType)
                    {
                        case StackHandlerType.PopAndClearNotAdd:
                        {
                            lock (_stopwatchLock)
                            {
                                if (!_lastAddStopwatch.IsRunning)
                                {
                                    _stack.PushRange(items);
                                }
                            }

                            break;
                        }

                        default:
                        {
                            _stack.PushRange(items);
                            break;
                        }
                    }

                    SetOrStartTimer();
                }
            });
        }

        /// <summary>
        /// Добавление элементов.
        /// </summary>
        public void PushRange(T[] items, int startIndex, int count)
        {
            if (_shouldStop || _shouldStopAndClear)
            {
                WriteLog($"Добавление в остановленный стэк '{_handlerName}'", LogMessageType.Warning);
            }

            TryCatchLog(() =>
            {
                if (items.Any())
                {
                    switch (_stackHandlerType)
                    {
                        case StackHandlerType.PopAndClearNotAdd:
                        {
                            lock (_stopwatchLock)
                            {
                                if (!_lastAddStopwatch.IsRunning)
                                {
                                    _stack.PushRange(items, startIndex, count);
                                }
                            }
                            break;
                        }

                        default:
                        {
                            _stack.PushRange(items, startIndex, count);
                            break;
                        }
                    }

                    SetOrStartTimer();
                }
            });
        }

        private void SetOrStartTimer()
        {
            if (_lastAddStopwatch == null)
            {
                _wakeEvent.Set();
            }
            else
            {
                lock (_stopwatchLock)
                {
                    _lastAddStopwatch.Restart();
                    _addTimeChecker.Start();
                }
            }
        }

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
            _task = Task.Factory.StartNew(RoutineProcessItems, TaskCreationOptions.LongRunning);

            if (writeConsole)
                WriteLog($"Очередь '{_handlerName}' - запущена");
        }

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
                    WriteLog($"Очередь '{_handlerName}' - ожидание остановки,  осталось {_stack.Count} элементов");
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
                    WriteLog($"Стэк '{_handlerName}' - ожидание очистки");
            }

            while (!_stack.IsEmpty)
                _stack.Clear();

            if (writeConsole)
                WriteLog($"Стэк '{_handlerName}' - очищен");
        }

        #region RoutineProcessItems

        /// <summary>
        /// Обработка элементов в очереди.
        /// </summary>
        private void RoutineProcessItems()
        {
            while (!_shouldStop || !_stack.IsEmpty)
            {
                if (_shouldStopAndClear)
                {
                    break;
                }

                if (!_stack.IsEmpty)
                {
                    while (_stack.TryPop(out var item) && !_shouldStopAndClear)
                    {
                        if (_stackHandlerType == StackHandlerType.PopAndClear)
                        {
                            _stack.Clear();
                        }

                        TryCatchLog(() =>
                        {
                            EvItemDequeued?.Invoke(item);
                        });
                    }
                }
                else
                {
                    _wakeEvent.WaitOne();
                }
            }
        }

        #endregion

        #region EvItemDequeued

        /// <summary>
        /// Уведомляет об извлечении элемента из стека.
        /// </summary> 
        public event Action<T> EvItemDequeued;

        #endregion
    }
}