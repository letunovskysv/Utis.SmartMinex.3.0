//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPlLinksDefaultRow – Постоянные (дефолтные) привязки светильников рабочим. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Постоянные (дефолтные) привязки светильников рабочим")]
    [Table("pl_links_default")]
    public class TPlLinksDefaultRow
    {
        /// <summary> Идентификатор светильника.</summary>
        [DisplayName("Идентификатор светильника")]
        [Column("lamp_id", TypeName = "int")]
        public int LampId { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }
    }
}
