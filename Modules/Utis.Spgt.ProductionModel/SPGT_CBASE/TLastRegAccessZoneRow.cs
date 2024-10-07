//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLastRegAccessZoneRow – Последняя регистрация доступа в зону. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Последняя регистрация доступа в зону")]
    [Table("last_reg_access_zone")]
    public class TLastRegAccessZoneRow
    {
        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Идентификатор зоны.</summary>
        [DisplayName("Идентификатор зоны")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Вход в зону - 1, выход из зоны - 0.</summary>
        [DisplayName("Вход в зону - 1, выход из зоны - 0")]
        [Column("in_zone", TypeName = "int")]
        public int InZone { get; set; }

        /// <summary> Дата и время последней регистрации.</summary>
        [DisplayName("Дата и время последней регистрации")]
        [Column("dt", TypeName = "datetime")]
        public DateTime Dt { get; set; }
    }
}
