using System;
using System.ComponentModel;

namespace Utis.Minex.ProductionModel
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Пользователь.
    /// </summary>
    [RegisterChanges(true)]
    [DisplayName("Пользователь")]    
    public class UserData : CatalogBase, IUserData
    {
        public UserData()
        {
            Name = UserName;
        }

        /// <summary>
        /// Логин.
        /// </summary>
        [UniqueKey]
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
        /// Cотрудник.
        /// </summary>        
        [Browsable(false)]
        [DisplayName("Cотрудник")]
        public virtual Person Person
        { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Наличие подтверждения дисклеймера.
        /// </summary>
        [DisplayName("Подтверждён")]
        public virtual bool HasConfirmDisclaimer
        { get; set; }

        /// <summary>
        /// Статус блокировки
        /// </summary>
        [Browsable(false)]
        [DisplayName("Статус блокировки")]
        public virtual bool IsBlocked
        { get; set; }

        /// <summary>
        /// Причина блокировки
        /// </summary>
        [DisplayName("Причина блокировки")]
        public virtual string BlockingReason 
        { get; set; }

        /// <summary>
        /// Требование смены пароля
        /// </summary>
        [DisplayName("Требование смены пароля")]
        public virtual bool PassChangeRequired
        { get; set; }

        /// <summary>
        /// Дата изменения пароля.
        /// </summary>
        [DisplayName("Дата изменения пароля")]
        public virtual DateTime? TimeOfPassChange
        { get; set; }

        /// <summary>
        /// Дата окончания действия пароля.
        /// </summary>
        [DisplayName("Дата окончания действия пароля")]
        public virtual DateTime? TimeOfPassExpiration
        { get; set; }

        /// <summary>
        /// Соль.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Соль")]
        [RegisterChangesIgnore(true)]
        public virtual string SaltValue
        { get; set; }

        /// <summary>
        /// Хэш.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Хэш")]
        [RegisterChangesIgnore(true)]
        public virtual string HashValue
        { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(UserName))
                return base.ToString();
            else return UserName;
        }
    }
}