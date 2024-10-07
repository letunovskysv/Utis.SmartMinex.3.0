using System;
using System.Runtime.CompilerServices;

namespace Utis.Minex.Common.Handlers
{
    #region Using
        
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

    #endregion

    public abstract class BaseHandler
    {
        protected string _handlerName { get; init; } = "";

        protected bool _canBeLogged { get; init; }

        protected IServerInputOutput _console { get; init; }
        protected IPureLogger _logger { get; init; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void WriteLog(string message, LogMessageType logMessageType = LogMessageType.Info)
        {
            if (_canBeLogged)
            {
                _console?.WriteLine(message, logMessageType, onlyToFile: true);
                _logger?.WriteLine(message, logMessageType);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void WriteLog(Exception ex)
        {
            if (_canBeLogged)
            {
                _console?.WriteLine(ex);
                _logger?.WriteException(ex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void TryCatchLog(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                WriteLog(new Exception($"Ошибка обработчике {_handlerName}", ex));
            }
        }
    }
}