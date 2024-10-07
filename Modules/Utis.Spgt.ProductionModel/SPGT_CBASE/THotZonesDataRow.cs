//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: THotZonesDataRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("hot_zones_data")]
    public class THotZonesDataRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Дата и время перехода зоны в состояние горячая.</summary>
        [DisplayName("Дата и время перехода зоны в состояние горячая")]
        [Column("datetime_begin", TypeName = "datetime")]
        public DateTime DatetimeBegin { get; set; }

        /// <summary> Дата и время перехода зоны в состояние холодная.</summary>
        [DisplayName("Дата и время перехода зоны в состояние холодная")]
        [Column("datetime_end", TypeName = "datetime")]
        public DateTime DatetimeEnd { get; set; }

        /// <summary> Пороговое значение превышени.</summary>
        [DisplayName("Пороговое значение превышени")]
        [Column("alarm", TypeName = "int")]
        public int Alarm { get; set; }

        /// <summary> Идентификатор зоны.</summary>
        [DisplayName("Идентификатор зоны")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }
    }
}
