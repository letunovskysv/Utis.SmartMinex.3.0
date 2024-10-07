using Utis.Minex.Common.AuthData;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Коды возврата авторизации.
    /// </summary>
    public enum AuthActions
    {
        /// <summary>
        /// Необходимо подтвердить условия использования
        /// </summary>
        ConfirmDisclaimerRequired,

        /// <summary>
        /// Необходимо сменить пароль
        /// </summary>
        PassChangeRequired,

        /// <summary>
        /// Необходимо уведомить пользователя о скором времени смены пароля
        /// </summary>
        NotifyPassChangeSoon
    }
}
