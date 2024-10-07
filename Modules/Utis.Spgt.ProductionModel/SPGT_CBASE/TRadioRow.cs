//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRadioRow – Радиостанции. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Радиостанции")]
    [Table("radio")]
    public class TRadioRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Индивидуальный номер радиостанции.</summary>
        [DisplayName("Индивидуальный номер радиостанции")]
        [Column("ind_num", TypeName = "int")]
        public int IndNum { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }
    }
}
