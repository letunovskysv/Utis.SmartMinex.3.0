
namespace Utis.Minex.Common
{
    /// <summary>
    /// Статус авторизации пользователя.
    /// </summary>
    [DisplayName("Статус авторизации")]
    [Description("Статус авторизации пользователя")]
    public enum SignInStatus
    {
        /// <summary>
        /// Не определенно.
        /// </summary>
        [DisplayName("Не определенно")]
        None = 0,

        /// <summary>
        /// Пользователь залогинелся.
        /// </summary>
        [DisplayName("Вход")]
        Login = 1,

        /// <summary>
        /// Пользователь разлогинелся.
        /// </summary>
        [DisplayName("Выход")]
        UnLogin = 2,

        /// <summary>
        /// Отклонено.
        /// </summary>
        [DisplayName("Отклонено")]
        Rejected = 4,

        /// <summary>
        /// Попытка повторного входа.
        /// </summary>
        [DisplayName("Попытка повторного входа")]
        RejectedByReEntry  = 8,

        /// <summary>
        /// Сессия не может быть продолжена
        /// </summary>
        [DisplayName("Сессия не может быть продолжена")]
        RejectedBySession = 10,

        /// <summary>
        /// Сервер завершил работу.
        /// </summary>
        [DisplayName("Сервер завершил работу")]
        ServerShutdown = 32,

        /// <summary>
        /// Разрыв связи с клиентом.
        /// </summary>
        [DisplayName("Разрыв связи с клиентом")]
        ClientDisconnected = 64,
    }
}
