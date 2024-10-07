//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDataRow – Данные по перемещениям. Срок хранения - 1 месяц.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Данные по перемещениям. Срок хранения - 1 месяц.")]
    [Table("data")]
    public class TDataRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Дата и время.</summary>
        [DisplayName("Дата и время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

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

        /// <summary> Номер метки передавшего транзитные данные.</summary>
        [DisplayName("Номер метки передавшего транзитные данные")]
        [Column("src_met_nom", TypeName = "int")]
        public int SrcMetNom { get; set; }
    }
}
