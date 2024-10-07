using System;
using System.Threading;

namespace Utis.Minex.Common.Synchronization
{
    public class ReadLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _slim;

        public ReadLock(ReaderWriterLockSlim slim)
        {
            _slim = slim;
            _slim.EnterReadLock();
        }

        public void Dispose()
        {
            _slim.ExitReadLock();
        }
    }
}