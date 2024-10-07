using System;
using System.Collections.Generic;

namespace Utis.Minex.Common.Synchronization
{
    /// <summary>
    /// Объект для синхронизации операций над словарем
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ISyncSlimDict<TKey, TValue> : ISyncSlim<Dictionary<TKey, TValue>>
    {
        /// <summary>
        /// Получить значение или создать новое
        /// </summary>
        /// <param name="key"></param>
        /// <param name="funcAdd"></param>
        /// <returns></returns>
        TValue GetOrAdd(TKey key, Func<TValue> funcAdd);

        new static ISyncSlimDict<TKey, TValue> Create()
        {
            return new SyncSlimDict<TKey, TValue>();
        }
    }

    internal class SyncSlimDict<TKey, TValue> : SyncSlim<Dictionary<TKey, TValue>>, ISyncSlimDict<TKey, TValue>
    {
        public TValue GetOrAdd(TKey key, Func<TValue> funcAdd)
        {
            TValue value = default(TValue);
            bool isExist = true;

            using (Read(out var dict))
            {
                if (!dict.TryGetValue(key, out value))
                    isExist = false;
            }

            if (!isExist)
            {
                using (Write(out var dict))
                {
                    if (!dict.TryGetValue(key, out value)) // Доп. проверка при пересечении Read потоками
                    {
                        value = funcAdd();
                        dict.Add(key, value);
                    }
                }
            }

            return value;
        }
    }
}
