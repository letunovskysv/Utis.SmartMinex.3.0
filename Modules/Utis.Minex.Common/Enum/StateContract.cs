
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус выполнения контракта.
    /// </summary>
    public enum StateContract : byte
    {
        /// <summary>
        /// Успешно.
        /// </summary>
        Ok = 0,

        /// <summary>
        /// Непредвиденная ошибка на сервере.
        /// </summary>
        ServerError = 1,
        
        /// <summary>
        /// Не корректный запрос.
        /// </summary>
        BadRequest = 2,

        /// <summary>
        /// Ошибка валидации.
        /// </summary>
        ValidationError = 3,

        /// <summary>
        /// Выполнение отменено.
        /// </summary>
        Canceled = 4,

        /// <summary>
        /// Выполнение активно
        /// </summary>
        Runnng = 5
    }
}