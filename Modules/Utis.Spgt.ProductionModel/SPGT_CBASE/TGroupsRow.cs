//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGroupsRow – Группы пользователей системы. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Группы пользователей системы")]
    [Table("groups")]
    public class TGroupsRow
    {
        /// <summary> Идентификатор группы.</summary>
        [DisplayName("Идентификатор группы")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название группы пользователей.</summary>
        [DisplayName("Название группы пользователей")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Имя роли в БД.</summary>
        [DisplayName("Имя роли в БД")]
        [Column("db_role", TypeName = "nvarchar")]
        public string DbRole { get; set; }
    }
}
