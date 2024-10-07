//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLampTypesRow – Типы светильников. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Типы светильников")]
    [Table("lamp_types")]
    public class TLampTypesRow
    {
        /// <summary> Идентификатор типа светильника.</summary>
        [DisplayName("Идентификатор типа светильника")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название типа светильника.</summary>
        [DisplayName("Название типа светильника")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
