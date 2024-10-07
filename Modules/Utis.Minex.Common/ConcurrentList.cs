using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Представляет строго типизированный потокобезопасный список объектов, доступных по индексу. 
    /// </summary>
    /// <typeparam name="T">Тип элементов в списке.</typeparam>
    public partial class ConcurrentList<T> : IList<T>, IDisposable
    {
        #region Constructors

        public ConcurrentList()
            : this(64)
        { }

        public ConcurrentList(int initialCapacity)
        {
            _arr = new T[initialCapacity];
        }

        public ConcurrentList(IEnumerable<T> items)
        {
            _arr   = items.ToArray();
            _count = _arr.Length;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _lock.Dispose();
        }

        ~ConcurrentList()
        {
            if (_lock != null)
                _lock.Dispose();
        }

        #endregion

        #region Lock

        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        #endregion

        #region Collection

        private T[] _arr;

        public T this[int index]
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    if (index >= _count)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    return _arr[index];
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
            set
            {
                _lock.EnterUpgradeableReadLock();
                try
                {

                    if (index >= _count)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    _lock.EnterWriteLock();
                    try
                    {
                        _arr[index] = value;
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }
                finally
                {
                    _lock.ExitUpgradeableReadLock();
                }
            }
        }

        #endregion

        #region EnsureCapacity

        /// <summary>
        /// Обеспечить требуемую емкоть списка.
        /// </summary>
        /// <param name="capacity">Требуемая емкость.</param>
        private void EnsureCapacity(int capacity)
        {
            if (_arr.Length >= capacity)
                return;

            int doubled;
            checked
            {
                try
                {
                    doubled = _arr.Length * 2;
                }
                catch (OverflowException)
                {
                    doubled = int.MaxValue;
                }
            }

            var newLength = Math.Max(doubled, capacity);
            Array.Resize(ref _arr, newLength);
        }

        #endregion

        #region Count

        private volatile int _count;

        /// <summary>
        /// Получает число элементов, содержащихся в интерфейсе List<T>.
        /// </summary>
        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        /// <summary>
        /// Возвращает общее число элементов, которые может вместить внутренняя структура данных без изменения размера.
        /// </summary>
        public int Capacity
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _arr.Length;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        #endregion

        #region IsReadOnly

        /// <summary>
        /// Получает значение, указывающее, является ли объект коллекции доступным только для чтения.
        /// </summary>
        public bool IsReadOnly => false;

        #endregion

        #region Clear

        /// <summary>
        /// Удаляет все элементы из коллекции.
        /// </summary>
        public void Clear()
        {
            _lock.EnterWriteLock();
            try
            {
                Array.Clear(_arr, 0, _count);
                _count = 0;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #endregion

        #region CopyTo

        /// <summary>
        /// Копирует коллекцию целиком в совместимый одномерный массив, начиная с указанного индекса конечного массива.
        /// </summary>
        /// <param name="array">Одномерный массив Array, в который копируются элементы из коллекции.</param>
        /// <param name="arrayIndex">Отсчитываемый от нуля индекс в массиве array, указывающий начало копирования.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _lock.EnterReadLock();
            try
            {
                if (_count > array.Length - arrayIndex)
                    throw new ArgumentException($"Destination {nameof(array)} was not long enough.");

                Array.Copy(_arr, 0, array, arrayIndex, _count);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        #endregion

        #region Contains

        /// <summary>
        /// Определяет, входит ли элемент в коллекцию.
        /// </summary>
        /// <param name="item">Объект для поиска.</param>
        /// <returns>
        /// Значение true, если параметр item найден в коллекции; 
        /// в противном случае — значение false.
        /// </returns>
        public bool Contains(T item)
        {
            _lock.EnterReadLock();
            try
            {
                return IndexOfInternal(item) != -1;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        #endregion

        #region IndexOf

        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения, 
        /// найденного в пределах всего списка.
        /// </summary>
        /// <param name="item">Объект для поиска.</param>
        /// <returns>
        /// Отсчитываемый от нуля индекс первого вхождения элемента item в пределах всей коллекции, 
        /// если элемент найден; в противном случае — значение –1.
        /// </returns>
        public int IndexOf(T item)
        {
            _lock.EnterReadLock();
            try
            {
                return IndexOfInternal(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        private int IndexOfInternal(T item)
        {
            return Array.FindIndex(_arr, 0, _count, x => x.Equals(item));
        }

        #endregion

        #region Add

        /// <summary>
        /// Добавляет объект в конец списка.
        /// </summary>
        /// <param name="item">Объект, добавляемый в конец коллекции.</param>
        public void Add(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                var newCount = _count + 1;
                EnsureCapacity(newCount);

                _arr[_count] = item;
                _count = newCount;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #endregion

        #region AddRange

        /// <summary>
        /// Добавляет элементы указанной коллекции в конец списка.
        /// </summary>
        /// <param name="items">Коллекция, элементы которой добавляются в конец списка.</param>
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _lock.EnterWriteLock();
            try
            {
                var arr = items as T[] ?? items.ToArray();
                var newCount = _count + arr.Length;
                EnsureCapacity(newCount);

                Array.Copy(arr, 0, _arr, _count, arr.Length);
                _count = newCount;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #endregion

        #region Remove

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции.
        /// </summary>
        /// <param name="item">Объект, который необходимо удалить из коллекции.</param>
        /// <returns>
        /// Значение true, если элемент item успешно удален, в противном случае — значение false.
        /// </returns>
        public bool Remove(T item)
        {
            _lock.EnterUpgradeableReadLock();
            try
            {
                var i = IndexOfInternal(item);

                if (i == -1)
                    return false;

                _lock.EnterWriteLock();
                try
                {
                    RemoveAtInternal(i);
                    return true;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        #endregion

        #region RemoveAt

        /// <summary>
        /// Удаляет элемент списка с указанным индексом.
        /// </summary>
        /// <param name="index">Индекс (с нуля) элемента, который требуется удалить.</param>
        public void RemoveAt(int index)
        {
            _lock.EnterUpgradeableReadLock();
            try
            {
                if (index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                _lock.EnterWriteLock();
                try
                {
                    RemoveAtInternal(index);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        private void RemoveAtInternal(int index)
        {
            Array.Copy(_arr, index + 1, _arr, index, _count - index - 1);
            _count--;

            // release last element
            Array.Clear(_arr, _count, 1);
        }

        #endregion

        #region Insert

        /// <summary>
        /// Вставляет элемент в коллекцию по указанному индексу.
        /// </summary>
        /// <param name="index">Отсчитываемый от нуля индекс, по которому следует вставить элемент.</param>
        /// <param name="item">Вставляемый объект.</param>
        public void Insert(int index, T item)
        {
            _lock.EnterUpgradeableReadLock();
            try
            {
                if (index > _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                _lock.EnterWriteLock();
                try
                {
                    var newCount = _count + 1;
                    EnsureCapacity(newCount);

                    // shift everything right by one, starting at index
                    Array.Copy(_arr, index, _arr, index + 1, _count - index);

                    // insert
                    _arr[index] = item;
                    _count = newCount;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        #endregion

        #region GetEnumerator

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор элементов списка.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            _lock.EnterReadLock();
            try
            {
                for (int i = 0; i < _count; i++)
                    // deadlocking potential mitigated by lock recursion enforcement
                    yield return _arr[i];
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region DoSync

        /// <summary>
        /// Предоставляет выполнение, требующие эксклюзивного доступа к списку.
        /// </summary>
        public void DoSync(Action<ConcurrentList<T>> action)
        {
            _lock.EnterWriteLock();
            try
            {
                action(this);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Предоставляет выполнение, требующие эксклюзивного доступа к списку.
        /// </summary>
        public TResult DoSync<TResult>(Func<ConcurrentList<T>, TResult> func)
        {
            _lock.EnterWriteLock();
            try
            {
                return func(this);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #endregion
    }
}