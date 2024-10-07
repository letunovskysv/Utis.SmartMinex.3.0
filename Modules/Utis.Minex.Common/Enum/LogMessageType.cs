
namespace Utis.Minex.Common.Enum
{
    public enum LogMessageType : byte
    {
        /// <summary>
        /// Техническая информация запуска приложения.
        /// </summary>
        None = 0,

        /// <summary>
        /// Стандартный тип информации.
        /// </summary>
        Info    = 1,

        /// <summary>
        /// Информация имеющая повышенный приоритет в логе.
        /// </summary>
        ImportantInfo = 2,

        /// <summary>
        /// Что то пошло не так, но не критично.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Ошибка критичная для работы приложения.
        /// </summary>
        Error = 4,

        Debug = 5
    }
}