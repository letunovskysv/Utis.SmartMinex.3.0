//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TJournalTempRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("journal_temp")]
    public class TJournalTempRow
    {
        /// <summary> Идентификатор журнала температуры.</summary>
        [DisplayName("Идентификатор журнала температуры")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор параметра.</summary>
        [DisplayName("Идентификатор параметра")]
        [Column("par_type_id", TypeName = "int")]
        public int ParTypeId { get; set; }

        /// <summary> Идентификатор устройства.</summary>
        [DisplayName("Идентификатор устройства")]
        [Column("device_id", TypeName = "int")]
        public int DeviceId { get; set; }

        /// <summary> Значение параметра температуры.</summary>
        [DisplayName("Значение параметра температуры")]
        [Column("val_dp", TypeName = "double")]
        public string ValDp { get; set; }

        /// <summary> Дата и время.</summary>
        [DisplayName("Дата и время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Идентификатор зоны.</summary>
        [DisplayName("Идентификатор зоны")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }

        /// <summary> Превышение температуры.</summary>
        [DisplayName("Превышение температуры")]
        [Column("excess", TypeName = "int")]
        public int Excess { get; set; }
    }
}
