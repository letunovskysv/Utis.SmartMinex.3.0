using System;
using System.Threading;

namespace Utis.Minex.Common.Synchronization
{
    public class Locker : IDisposable
    {
        private readonly object _lockObj;
        private readonly bool _isLock;

        public Locker(object lockObj)
        {
            _lockObj = lockObj;
            Monitor.Enter(_lockObj, ref _isLock);
        }

        public void Dispose()
        {
            if (_isLock)
            {
                Monitor.Exit(_lockObj);
            }
        }
    }
}