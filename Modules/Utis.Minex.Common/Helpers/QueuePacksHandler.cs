using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Utis.Minex.Common.Helpers
{
    #region Using
    
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

        #endregion

    /// <summary>
    /// Представляет очередь асинхронной обработки списка элементов по группам через некоторый интервал времени.
    /// </summary>
    /// <typeparam name="T">Тип элементов в списке.</typeparam>
    public class QueuePacksHandler<T>
    {
        #region Fields

        private readonly string _queueHandlerName;

        private readonly IServerInputOutput _console;
        private readonly IPureLogger _logger;

        /// <summary>
        /// Пользовательский обработчик пачки событий.
        /// </summary>
        private readonly Action<List<T>> _action;

        /// <summary>
        /// Интервал, через который формируется и отправляется на обработку следующая пачка событий.
        /// </summary>
        private readonly int _intervalMs = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов по группам через некоторый интервал времени.
        /// </summary>
        public QueuePacksHandler(Action<List<T>> action, int intervalMs, IServerInputOutput console, string queueHandlerName)
        {
            _intervalMs = intervalMs;
            _action  = action;
            _console = console;
            _queueHandlerName = queueHandlerName;
        }

        /// <summary>
        /// Инициализирует очередь асинхронной обработки списка элементов по группам через некоторый интервал времени.
        /// </summary>
        public QueuePacksHandler(Action<List<T>> action, int intervalMs, IPureLogger logger, string queueHandlerName)
        {
            _intervalMs = intervalMs;
            _action = action;
            _logger = logger;
            _queueHandlerName = queueHandlerName;
        }

        private static readonly Stopwatch _sw
            = Stopwatch.StartNew();

        private static readonly ManualResetEvent _mre
            = new ManualResetEvent(false);

        #endregion

        #region Queue

        /// <summary>
        /// Внутренняя очередь.
        /// </summary>
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

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
        protected readonly AutoResetEvent _wakeEvent = new AutoResetEvent(false);

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
            _task = Task.Run(RoutineProcessItems);

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

            while (!_queue.IsEmpty)
                _queue.TryDequeue(out _);

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

                        //копить не дольше _intervalMs
                        if (_sw.ElapsedMilliseconds - begin >= _intervalMs) break;

                        if (_queue.TryDequeue(out var item))
                            list.Add(item);
                    }

                    if (_shouldStopAndClear) { break; }

                    try
                    {
                        if (list.Count > 0)
                        _action?.Invoke(list);
                    }
                    catch (Exception ex)
                    {
                        WriteLog(new Exception($"Ошибка обработчике {_queueHandlerName}", ex));
                    }

                    var rest = (int)(_sw.ElapsedMilliseconds - begin - _intervalMs);
                    if (rest > 0) _mre.WaitOne(rest);
                }
                else
                {
                    _wakeEvent.WaitOne();
                }
            }
        }

        private void WriteLog(string message, LogMessageType logMessageType = LogMessageType.Info)
        {
            _console?.WriteLine(message, logMessageType, onlyToFile: true);
            _logger?.WriteLine(message, logMessageType);
        }


        private void WriteLog(Exception ex)
        {
            _console?.WriteLine(ex);
            _logger?.WriteException(ex);
        }

        #endregion
    }
}