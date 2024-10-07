//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGasRow – Названия газов. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Названия газов")]
    [Table("gas")]
    public class TGasRow
    {
        /// <summary> Идентификатор газа.</summary>
        [DisplayName("Идентификатор газа")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название.</summary>
        [DisplayName("Название")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Еденица измерения.</summary>
        [DisplayName("Еденица измерения")]
        [Column("unit", TypeName = "nvarchar")]
        public string Unit { get; set; }
    }
}
