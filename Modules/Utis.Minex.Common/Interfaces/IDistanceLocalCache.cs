using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common
{
    public interface IDistanceLocalCache
    {
        /// <summary>
        /// Возвращает включена или выключена данная функция в приложении
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// Асинхронно записать дистанции в файл
        /// </summary>
        /// <param name="schemeId">Идентификатор схемы имр на основе который были вычеслены дистанции</param>
        /// <param name="branchId">Идентификатор ветки схемы имр на основе который были вычеслены дистанции</param>
        /// <param name="shortestDistances">Предрасситанные дистанции</param>
        public void WriteShortestPathToFileAsync(long schemeId, long branchId, Dictionary<long, Dictionary<long, float>> shortestDistances);

        /// <summary>
        /// Метод для попытки считать файл хранящегося кеша. Файл будет удачно считан только если ожидаемый файл находится в папке и при этом нет других файлов кеша.
        /// </summary>
        /// <param name="schemeId">Идентификатор ожидаемой схемы</param>
        /// <param name="branchId">Идентификатор ожидаемой ветки</param>
        /// <param name="shortedDistances">Возвращаемая ссылка на считанный кеш дистанций</param>
        /// <returns></returns>
        public bool TryReadShortestPathFromFile(long schemeId, long branchId, out Dictionary<long, Dictionary<long, float>> shortedDistances);
    }
}
