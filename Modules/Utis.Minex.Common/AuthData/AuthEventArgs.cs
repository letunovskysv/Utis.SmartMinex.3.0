using System;
using System.Collections.Generic;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Предоставляет данные для события авторизации пользователя.
    /// </summary>
    public class AuthEventArgs : EventArgs
    {
        public AuthEventArgs(
            bool   isAuth, 
            long   userId, 
            string userName, 
            string roleName,
            bool   allowTabAdministration
            )
        {
            IsAuth   = isAuth;
            UserId   = userId;
            UserName = userName;
            RoleName = roleName;
        }

        /// <summary>
        /// Флаг авторизации.
        /// </summary>
        public bool IsAuth
        { get; protected set; }

        /// <summary>
        /// Id авторизированного пользователя.
        /// </summary>
        public long UserId
        { get; protected set; }

        /// <summary>
        /// Имя авторизированного пользователя.
        /// </summary>
        public string UserName 
        { get; protected set; }

        /// <summary>
        /// Роли авторизированного пользователя.
        /// </summary>
        public string RoleName
        { get; protected set; }
    }
}
