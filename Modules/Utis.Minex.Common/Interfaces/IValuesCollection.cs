using System;
using Utis.Minex.Common.Synchronization;

namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Коллекция значений
    /// </summary>
    public interface IValuesCollection<T> : IValuesCollection
    {
        /// <summary>
        /// get T by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string this[string name] { get; }

        /// <summary>
        /// добавление события тэга в обработку
        /// </summary>
        void Add<TEvent>(TEvent evt) where TEvent : class;

        /// <summary>
        /// методы извлечения имени тэга, его описания и значения
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="gettagname">получение имени тэга</param>
        /// <param name="getdescription">получение описания тэга</param>
        /// <param name="getvalue">получение значения тэга</param>
        void AddProcessor<TEvent>(Func<TEvent, string> gettagname, Func<TEvent, string> getdescription, Func<TEvent, object> getvalue) where TEvent : class;

        /// <summary>
        /// обновление сущности T
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="input"></param>
        void UpdateSource(string tagName, CatalogBase input);

        Locker GetTagsUnderLock(out T[] tags);
    }

    public interface IValuesCollection
    {
        void Stop();
    }
}