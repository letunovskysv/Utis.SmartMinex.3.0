using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utis.Minex.Common.Interfaces.Repository;

namespace Utis.Minex.Common
{
    using Utis.Minex.Common.Enum;

    public class ActionEntityEventArgs<T> : EventArgs where T : ObjectBase
    {
        public ActionEntityEventArgs(EntityActionType entityActionType, IEnumerable<T> entities)
        {
            Entities         = entities;
            EntityActionType = entityActionType;
        }

        public IEnumerable<T> Entities
        { get; }

        public EntityActionType EntityActionType 
        { get; }
    }

    /// <summary>
    /// Загрузчик данных.
    /// </summary>
    public class RepositoryWorker<T> : IDisposable where T : ObjectBase
    {
        private readonly IBaseRepository _repository;
        private readonly IMetadataRepository _metadataRepository;
        private readonly IServerInputOutput _console;
        private readonly string _workerName;

        private readonly ConcurrentQueue<EntityActionTypeWrapper> _queue = new();

        private Task _task;
        private volatile bool _shouldStop = false;
        private readonly bool _isVersionObjectType = typeof(VersionObjectBase).IsAssignableFrom(typeof(T));

        /// <summary>
        /// Event on save action
        /// </summary>
        public event EventHandler<ActionEntityEventArgs<T>> OnActionEntity;
        Action<IEnumerable<T>> _create;
        Action<IEnumerable<T>> _update;
        Action<IEnumerable<T>> _delete;

        /// <summary>
        /// Событие уведомляющее ожидающий поток о необходимости пробуждении.
        /// </summary>
        protected readonly AutoResetEvent _wakeEvent = new(false);

        /// <summary>
        /// конструктор с репозиторием метаданных
        /// </summary>
        /// <param name="repository"></param>
        public RepositoryWorker(
            IMetadataRepository repository,
            IServerInputOutput console,
            string workerName
            )
        {
            _metadataRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _console = console ?? throw new ArgumentNullException(nameof(console));
            _workerName = workerName;

            _create = x => { foreach (var item in x) _metadataRepository.Insert(item); };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="console"></param>
        /// <param name="workerName"></param>
        /// <param name="sendToChangeAnalizer">уведомлять ли весь СП и клиенты о изменениях(выключать только в частных случаях, как например при записи в DA)</param>
        public RepositoryWorker(
            IBaseRepository repository,
            IServerInputOutput console,
            string workerName,
            bool sendToChangeAnalizer
            )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _console = console ?? throw new ArgumentNullException(nameof(console));
            _workerName = workerName;

            _create       = x => _repository.Add(x, sendToChangeAnalizer: sendToChangeAnalizer);
            _delete       = x => _repository.Delete(x, sendToChangeAnalizer: sendToChangeAnalizer);
            _update       = x => _repository.Update(x, sendToChangeAnalizer: sendToChangeAnalizer);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="entity">Item</param>
        /// <param name="entityActionType">тип действия с сущностью</param>
        public void Add(T entity, EntityActionType entityActionType)
        {
            if (_shouldStop)
            {
                _console.WriteLine($"Добавление в остановленный RepositoryWorker '{_workerName}'", LogMessageType.Warning, onlyToFile: true);
            }

            if (entity != null)
            {
                if (_isVersionObjectType)
                {
                    _queue.Enqueue(new EntityActionTypeWrapper(_repository.GetShallowClone(entity), entityActionType));
                }
                else
                {
                    _queue.Enqueue(new EntityActionTypeWrapper(entity, entityActionType));
                }

                _wakeEvent.Set();
            }
        }

        /// <summary>
        /// Add collection of items
        /// </summary>
        /// <param name="entities">Collection of items</param>
        /// <param name="entityActionType">тип действия с сущностью</param>
        public void AddRange(IEnumerable<T> entities, EntityActionType entityActionType)
        {
            if (_shouldStop)
            {
                _console.WriteLine($"Добавление в остановленный RepositoryWorker '{_workerName}'", LogMessageType.Warning, onlyToFile: true);
            }

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    if (item != null)
                    {
                        if (_isVersionObjectType)
                        {
                            _queue.Enqueue(new EntityActionTypeWrapper(_repository.GetShallowClone(item), entityActionType));
                        }
                        else
                        {
                            _queue.Enqueue(new EntityActionTypeWrapper(item, entityActionType));
                        }
                    }
                }

                _wakeEvent.Set();
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            _console.WriteLine($"RepositoryWorker '{_workerName}' - запуск", onlyToFile: true);
            Stop(false);
            _shouldStop = false;
            _task = Task.Run(ProcessItems);
            _console.WriteLine($"RepositoryWorker '{_workerName}' - запущен", onlyToFile: true);
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            Stop(true);
        }

        /// <summary>
        /// Stop, сделан приватным чтобы извне не было возможности остановить без сообщений в лог
        /// </summary>
        private void Stop(bool writeToLog)
        {
            
            if (writeToLog)
                _console.WriteLine($"RepositoryWorker '{_workerName}' - остановка", onlyToFile: true);

            _shouldStop = true;
            _wakeEvent.Set();

            if (writeToLog)
            {
                while (_task?.Wait(1000) == false)
                {
                    _console.WriteLine($"RepositoryWorker '{_workerName}' - ожидание остановки, осталось {_queue.Count} элементов", onlyToFile: true);
                }
            }
            else
            {
                _task?.Wait();
            }

            _task = null;

            if (writeToLog)
                _console.WriteLine($"RepositoryWorker '{_workerName}' - остановлен", onlyToFile: true);
        }

        private void ProcessItems()
        {
            while (!_shouldStop || !_queue.IsEmpty)
            {
                if (!_queue.IsEmpty)
                {
                    var list = new LinkedList<(EntityActionType EntityActionType, List<T> Entities)>();

                    int i = 0;
                    while (_queue.TryDequeue(out var temp))
                    {
                        if (list.Last == null || list.Last.Value.EntityActionType != temp.EntityActionType)
                        {
                            list.AddLast((temp.EntityActionType, new List<T>{ temp.Entity }));
                        }
                        else
                        {
                            list.Last.Value.Entities.Add(temp.Entity);
                        }

                        //иначе может бесконечно копиться(в случае SSD)
                        if (i++ > 500)
                            break;
                    }

                    if (i > 500)
                        _console.WriteLine($"RepositoryWorker '{_workerName}': очередь разобрана не до конца: в очереди осталось '{_queue.Count}' элементов", onlyToFile: true);

                    using (_repository.CreateSession(true))
                    {
                        var current = list.First;

                        while (current != null)
                        {
                            InvokeAction(current.Value);
                            current = current.Next;
                        }
                    }

                    if (i > 500)
                        _console.WriteLine($"RepositoryWorker '{_workerName}': действия над полученными элементами из очереди выполнены", onlyToFile: true);

                    void InvokeAction((EntityActionType EntityActionType, List<T> Entities) item)
                    {
                        try
                        {
                            switch (item.EntityActionType)
                            {
                                case EntityActionType.Create: { _create.Invoke(item.Entities); } break;
                                case EntityActionType.Update: { _update.Invoke(item.Entities); } break;
                                case EntityActionType.Delete: { _delete.Invoke(item.Entities); } break;
                            }

                            try
                            {
                                OnActionEntity?.Invoke(this, new ActionEntityEventArgs<T>(item.EntityActionType, item.Entities));
                            }
                            catch (Exception)
                            {
                                _console.WriteLine($"RepositoryWorker '{_workerName}' - Не удалось выполнить событие OnActionEntity", onlyToFile: true);
                                throw;
                            }
                        }
                        catch(Exception ex)
                        {
                            _console.WriteLine(ex);
                        }
                    }
                }
                else
                {
                    _wakeEvent.WaitOne();
                }
            }
        }

        private class EntityActionTypeWrapper
        {
            public EntityActionTypeWrapper(T entity, EntityActionType entityActionType)
            {
                Entity           = entity;
                EntityActionType = entityActionType;
            }

            public T Entity
            { get; }

            public EntityActionType EntityActionType
            { get; }
        }

        public void Dispose()
        {
            try
            {
                _repository?.Dispose();
                _task?.Dispose();
                _wakeEvent?.Dispose();
            }
            catch
            {
                //ignore
            }
        }
    }
}