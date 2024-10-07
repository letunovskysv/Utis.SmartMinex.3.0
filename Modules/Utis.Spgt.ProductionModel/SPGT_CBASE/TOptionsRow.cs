//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TOptionsRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("options")]
    public class TOptionsRow
    {
        /// <summary> Тип устройства.</summary>
        [DisplayName("Тип устройства")]
        [Column("dev_type_id", TypeName = "int")]
        public int DevTypeId { get; set; }

        /// <summary> Тип параметра.</summary>
        [DisplayName("Тип параметра")]
        [Column("par_type_id", TypeName = "int")]
        public int ParTypeId { get; set; }
    }
}
