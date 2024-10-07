//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLastRegAlarmDataRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("last_reg_alarm_data")]
    public class TLastRegAlarmDataRow
    {
        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_num", TypeName = "int")]
        public int MetNum { get; set; }

        /// <summary> Тип данных 0-авария, 1-индивидуальный вызов.</summary>
        [DisplayName("Тип данных 0-авария, 1-индивидуальный вызов")]
        [Column("type", TypeName = "int")]
        public int Type { get; set; }

        /// <summary> Номер аварии.</summary>
        [DisplayName("Номер аварии")]
        [Column("alarm_num", TypeName = "int")]
        public int AlarmNum { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Идентификатор зоны антенна 1.</summary>
        [DisplayName("Идентификатор зоны антенна 1")]
        [Column("zone1_id", TypeName = "int")]
        public int Zone1Id { get; set; }

        /// <summary> Идентификатор зоны антенна 2.</summary>
        [DisplayName("Идентификатор зоны антенна 2")]
        [Column("zone2_id", TypeName = "int")]
        public int Zone2Id { get; set; }

        /// <summary> Идентификатор зоны антенна 3.</summary>
        [DisplayName("Идентификатор зоны антенна 3")]
        [Column("zone3_id", TypeName = "int")]
        public int Zone3Id { get; set; }

        /// <summary> Идентификатор зоны антенна 4.</summary>
        [DisplayName("Идентификатор зоны антенна 4")]
        [Column("zone4_id", TypeName = "int")]
        public int Zone4Id { get; set; }

        /// <summary> Дата и время получения аварии меткой.</summary>
        [DisplayName("Дата и время получения аварии меткой")]
        [Column("dt_receive", TypeName = "datetime")]
        public DateTime DtReceive { get; set; }

        /// <summary> Дата и время записи в базу.</summary>
        [DisplayName("Дата и время записи в базу")]
        [Column("dt_write", TypeName = "datetime")]
        public DateTime DtWrite { get; set; }
    }
}
