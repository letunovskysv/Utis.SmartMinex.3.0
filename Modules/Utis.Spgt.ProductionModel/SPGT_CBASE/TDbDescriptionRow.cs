//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDbDescriptionRow – Описание базы данных. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Описание базы данных")]
    [Table("db_description")]
    public class TDbDescriptionRow
    {
        /// <summary> Идентификатор программы.</summary>
        [DisplayName("Идентификатор программы")]
        [Column("prog_id", TypeName = "nvarchar")]
        public string ProgId { get; set; }

        /// <summary> Версия доступности.</summary>
        [DisplayName("Версия доступности")]
        [Column("ver", TypeName = "int")]
        public int Ver { get; set; }

        /// <summary> Дата изменения.</summary>
        [DisplayName("Дата изменения")]
        [Column("ver_datetime", TypeName = "datetime")]
        public DateTime VerDatetime { get; set; }
    }
}
