//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
//--------------------------------------------------------------------------------------------------
using System;
using System.Collections;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    public class SessionReleaser : IDisposable
    {
        private ICustomSession _session;
        private Action _releaseSessionInRepository;

        public SessionReleaser(
            ICustomSession session,
            Action releaseSessionInRepository
            )
        {
            _releaseSessionInRepository = releaseSessionInRepository;
            _session = session;
        }

        #region IDisposable

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _session?.SetSession(null);
                _session = null;

                _releaseSessionInRepository();
                _releaseSessionInRepository = null;
            }

            _disposed = true;
        }

        ~SessionReleaser()
        {
            Dispose(false);
        }

        #endregion
    }

    /// <summary>
    /// Класс работы с транзакциями в рамках сессии и выполнения запросов
    /// </summary>
    public interface ICustomSession : ICustomSessionBase
    {
        object Session { get; }

        object Transaction { get; }
  
        void SetSession(object statelessSession);

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        void Rollback();
    }

    public interface ICustomSessionBase : IDisposable
    {
        bool IsOpenTransaction { get; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        void AddChangeObjectInTransactionOrImidiatlySend(ChangeObjectOperation data, ObjectBase oldObject = null);

        ObjectBase AddOldEntityToOperationIfFirstOperation(ObjectBase newObject, string guid = null);

        ObjectBase AddOldEntityToOperationIfFirstOperation(long id, Type entityType, string guid = null);

        public void CreateAndStartQueueIfNeed();
    }

    public class ChangeObjectEventData
    {
        /// <summary>
        /// До изменений
        /// </summary>
        public ObjectBase OldObject { get; set; }

        /// <summary>
        /// После изменений
        /// </summary>
        public ObjectBase NewObject { get; set; }

        /// <summary>
        /// Тип операции
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Заполнен если операция шла с клиента
        /// </summary>
        public string GUID { get; set; }

        public bool IsSetUpdate { get; set; }
    }

    public class ChangeObjectOperation
    {
        /// <summary>
        /// После изменений
        /// </summary>
        public ObjectBase Object { get; set; }

        /// <summary>
        /// Тип операции
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Заполнен если операция шла с клиента
        /// </summary>
        public string GUID { get; set; }

        public bool IsSetUpdate { get; set; }

        public string[] PropertyNames { get; set; }

        public object[] PropertyValues { get; set; }

        public Type EntityType { get; set; }

        public long EntityId { get; set; }
    }
}