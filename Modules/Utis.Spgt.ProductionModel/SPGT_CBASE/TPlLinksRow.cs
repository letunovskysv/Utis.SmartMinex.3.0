//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPlLinksRow – Связи светильников и людей. Срок хранения - 1 год.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Связи светильников и людей. Срок хранения - 1 год.")]
    [Table("pl_links")]
    public class TPlLinksRow
    {
        /// <summary> Идентификатор связи.</summary>
        [DisplayName("Идентификатор связи")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Идентификатор светильника.</summary>
        [DisplayName("Идентификатор светильника")]
        [Column("lamp_id", TypeName = "int")]
        public int LampId { get; set; }

        /// <summary> Идентификатор радиоблока.</summary>
        [DisplayName("Идентификатор радиоблока")]
        [Column("rfu_id", TypeName = "int")]
        public int RfuId { get; set; }

        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Дата и время начала связи.</summary>
        [DisplayName("Дата и время начала связи")]
        [Column("datetime_begin", TypeName = "datetime")]
        public DateTime DatetimeBegin { get; set; }

        /// <summary> Дата и время окончания связи.</summary>
        [DisplayName("Дата и время окончания связи")]
        [Column("datetime_end", TypeName = "datetime")]
        public DateTime DatetimeEnd { get; set; }
    }
}
