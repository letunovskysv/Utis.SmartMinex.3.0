//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TCompaniesRow – Список предприятий.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Список предприятий.")]
    [Table("companies")]
    public class TCompaniesRow
    {
        /// <summary> Идентификатор (код) предприятия..</summary>
        [DisplayName("Идентификатор (код) предприятия.")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название предприятия..</summary>
        [DisplayName("Название предприятия.")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
