//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TTrBeaconsRow – Список АТО. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Список АТО")]
    [Table("tr_beacons")]
    public class TTrBeaconsRow
    {
        /// <summary> Номер АТО.</summary>
        [DisplayName("Номер АТО")]
        [Column("num", TypeName = "int")]
        public int Num { get; set; }

        /// <summary> Описание.</summary>
        [DisplayName("Описание")]
        [Column("descr", TypeName = "nvarchar")]
        public string Descr { get; set; }

        /// <summary> Поле Тип АТО (0 - маршрут; 1 - загрузка).</summary>
        [DisplayName("Поле Тип АТО (0 - маршрут; 1 - загрузка)")]
        [Column("beacon_type", TypeName = "int")]
        public int BeaconType { get; set; }

        /// <summary> Зона.</summary>
        [DisplayName("Зона")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }

        /// <summary> Состояние (исправен, разряжен, удалён...).</summary>
        [DisplayName("Состояние (исправен, разряжен, удалён...)")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Дата-время разряда батареи АТО.</summary>
        [DisplayName("Дата-время разряда батареи АТО")]
        [Column("state_changed", TypeName = "datetime")]
        public DateTime StateChanged { get; set; }

        /// <summary> Идентификатор места расположения.</summary>
        [DisplayName("Идентификатор места расположения")]
        [Column("location_id", TypeName = "int")]
        public int LocationId { get; set; }
    }
}
