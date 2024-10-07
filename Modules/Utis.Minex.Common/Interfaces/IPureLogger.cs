using System;

namespace Utis.Minex.Common.Interfaces
{
    #region Using
    
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Common;

        #endregion

    /// <summary>
    /// Предоставляет методы записи строкового сообщения в лог-файл.
    /// </summary>
    public interface IPureLogger : IDisposable
    {
        bool WriteLine(string message, LogMessageType messageType = LogMessageType.Info);

        bool WriteException(Exception exception, LogMessageType messageType = LogMessageType.Error);

        bool WriteContractResult(IContractResult contractResult);
    }
}