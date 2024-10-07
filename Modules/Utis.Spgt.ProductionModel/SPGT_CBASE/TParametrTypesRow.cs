//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TParametrTypesRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("parametr_types")]
    public class TParametrTypesRow
    {
        /// <summary> Идентификатор типа параметра.</summary>
        [DisplayName("Идентификатор типа параметра")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название типа параметра.</summary>
        [DisplayName("Название типа параметра")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Коментарии к типу параметра.</summary>
        [DisplayName("Коментарии к типу параметра")]
        [Column("note", TypeName = "nvarchar")]
        public string Note { get; set; }
    }
}
