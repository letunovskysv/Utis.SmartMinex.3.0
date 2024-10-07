using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Utis.Minex.Common
{
    public static class ReaderWriterLockSlimExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Read(this ReaderWriterLockSlim slim, Action action)
        {
            slim.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                slim.ExitReadLock();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(this ReaderWriterLockSlim slim, Func<T> action)
        {
            slim.EnterReadLock();
            try
            {
                return action();
            }
            finally
            {
                slim.ExitReadLock();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this ReaderWriterLockSlim slim, Action action)
        {
            slim.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                slim.ExitWriteLock();
            }
        }
    }
}