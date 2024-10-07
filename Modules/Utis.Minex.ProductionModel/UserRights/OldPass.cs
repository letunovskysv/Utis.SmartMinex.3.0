using System;
using System.ComponentModel;

namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Предыдущий пароль пользователя
    /// (используется для хранения истории паролей пользователя).
    /// </summary>
    [DisplayName("Предыдущий пароль пользователя")]
    public class OldPass : CatalogBase
    {
        /// <summary>
        /// Данные пользователя.
        /// </summary>
        [DisplayName("Данные пользователя")]
        [Description("Данные пользователя")]
        public virtual UserData UserData
        { get; set; }

        /// <summary>
        /// Дата начала действия данного пароля.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Дата начала действия пароля")]
        public virtual DateTime? TimeBeginOfPass 
        { get; set; }

        /// <summary>
        /// Дата завершения действия данного пароля.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Дата завершения действия пароля")]
        public virtual DateTime? TimeEndOfPass 
        { get; set; }

        /// <summary>
        /// Соль.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Соль")]
        public virtual string SaltValue
        { get; set; }

        /// <summary>
        /// Хэш.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Хэш")]
        public virtual string HashValue
        { get; set; }
    }
}