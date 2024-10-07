using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.UserRights
{
    /// <summary>
    /// Запрещенные пароли
    /// </summary>
    [DisplayName("Запрещенные пароли")]
    [Description("Запрещенные пароли")]
    public class PasswordBlackListRecord : VersionObjectBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Пароль")]
        [Description("Пароль")]
        public virtual string Password
        { get; set; }
    }
}
