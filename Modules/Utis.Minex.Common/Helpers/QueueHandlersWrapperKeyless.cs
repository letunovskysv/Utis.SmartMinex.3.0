using System;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.Common.Helpers
{
    /// <summary>
    /// Позволяет эффективно разбирать очередь в параллельных очередях, 
    /// где не важно в какую из очередей попадет объект для обработки
    /// </summary>
    public class QueueHandlersWrapperKeyless<TEvent> : IDisposable
    {
        private readonly string _queueName;
        private readonly string _moduleName;

        public QueueHandlersWrapperKeyless(string queueName,
        string moduleName,
        Action<TEvent> actionForEvent,
        IServerInputOutput serverInputOutput) 
            : this(queueName, moduleName, actionForEvent)
        {
            _serverInputOutput = serverInputOutput;
        }

        public QueueHandlersWrapperKeyless(string queueName,
        string moduleName,
        Action<TEvent> actionForEvent,
        IPureLogger pureLogger) 
            : this(queueName, moduleName, actionForEvent)
        {
            _pureLogger = pureLogger;
        }

        public QueueHandlersWrapperKeyless(
          string queueName,
          string moduleName,
          Action<TEvent> actionForEvent)
        {
            _queueName = queueName;
            _moduleName = moduleName;

            _actionForEvent = actionForEvent;

            var queuesCount = ProcessorCountDevider.GetQueuesCount();

            _queues =
                new QueueHandler<TEvent>[queuesCount];

            for (int i = 0; i < queuesCount; i++)
            {
                _queues[i] = _pureLogger
                             == null ? new QueueHandler<TEvent>(_actionForEvent, _serverInputOutput, $"{_queueName} №{i} в модуле {_moduleName}") :
                                       new QueueHandler<TEvent>(_actionForEvent, _pureLogger, $"{_queueName} №{i} в модуле {_moduleName}");
            }

            return;
        }

        #region InlandDepends

        private readonly IServerInputOutput _serverInputOutput;
        private readonly IPureLogger _pureLogger;

        #endregion

        #region Queues

        private readonly QueueHandler<TEvent>[] _queues;

        /// <summary>
        /// Обработчик события
        /// </summary>
        private readonly Action<TEvent> _actionForEvent;

        private int _nextQueueIndex = 0;

        #endregion

        #region Methods

        public void Start()
        {
            foreach (var queue in _queues)
            {
                queue.Start();
            }
        }
        public void Add(TEvent evt)
        {
            _queues[_nextQueueIndex].Add(evt);

            _nextQueueIndex++;

            if (_nextQueueIndex == _queues.Length)
                _nextQueueIndex = 0;
        }

        public void Stop()
        {
            foreach (var handler in _queues)
                handler?.Stop();
        }

        public void Dispose()
        {
            foreach (var handler in _queues)
                handler?.Dispose();
        }

        #endregion
    }
}
