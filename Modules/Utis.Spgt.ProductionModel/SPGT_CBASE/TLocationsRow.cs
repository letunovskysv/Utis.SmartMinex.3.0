//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLocationsRow – Схема расположений. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Схема расположений")]
    [Table("locations")]
    public class TLocationsRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Внешний идентификатор.</summary>
        [DisplayName("Внешний идентификатор")]
        [Column("external_id", TypeName = "bigint")]
        public long ExternalId { get; set; }

        /// <summary> Идентификатор родителя.</summary>
        [DisplayName("Идентификатор родителя")]
        [Column("parent_id", TypeName = "int")]
        public int ParentId { get; set; }

        /// <summary> Идентификатор типа расположения.</summary>
        [DisplayName("Идентификатор типа расположения")]
        [Column("type_id", TypeName = "int")]
        public int TypeId { get; set; }

        /// <summary> Наименование места.</summary>
        [DisplayName("Наименование места")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
