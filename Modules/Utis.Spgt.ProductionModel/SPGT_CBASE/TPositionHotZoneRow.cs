//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPositionHotZoneRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("position_hot_zone")]
    public class TPositionHotZoneRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Метка позиционирования.</summary>
        [DisplayName("Метка позиционирования")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Идентификатор данных перехода зоны в горячее состояние.</summary>
        [DisplayName("Идентификатор данных перехода зоны в горячее состояние")]
        [Column("hot_zone_id", TypeName = "int")]
        public int HotZoneId { get; set; }

        /// <summary> Дата и время появления в горячей зоне.</summary>
        [DisplayName("Дата и время появления в горячей зоне")]
        [Column("datetime_begin", TypeName = "datetime")]
        public DateTime DatetimeBegin { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Дата и время выхода из горячей зоны.</summary>
        [DisplayName("Дата и время выхода из горячей зоны")]
        [Column("datetime_end", TypeName = "datetime")]
        public DateTime DatetimeEnd { get; set; }
    }
}
