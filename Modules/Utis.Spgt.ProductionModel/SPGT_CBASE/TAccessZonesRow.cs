//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TAccessZonesRow – Доступ в зоны. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Доступ в зоны")]
    [Table("access_zones")]
    public class TAccessZonesRow
    {
        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Идентификатор зоны.</summary>
        [DisplayName("Идентификатор зоны")]
        [Column("zone_id", TypeName = "int")]
        public int ZoneId { get; set; }

        /// <summary> Дата и время изменения записи.</summary>
        [DisplayName("Дата и время изменения записи")]
        [Column("dt", TypeName = "datetime")]
        public DateTime Dt { get; set; }
    }
}
