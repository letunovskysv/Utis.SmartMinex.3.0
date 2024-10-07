//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TVacationsRow – График отпусков работников. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("График отпусков работников")]
    [Table("vacations")]
    public class TVacationsRow
    {
        /// <summary> Идентификатор таблицы.</summary>
        [DisplayName("Идентификатор таблицы")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Дата и время начала отпуска.</summary>
        [DisplayName("Дата и время начала отпуска")]
        [Column("dt_begin", TypeName = "datetime")]
        public DateTime DtBegin { get; set; }

        /// <summary> Дата и время конца отпуска.</summary>
        [DisplayName("Дата и время конца отпуска")]
        [Column("dt_end", TypeName = "datetime")]
        public DateTime DtEnd { get; set; }
    }
}
