//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRfuTypesRow – Типы радиоблоков. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Типы радиоблоков")]
    [Table("rfu_types")]
    public class TRfuTypesRow
    {
        /// <summary> Идентификатор типа радиоблока: 1-субр-01см, 2-субр-02см, 3-субр-03см, 4-МГ01 Исеть.</summary>
        [DisplayName("Идентификатор типа радиоблока: 1-субр-01см, 2-субр-02см, 3-субр-03см, 4-МГ01 Исеть")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название типа.</summary>
        [DisplayName("Название типа")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
