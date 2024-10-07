//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPeopleReportRow – Разрешение для SPGTSTLAMPS на people_report.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Разрешение для SPGTSTLAMPS на people_report.")]
    [Table("people_report")]
    public class TPeopleReportRow
    {
        /// <summary> Время.</summary>
        [DisplayName("Время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Код операции.</summary>
        [DisplayName("Код операции")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }
    }
}
