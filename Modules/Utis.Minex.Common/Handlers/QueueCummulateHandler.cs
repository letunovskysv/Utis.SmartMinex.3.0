using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Utis.Minex.Common.Handlers
{
    #region Using
    
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

        #endregion

    /// <summary>
    /// Представляет очередь что накапливает элементы и асинхронно обрабатывает результирующий список через интервалы времени
    /// </summary>
    /// <typeparam name="T">Тип элементов в списке.</typeparam>
    public class QueueCummulateHandler<T> : BaseHandler, IDisposable
    {
        #region UsefulConstants 

        private const int InfiniteItems = -1;

        #endregion

        #region Constructors

        /// <summary>
        /// Инициализирует очередь что накапливает элементы и асинхронно обрабатывает результирующий список через интервалы времени
        /// </summary>
        /// <param name="intervalMs">период запуска сбора очереди в список</param>
        /// <param name="maxAccumulateTime">максимально время которое собирать список</param>
        public QueueCummulateHandler(
            Action<List<T>> action,
            int intervalMs,
            int maxAccumulateTime,
            int maxAccumulateItems = -1,
            bool canBeLogged = false
            )
        {
            IntervalMs = intervalMs;

            _maxAccumulateTime  = maxAccumulateTime;
            _maxAccumulateItems = maxAccumulateItems;
            
            _action = action;
            _canBeLogged = canBeLogged;

            return;
        }

        /// <summary>
        /// Инициализирует очередь что накапливает элементы и асинхронно обрабатывает результирующий список через интервалы времени
        /// </summary>
        /// <param name="intervalMs">период запуска сбора очереди в список</param>
        /// <param name="maxAccumulateTime">максимально время которое собирать список</param>
        private QueueCummulateHandler(
            Action<List<T>> action,
            string queueHandlerName,
            int intervalMs,
            int maxAccumulateTime,
            bool canBeLogged,
            int maxAccumulateItems = -1
        )
            : this(action, intervalMs, maxAccumulateTime, maxAccumulateItems, canBeLogged)
        {
            _queueHandlerName = queueHandlerName;
            return;
        }

        /// <summary>
        /// Инициализирует очередь что накапливает элементы и асинхронно обрабатывает результирующий список через интервалы времени
        /// </summary>
        /// <param name="intervalMs">период запуска сбора очереди в список</param>
        /// <param name="maxAccumulateTime">максимально время которое собирать список</param>
        public QueueCummulateHandler(
            Action<List<T>> action,
            IServerInputOutput console,
            int intervalMs,
            int maxAccumulateTime,
            string queueHandlerName,
            int maxAccumulateItems = -1
            )
            : this(action, queueHandlerName, intervalMs, maxAccumulateTime, true, maxAccumulateItems)
        {
            _console = console;
            return;
        }

        /// <summary>
        /// Инициализирует очередь что накапливает элементы и асинхронно обрабатывает результирующий список через интервалы времени
        /// </summary>
        /// <param name="intervalMs">период запуска сбора очереди в список</param>
        /// <param name="maxAccumulateTime">максимально время которое собирать список</param>
        public QueueCummulateHandler(
            Action<List<T>> action,
            IPureLogger logger,
            int intervalMs,
            int maxAccumulateTime,
            string queueHandlerName,
            int maxAccumulateItems = -1
            )
            : this(action, queueHandlerName, intervalMs, maxAccumulateTime, true, maxAccumulateItems)
        {
            _logger = logger;
            return;
        }

        private static readonly Stopwatch _sw 
            = Stopwatch.StartNew();

        private static readonly ManualResetEvent _mre 
            = new ManualResetEvent(false);

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

        ~QueueCummulateHandler()
        {
            Dispose(false);
        }

        #endregion

        #region Queue

        private readonly string _queueHandlerName;
        private readonly int _maxAccumulateTime;
        private readonly int _maxAccumulateItems;

        private int intervalMs;

        public int IntervalMs 
        { 
            get => intervalMs; 
            set => intervalMs = value > 0 ? value : 0; 
        }

        /// <summary>
        /// Внутренняя очередь.
        /// </summary>
        private readonly ConcurrentQueue<T> _queue = new();

        #endregion

        #region IsEmpty

        /// <summary>
        /// Пуста ли очередь.
        /// </summary>
        public bool IsEmpty => _queue.IsEmpty;

        #endregion

        #region Task

        /// <summary>
        /// Задача обработки.
        /// </summary>
        private Task _task { get; set; }

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
        private readonly AutoResetEvent _wakeEvent = new(false);

        #endregion

        #region Count

        /// <summary>
        /// Текущее количество элементов в очереди.
        /// </summary>
        public int Count => _queue.Count;

        #endregion

        #region Enqueue

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
                    WriteLog($"Добавление в остановленную очередь '{_queueHandlerName}'", LogMessageType.Warning);
                }

                _queue.Enqueue(item);
                _wakeEvent.Set();
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
                WriteLog($"Очередь '{_queueHandlerName}' - запуск");

            Stop(false);

            _shouldStop = false;
            _shouldStopAndClear = false;
            _task = Task.Factory.StartNew(RoutineProcessItems, TaskCreationOptions.LongRunning);

            if (writeConsole)
                WriteLog($"Очередь '{_queueHandlerName}' - запущена");
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
                    WriteLog($"Очередь '{_queueHandlerName}' - ожидание остановки,  осталось {_queue.Count} элементов");
                }
            }
            else
            {
                _task?.Wait();
            }

            if (writeConsole)
            {
                WriteLog($"Очередь '{_queueHandlerName}' - остановлена");
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
                    WriteLog($"Очередь '{_queueHandlerName}' - ожидание очистки");
            }

            _queue.Clear();

            if (writeConsole)
                WriteLog($"Очередь '{_queueHandlerName}' - очищена");
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
                if (_shouldStopAndClear) { break; }

                if (!_queue.IsEmpty)
                {
                    var begin = _sw.ElapsedMilliseconds;

                    var list = new List<T>();

                    var count = _queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (_shouldStopAndClear) { break; }

                        //копить не дольше maxAccumulateTime и не более maxAccumulateItems
                        if (_sw.ElapsedMilliseconds - begin >= _maxAccumulateTime) break;
                        if (_maxAccumulateItems != InfiniteItems && list.Count >= _maxAccumulateItems) break;

                        if (_queue.TryDequeue(out var item))
                            list.Add(item);
                    }

                    if (_shouldStopAndClear) { break; }

                    if (list.Count > 0)
                    TryCatchLog(() => _action?.Invoke(list));

                    if (_shouldStopAndClear) { break; }

                    if (_queue.IsEmpty)
                        _mre.WaitOne(intervalMs);
                }
                else
                {
                    _wakeEvent.WaitOne(100);
                }
            }
        }

        /// <summary>
        /// Пользовательский обработчик.
        /// </summary>
        private readonly Action<List<T>> _action;

        #endregion
    }
}