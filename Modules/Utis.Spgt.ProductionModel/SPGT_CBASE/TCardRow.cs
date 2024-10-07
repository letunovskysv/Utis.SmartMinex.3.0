//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TCardRow – Привязка карт доступа к людям.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Привязка карт доступа к людям.")]
    [Table("card")]
    public class TCardRow
    {
        /// <summary> Номер карты.</summary>
        [DisplayName("Номер карты")]
        [Column("num", TypeName = "bigint")]
        public long Num { get; set; }

        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }
    }
}
