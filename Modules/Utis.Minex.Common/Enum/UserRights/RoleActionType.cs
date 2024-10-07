using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Перечень разрешений.
    /// </summary>
    [Flags]
    [DisplayName("Действие")]
    [Description("Тип действий пользователя")]
    public enum RoleActionType
    {
        /// <summary>
        /// None access.
        /// </summary>
        [DisplayName("Нет доступа")]
        Forbidden = 0,

        /// <summary>
        /// Read access.
        /// </summary>
        [DisplayName("Чтение")]
        Read = 1,

        /// <summary>
        /// Create access.
        /// </summary>
        [DisplayName("Добавление")]
        Create = 2,

        /// <summary>
        /// Update access.
        /// </summary>
        [DisplayName("Изменение")]
        Update = 4,

        /// <summary>
        /// Delete access.
        /// </summary>
        [DisplayName("Удаление")]
        Delete = 8,

        /// <summary>
        /// All access.
        /// </summary>
        [DisplayName("Полный доступ")]
        Allowed = Read | Create | Update | Delete,
    }
}
