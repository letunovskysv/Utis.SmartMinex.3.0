using System;
namespace Utis.Minex.Common.Helpers
{
    public static class ProcessorCountDevider
    {
        /// <summary>
        /// Делитель логических ядер процессора
        /// </summary>
        private static readonly int _devider = 3;

        /// <summary>
        /// Возвращает количество очерей в зависимости от количества логических 
        /// ядер процессора
        /// </summary>
        public static int GetQueuesCount()
        {
            var queuesCount = Environment.ProcessorCount / _devider;
            if (queuesCount == 0)
                queuesCount = 1;
            return queuesCount;
        }
    }
}
