using System;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Методы логгирования ошибок валидации
    /// </summary>
    public interface IValidationLogger : IDisposable
    {
        bool WriteLine(string message, LogMessageType messageType = LogMessageType.Info);
    }
}
