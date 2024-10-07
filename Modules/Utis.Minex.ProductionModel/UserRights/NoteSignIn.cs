using System;
using System.ComponentModel;

namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Запись о статусе авторизации пользователя.
    /// </summary>
    [DisplayName("Запись о статусе авторизации пользователя")]
    public class NoteSignIn : CatalogBase
    {
        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        [DisplayName("Идентификатор клиента")]
        public virtual string ClientGuid
        { get; set; }

        /// <summary>
        /// Идентификатор сервера.
        /// </summary>
        [DisplayName("Идентификатор сервера")]
        public virtual string SeverGuid
        { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Пользователь")]
        public virtual UserData UserData
        { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DisplayName("Логин")]
        public virtual string UserName
        { get; set; }

        /// <summary>
        /// ФИО cотрудника.
        /// </summary>
        [DisplayName("ФИО cотрудника")]
        public virtual string PersonFullName
        { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [DisplayName("Статус")]
        public virtual SignInStatus SignInStatus
        { get; set; }

        /// <summary>
        /// Дата/время авторизации.
        /// </summary>
        [DisplayName("Дата/время авторизации")]
        public virtual DateTime? TimeEnterSignIn 
        { get; set; }

        /// <summary>
        /// Дата/время разлогинивания.
        /// </summary>
        [DisplayName("Дата/время разлогинивания")]
        public virtual DateTime? TimeExitSignIn
        { get; set; }

        /// <summary>
        /// Ip адрес клиента.
        /// </summary>
        [DisplayName("Ip-адрес")]
        public virtual string? IpAddress
        { get; set; }

        /// <summary>
        /// HOST-имя.
        /// </summary>
        [DisplayName("HOST-имя")]
        public virtual string? HostName
        { get; set; }
    }
}