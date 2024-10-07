using System;

namespace Utis.Minex.Common
{
    #region Using
    
    using Utis.Minex.Common.Enum;

        #endregion
    
    public interface IServerInputOutput : IDisposable
    {
        /// <summary>
        /// Записать ошибку в лог.
        /// </summary>
        /// <param name="ex">Логируемая ошибка.</param>
        void WriteLine(Exception ex, LogMessageType logMessageType = LogMessageType.Error);

        /// <summary>
        /// Записать в лог строку.
        /// </summary>
        /// <param name="message">Сообщение для записи в лог.</param>
        /// <param name="logMessageType">Тип логгируемого сообщения.</param>
        /// <param name="showDatetime">Поставить перед сообщением дату/время записи.</param>
        /// <param name="onlyToFile">Не отображать в консоли, только запись в файл.</param>
        void WriteLine(string message = "", LogMessageType logMessageType = LogMessageType.Info, bool showDatetime = true, bool onlyToFile = false);
    }
}