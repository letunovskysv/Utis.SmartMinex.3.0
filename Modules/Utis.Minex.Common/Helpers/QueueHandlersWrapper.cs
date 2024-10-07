using System;
using System.Collections.Generic;
using System.Threading;

namespace Utis.Minex.Common.Helpers
{
    /// <summary>
    /// Позволяет эффективно обрабатывать события в параллельных очередях, количество которых зависит от количества логических ядер.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа, события с разными ключами могут быть помещены в разные очереди, события с одним ключом гарантированно окажутся в одной.</typeparam>
    /// <typeparam name="TEvent">Тип события.</typeparam>
    public class QueueHandlersWrapper<TKey, TEvent>
    {
        private readonly string _queueName;
        private readonly string _moduleName;
        private readonly ThreadPriority? _threadPriority;

        #region Constructors
        public QueueHandlersWrapper(
            string queueName, 
            string moduleName, 
            Action<TEvent> actionForEvent, 
            Func<TEvent, TKey> getKeyFromEvent,
            IServerInputOutput console,
            ThreadPriority threadPriority) : this(queueName,
                                                  moduleName,
                                                  actionForEvent,
                                                  getKeyFromEvent,
                                                  console)

        {
            _threadPriority = threadPriority;
        }

        public QueueHandlersWrapper(
            string queueName, 
            string moduleName, 
            Action<TEvent> actionForEvent, 
            Func<TEvent, TKey> getKeyFromEvent,
            IServerInputOutput console
            )
        {
            _queueName       = queueName;
            _moduleName      = moduleName;

            _actionForEvent  = actionForEvent;
            _getKeyFromEvent = getKeyFromEvent;
            _console         = console;

            var queuesCount = ProcessorCountDevider.GetQueuesCount();
            
            _queues = 
                new QueueHandler<TEvent>[queuesCount];

            return;
        }

        #endregion

        #region InlandDepends

        private readonly IServerInputOutput _console;

        #endregion

        #region Queues

        private readonly QueueHandler<TEvent>[] _queues;
        private readonly Dictionary<TKey, int> _keyToQueueIndex = new Dictionary<TKey, int>();

        /// <summary>
        /// Обработчик события
        /// </summary>
        private readonly Action<TEvent> _actionForEvent;

        /// <summary>
        /// Получение ключа из события, события с разными ключами могут быть помещены в разные очереди, события с одним ключом гарантированно окажутся в одной
        /// </summary>
        private readonly Func<TEvent, TKey> _getKeyFromEvent;

        private readonly object _locker = new object();

        private int _nextQueueIndex = 0;

        #endregion

        #region Methods

        public void Add(TEvent evt)
        {
            var key = _getKeyFromEvent(evt);

            int index = GetQueueIndexByKey(key);

            _queues[index].Add(evt);
        }

        /// <summary>
        /// Получить индекс очереди, сопоставленной с ключом, используется для лучшего управления разделяемыми ресурсами
        /// </summary>
        public int GetQueueIndexByKey(TKey key)
        {
            int index;
            lock (_locker)
            {
                //ищем очередь, которая соответствует ключу этого события
                if (!_keyToQueueIndex.TryGetValue(key, out index))
                {
                    //если для этого ключа ещё нет сопоставленной очереди, то сопоставляем очередь с индексом _nextQueueIndex
                    index = _nextQueueIndex;
                    if (_queues[index] == default)
                    {
                        _console.WriteLine($"Ключу {key} создана очередь \"{_queueName} №{index}\"", onlyToFile: true);

                        var queueName = $"{_queueName} №{index} в модуле {_moduleName}";

                        var newQueue = _threadPriority == null ?
                            new QueueHandler<TEvent>(_actionForEvent, _console, queueName) :
                            new QueueHandler<TEvent>(_actionForEvent, _console, queueName, (ThreadPriority)_threadPriority);

                        _queues[index] = newQueue;
                        newQueue.Start();                        
                    }

                    _console.WriteLine($"Ключу {key} сопоставлена \"{_queueName} №{index}\"", onlyToFile: true);

                    _keyToQueueIndex.Add(key, index);

                    _nextQueueIndex++;
                    if (_nextQueueIndex == _queues.Length)
                        _nextQueueIndex = 0;
                }
            }

            return index;
        }

        public void Stop()
        {
            foreach (var handler in _queues)
                handler?.Stop();
        }

        #endregion
    }
}
