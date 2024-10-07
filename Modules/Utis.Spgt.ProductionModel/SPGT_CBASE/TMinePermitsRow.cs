//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TMinePermitsRow – Разрешения на спуск в шахту. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Разрешения на спуск в шахту")]
    [Table("mine_permits")]
    public class TMinePermitsRow
    {
        /// <summary> Идентификатор допуска.</summary>
        [DisplayName("Идентификатор допуска")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Дата и время начала разрешения.</summary>
        [DisplayName("Дата и время начала разрешения")]
        [Column("datetime_begin", TypeName = "datetime")]
        public DateTime DatetimeBegin { get; set; }

        /// <summary> Дата и время окончания разрешения.</summary>
        [DisplayName("Дата и время окончания разрешения")]
        [Column("datetime_end", TypeName = "datetime")]
        public DateTime DatetimeEnd { get; set; }
    }
}
