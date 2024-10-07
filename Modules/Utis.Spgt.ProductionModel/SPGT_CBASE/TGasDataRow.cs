//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGasDataRow – Данные газа. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Данные газа")]
    [Table("gas_data")]
    public class TGasDataRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Дата и время.</summary>
        [DisplayName("Дата и время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Номер газовой метки.</summary>
        [DisplayName("Номер газовой метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Идентификатор зоны.</summary>
        [DisplayName("Идентификатор зоны")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }

        /// <summary> Идентификатор газа.</summary>
        [DisplayName("Идентификатор газа")]
        [Column("gas", TypeName = "int")]
        public int Gas { get; set; }

        /// <summary> Состояние канала.</summary>
        [DisplayName("Состояние канала")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Максимальное (минимальное) значение концентрации.</summary>
        [DisplayName("Максимальное (минимальное) значение концентрации")]
        [Column("extremum", TypeName = "double")]
        public string Extremum { get; set; }

        /// <summary> Количество мгновенных измерений с экстремальными значениями.</summary>
        [DisplayName("Количество мгновенных измерений с экстремальными значениями")]
        [Column("extremum_count", TypeName = "int")]
        public int ExtremumCount { get; set; }

        /// <summary> Количество переходов через уровень аварийного порога.</summary>
        [DisplayName("Количество переходов через уровень аварийного порога")]
        [Column("extremum_level_count", TypeName = "int")]
        public int ExtremumLevelCount { get; set; }

        /// <summary> Cреднее значение концентрации.</summary>
        [DisplayName("Cреднее значение концентрации")]
        [Column("average", TypeName = "double")]
        public string Average { get; set; }

        /// <summary> Среднее значение концентрации для экстремальных значений.</summary>
        [DisplayName("Среднее значение концентрации для экстремальных значений")]
        [Column("extremum_average", TypeName = "double")]
        public string ExtremumAverage { get; set; }
    }
}
