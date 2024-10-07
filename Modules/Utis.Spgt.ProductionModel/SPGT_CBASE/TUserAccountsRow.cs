//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TUserAccountsRow – Пользователи системы. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Пользователи системы")]
    [Table("user_accounts")]
    public class TUserAccountsRow
    {
        /// <summary> Идентификатор пользователя.</summary>
        [DisplayName("Идентификатор пользователя")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Логин пользователя.</summary>
        [DisplayName("Логин пользователя")]
        [Column("login", TypeName = "nvarchar")]
        public string Login { get; set; }
    }
}
