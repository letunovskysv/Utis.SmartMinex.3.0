//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TStaffCategoriesRow – Категории персонала. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Категории персонала")]
    [Table("staff_categories")]
    public class TStaffCategoriesRow
    {
        /// <summary> Код категории: 0-штатный сотрудник; 1-подрядчик; 2-гость.</summary>
        [DisplayName("Код категории: 0-штатный сотрудник; 1-подрядчик; 2-гость")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название категории.</summary>
        [DisplayName("Название категории")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
