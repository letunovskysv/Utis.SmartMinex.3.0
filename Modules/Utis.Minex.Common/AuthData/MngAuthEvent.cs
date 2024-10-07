using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Агрегирует события, уведомляющие о авторизации пользователя.
    /// </summary>
    public static class MngAuthEvent
    {
        #region AuthorizationAttempting

        public static event EventHandler<CancelEventArgs> AuthorizationAttempting = delegate { };

        private static CancelEventArgs _cancelEventArgs = new CancelEventArgs();

        public static bool IsCanceled { get =>  _cancelEventArgs.Cancel; }

        public static void RaiseAuthorizationAttempting()
        {
            AuthorizationAttempting?.Invoke(null, _cancelEventArgs);
        }

        #endregion

        #region EvExecShowAuthDialog

        /// <summary>
        /// Флаг, что при запуске нуобходимо вызвать окно авторизации.
        /// Должен устанавливаться, только когда EvExecShowAuthDialog не успел инициализироваться
        /// </summary>
        private volatile static bool _isPending;

        /// <summary>
        /// Событие уведомляющее о необходимости вывести диалог авторизации.
        /// </summary>
        public static event EventHandler EvExecShowAuthDialog = null;

        public static void RaisePendingEvents(Interfaces.IPureLogger _logger)
        {
            if (_isPending)
            {
                _isPending = false;

                // запуск в отдельном потоке на случай, если метод вызывается из конструктора (сейчас RaisePendingEvents всегда запускается из конструктора).
                // если запускать просто так, то конструктор сломается, статус бар не загрузиться и авторизация зависнет 
                _logger?.WriteLine("MngAuthEvent::попытка выполнить EvExecShowAuthDialog после ожидания");
                Task.Factory.StartNew(() =>
                {
                    RaiseExecShowAuthDialog(_logger);
                }, TaskCreationOptions.AttachedToParent);
            }
        }

        /// <summary>
        /// Опубликовать событие о необходимости вывести диалог авторизации.
        /// </summary>
        public static void RaiseExecShowAuthDialog(Interfaces.IPureLogger _logger)
        {
            if (EvExecShowAuthDialog == null)
            {
                _logger?.WriteLine("MngAuthEvent::ставим флаг ожидания инициализации EvExecShowAuthDialog");
                _isPending = true;
            }
            else
            {
                _logger?.WriteLine("MngAuthEvent::попытка выполнить EvExecShowAuthDialog");
                EvExecShowAuthDialog?.Invoke(null, EventArgs.Empty);
            }
        }

        #endregion

    }
}
