//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TInLiftRow – Список меток в лифте. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Список меток в лифте")]
    [Table("in_lift")]
    public class TInLiftRow
    {
        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_num", TypeName = "int")]
        public int MetNum { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Идентификатор горизонта.</summary>
        [DisplayName("Идентификатор горизонта")]
        [Column("level_id", TypeName = "int")]
        public int LevelId { get; set; }

        /// <summary> Идентификатор зоны 1.</summary>
        [DisplayName("Идентификатор зоны 1")]
        [Column("zone1_id", TypeName = "int")]
        public int Zone1Id { get; set; }

        /// <summary> Идентификатор зоны 2.</summary>
        [DisplayName("Идентификатор зоны 2")]
        [Column("zone2_id", TypeName = "int")]
        public int Zone2Id { get; set; }

        /// <summary> Идентификатор зоны 3.</summary>
        [DisplayName("Идентификатор зоны 3")]
        [Column("zone3_id", TypeName = "int")]
        public int Zone3Id { get; set; }

        /// <summary> Идентификатор зоны 4.</summary>
        [DisplayName("Идентификатор зоны 4")]
        [Column("zone4_id", TypeName = "int")]
        public int Zone4Id { get; set; }

        /// <summary> Дата и время последней регистрации.</summary>
        [DisplayName("Дата и время последней регистрации")]
        [Column("dt", TypeName = "datetime")]
        public DateTime Dt { get; set; }
        public int SrcMetNom { get; set; }
    }
}
