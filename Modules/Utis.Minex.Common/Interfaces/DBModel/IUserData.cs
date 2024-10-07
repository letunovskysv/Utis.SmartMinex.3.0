using System;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Справочник персонала.
    /// </summary>
    [DisplayName("Персонал")]
    [Description("Справочник персонала")]
    public interface IUserData : IObjectNamed
    {
        [DisplayName("Логин")]
       string UserName{ get; set; }

        /// <summary>
        /// ФИО cотрудника.
        /// </summary>
        [DisplayName("ФИО cотрудника")]
        string PersonFullName{ get; set; }
    }
}
