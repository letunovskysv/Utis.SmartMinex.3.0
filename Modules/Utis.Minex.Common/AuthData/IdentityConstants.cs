namespace Utis.Minex.Common.AuthData
{
    public static class IdentityConstants
    {
        /// <summary>
        /// Техническая роль не авторизованного пользователя
        /// </summary>
        public const string UnauthorizedRole = "UnauthorizedRole";

        /// <summary>
        /// Роль Администратора
        /// </summary>
        public const string AdminRole = "Администратор";

        /// <summary>
        /// Базовый администратор, создается для первчного входа в систему
        /// </summary>
        public const string DefaultAdminUserName = "Администратор";

        /// <summary>
        /// Пароль базового администратора
        /// </summary>
        public const string DefaultAdminUserPass = "11111";

        /// <summary>
        /// Периодичность смены пароля пользователями
        /// </summary>
        public const int PassExpirationUser = 90;

        /// <summary>
        /// Периодичность смены пароля администраторами
        /// </summary>
        public const int PassExpirationAdministrator = 45;

        /// <summary>
        /// Минимальное количество символов для пароля
        /// </summary>
        public const int MinPassLengthUser = 8;

        /// <summary>
        /// Минимальное количество символов для пароля администратора
        /// </summary>
        public const int MinPassLengthAdmin = 12;

        /// <summary>
        /// Глубина проверки истории паролей на не поторяемость, при смене пароля
        /// </summary>
        public const int OldPassHistoryInMonths = 12;

        /// <summary>
        /// Частота проверки учетных записей на предмет отсутсвия подтверждения дисклеймера или входов в учтную запись
        /// </summary>
        public const int PeriodOfCheckingInHours = 24;

        /// <summary>
        /// Период неактивности после которого будет заблокирован пользователь
        /// </summary>
        public const int BlockInactiveUsersAfterDays = 90;

        /// <summary>
        /// Период неактивности после которого будет заблокирован администратор
        /// </summary>
        public const int BlockInactiveAdministratorAfterDays = 45;

        /// <summary>
        /// Период неактивности после которого будет заблокирован пользователь с неподтвержденным дисклеймером
        /// </summary>
        public const int BlockUsersWithUnconfirmedDisclaimerDays = 21;

        /// <summary>
        /// Количество днейза которое пользователь будет предупрежден о необходимости смены пароля
        /// </summary>
        public const int NotifyBeforePassExpirationDays = 14;

        public static bool IsDefaultAdmin(string userName) 
            => IdentityConstants.DefaultAdminUserName == userName;

        public static bool IsAdmin(string roleName) 
            => roleName == AdminRole;

    }
}
