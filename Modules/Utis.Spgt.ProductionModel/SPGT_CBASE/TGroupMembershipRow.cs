//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGroupMembershipRow – Учетные записи пользователей. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Учетные записи пользователей")]
    [Table("group_membership")]
    public class TGroupMembershipRow
    {
        /// <summary> Идентификатор пользователя.</summary>
        [DisplayName("Идентификатор пользователя")]
        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; }

        /// <summary> Идентификатор группы.</summary>
        [DisplayName("Идентификатор группы")]
        [Column("group_id", TypeName = "int")]
        public int GroupId { get; set; }
    }
}
