namespace Utis.Minex.Common.Event
{
    /// <summary>
    /// Класс вспомогательной информации по событиям точного позиционирования
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Количество миллисекунд опроса всех антенн на анкере
        /// </summary>
        public const int FULL_PACKAGE_MILLISECONDS = 4000;

        /// <summary>
        /// Миллисекунды для хранения предыдущих данных
        /// </summary>
        public const int BUFFER_MILLISECONDS = 4000;

        /// <summary>
        /// Глубина хранения данных точного позиционирования
        /// </summary>
        public const int POSITION_STORAGE_DEPTH = 30;

        /// <summary>
        /// Время простоя объекта позиционирования
        /// </summary>
        public const int OBJECT_DOWNTIME = 15000;
    }
} 