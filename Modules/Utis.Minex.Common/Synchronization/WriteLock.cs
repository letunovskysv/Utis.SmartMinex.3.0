using System;
using System.Threading;

namespace Utis.Minex.Common.Synchronization
{
    public class WriteLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _slim;

        public WriteLock(ReaderWriterLockSlim slim)
        {
            _slim = slim;
            _slim.EnterWriteLock();
        }

        public void Dispose()
        {
            _slim.ExitWriteLock();
        }
    }
}