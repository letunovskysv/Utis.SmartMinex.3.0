//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLocationTypesRow – Типы расположений. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Типы расположений")]
    [Table("location_types")]
    public class TLocationTypesRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Внешний идентификатор.</summary>
        [DisplayName("Внешний идентификатор")]
        [Column("external_id", TypeName = "bigint")]
        public long ExternalId { get; set; }

        /// <summary> Наименование типа расположения.</summary>
        [DisplayName("Наименование типа расположения")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
