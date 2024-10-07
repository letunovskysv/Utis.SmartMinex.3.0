using System;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Utis.Minex.Common.Helpers
{
    #region Using

    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Handlers;
    using Utis.Minex.Common.Interfaces;

    #endregion

    /// <summary>
    /// Предназначен для слежением за разбором очереди, 
    /// пишет в лог сообщение если превышен интервал ожидания разбора.    
    /// </summary>
    public class SafetyHandler : BaseHandler, IDisposable   
    {        
        private volatile bool _onProcess = false;
        private double _lastProcesStartTime;
        private double _lastProcesEndTime;
        private object _lastProcessItem;

        private Timer _timerCheckingDequeuing;
        private Stopwatch _stopWatch;

        /// <summary>
        /// Внутренняя очередь.
        /// </summary>
        private ICollection _collection;

        /// <summary>
        /// Пуста ли очередь.
        /// </summary>
        private bool IsEmpty => _collection?.Count == 0;

        public SafetyHandler(
            IServerInputOutput console, 
            string queueHandlerName,
            ICollection collection
            )
            : this(queueHandlerName, collection)
        {
            _console = console;
        }

        public SafetyHandler(
            IPureLogger logger, 
            string queueHandlerName, 
            ICollection collection
            )
            : this(queueHandlerName, collection)
        {
            _logger = logger;
        }

        private SafetyHandler(string invokeHandlerName, ICollection collection)
        {
            if (invokeHandlerName.IsNullOrEmpty())
                throw new ArgumentException("Имя обработчика не должно быть пустым!", nameof(invokeHandlerName));

            _handlerName = invokeHandlerName;
            _collection  = collection;

            _canBeLogged = true;           

            _stopWatch = 
                Stopwatch.StartNew();

            InitTimerCheckingDequeuing();
        }

        private void InitTimerCheckingDequeuing()
        {
            //The time interval between check, in milliseconds.
            const int dueTime = 10000;
            const int period  = 10000;

            _timerCheckingDequeuing =
                new Timer(_ =>
                {
                    try
                    {
                        if (!IsEmpty || (IsEmpty && _onProcess))
                        {
                            var elapsedInside = _stopWatch.Elapsed.TotalSeconds - _lastProcesStartTime;
                            if (elapsedInside > 10 && _lastProcesEndTime < _lastProcesStartTime)
                            {
                                WriteLog(
                                    $"Обработка элемента внутри очереди '{_handlerName}' висит {elapsedInside:N} секунд! " +
                                    $"Начиная с: {DateTime.Now - TimeSpan.FromSeconds(elapsedInside)} " +
                                    $"Элемент: {_lastProcessItem?.ToString()}",
                                    LogMessageType.Debug
                                    );

                                WriteLog($"Число элементов в очереди [{_onProcess}][{_collection?.Count}]", logMessageType: LogMessageType.Debug);
                            }
                        }

                        if (!IsEmpty)
                        {
                            var elapsedOutside = _stopWatch.Elapsed.TotalSeconds - _lastProcesEndTime;
                            if (elapsedOutside > 10 && _lastProcesEndTime > _lastProcesStartTime)
                            {
                                WriteLog(
                                    $"Обработка в '{_handlerName}' висит, новый объект не берется из очереди уже {elapsedOutside:N} секунд! " +
                                    $"Начиная с: {DateTime.Now - TimeSpan.FromSeconds(elapsedOutside)} " +
                                    $"Последний, обработанный элемент: {_lastProcessItem?.ToString()}",
                                    LogMessageType.Debug
                                    );

                                WriteLog($"Число элементов в очереди [{_onProcess}][{_collection?.Count}]", logMessageType: LogMessageType.Debug);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex);
                    }

                }, null, dueTime, period);
        }

        public void SetActionStart(object proessItem)
        {
            _lastProcesStartTime = _stopWatch.Elapsed.TotalSeconds;
            _lastProcessItem = proessItem;
            _onProcess = true;
        }

        public void SetActionEnd(object proessItem)
        {
            _onProcess = false;
            _lastProcesEndTime = _stopWatch.Elapsed.TotalSeconds;
            var insideProcessTime = _lastProcesEndTime - _lastProcesStartTime;
            if (insideProcessTime > 10)
            {
                WriteLog(
                    $"Обработка внутри элемента в очереди \"{_handlerName}\" провисела {insideProcessTime:N} секунд!" +
                    $"Начиная с: {DateTime.Now - TimeSpan.FromSeconds(insideProcessTime)} " +
                    $"Элемент: {_lastProcessItem?.ToString()}", 
                    LogMessageType.Debug
                    );
            }
        }

        /// <summary>
        /// Обязательно вызвать, иначе останется висеть в памяти!
        /// </summary>
        public void Dispose()
        {
            _stopWatch.Stop();
            _timerCheckingDequeuing?.Dispose();
            _timerCheckingDequeuing = null;
            _collection = null;
        }
    }
}
