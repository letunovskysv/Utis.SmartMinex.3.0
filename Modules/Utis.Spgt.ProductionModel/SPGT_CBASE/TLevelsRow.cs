//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLevelsRow – Горизонты. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Горизонты")]
    [Table("levels")]
    public class TLevelsRow
    {
        /// <summary> Идентификатор горизонта.</summary>
        [DisplayName("Идентификатор горизонта")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название горизонта.</summary>
        [DisplayName("Название горизонта")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Поверхность: 0-горизонт в шахте; 1-горизонт является поверхностью (пром.площадка).</summary>
        [DisplayName("Поверхность: 0-горизонт в шахте; 1-горизонт является поверхностью (пром.площадка)")]
        [Column("zero_level", TypeName = "int")]
        public int ZeroLevel { get; set; }

        /// <summary> Идентификатор места расположения.</summary>
        [DisplayName("Идентификатор места расположения")]
        [Column("location_id", TypeName = "int")]
        public int LocationId { get; set; }
    }
}
