using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Helpers
{
    public static class ParallelHelper
    {
        public static void ForEach<T>(ICollection<T> list, Action<List<T>> action)
        {
            //для эффективного распараллеливания разбиваем на колво групп равное колву процессоров (+1, если делится не ровно)
            //работает быстрее чем Parallel.ForEach с заданным MaxDegreeOfParallelism, по крайней мере для больших коллекций

            var size = list.Count() / Environment.ProcessorCount;

            if (size == 0)
                size = list.Count();

            var groups = new List<List<T>>();

            for (int i = 0; i < list.Count(); i += size)
            {
                groups.Add(list.Skip(i).Take(size).ToList());
            }

            Parallel.ForEach(groups, action);
        }

        /// <summary>
        /// Параллельное преобразование коллекции <typeparamref name="T"/> в коллекцию <typeparamref name="TResult"/>, возвращает true, если не было исключений
        /// </summary>
        /// <typeparam name="T">Тип элемента входной коллекции</typeparam>
        /// <typeparam name="TResult">Тип элемента возвращаемой коллекции</typeparam>
        /// <param name="list">Входная коллекция</param>
        /// <param name="selector">Функция, преобразующая элемент входной коллекции в элемент выходной коллекции</param>
        /// <param name="ct">Токен отмены</typeparam>
        public static async Task<IEnumerable<TResult>> AsyncSelect<T, TResult>(
            IEnumerable<T> list,
            Func<T, TResult> selector,
            CancellationToken ct)
        {
            var loadTask = list.Select(source =>
                Task.Factory.StartNew<TResult>(() =>
                {
                    return selector(source); 
                }, ct
            ));

            return await Task.WhenAll(loadTask);
        }

        /// <summary>
        /// Параллельное выполнение действия для каждого элемента коллекции,
        /// </summary>
        /// <typeparam name="T">Тип элемента входной коллекции</typeparam>
        /// <param name="list">Входная коллекция</param>
        /// <param name="actionOnElement">Действие над элементами входной коллекции</param>
        /// <param name="ct">Токен отмены</typeparam>
        public static async Task AsyncForEach<T>(
            IEnumerable<T> list,
            Action<T> actionOnElement,
            CancellationToken ct = default)
        {
            var loadTask = list.Select(source =>
            Task.Factory.StartNew(() =>
                {
                    actionOnElement(source);
                }, ct
            ));

            await Task.WhenAll(loadTask);
        }
    }
}
