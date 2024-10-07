using System.Threading;

namespace Utis.Minex.Common.Synchronization
{
    /// <summary>
    /// Объект для синхронизации операций над T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISyncSlim<T> : ISyncSlimRead<T>
        where T : new()
    {
        /// <summary>
        /// Создать локер для записи
        /// </summary>
        /// <param name="syncObject"></param>
        /// <returns></returns>
        WriteLock Write(out T syncObject);

        static ISyncSlim<T> Create()
        {
            return new SyncSlim<T>();
        }
    }

    /// <summary>
    /// Объект для синхронного чтения T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISyncSlimRead<T> where T : new()
    {
        /// <summary>
        /// Создать локер для чтения
        /// </summary>
        /// <param name="syncObject"></param>
        /// <returns></returns>
        ReadLock Read(out T syncObject);
    }


    internal class SyncSlim<T> : ISyncSlim<T>
        where T : new()
    {
        private readonly T _syncObject = new();
        private readonly ReaderWriterLockSlim _slim = new();

        internal SyncSlim()
        {
        }

        public ReadLock Read(out T syncObject)
        {
            var readLock = new ReadLock(_slim);
            syncObject = _syncObject;

            return readLock;
        }

        public WriteLock Write(out T syncObject)
        {
            var writeLock = new WriteLock(_slim);
            syncObject = _syncObject;

            return writeLock;
        }

    }
}
