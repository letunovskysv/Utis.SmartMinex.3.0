//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDepartmentsRow – Отделы (участки). База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Отделы (участки)")]
    [Table("departments")]
    public class TDepartmentsRow
    {
        /// <summary> Идентификатор отдела (участка).</summary>
        [DisplayName("Идентификатор отдела (участка)")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название отдела (участка).</summary>
        [DisplayName("Название отдела (участка)")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Организация.</summary>
        [DisplayName("Организация")]
        [Column("company_id", TypeName = "integer")]
        public int CompanyId { get; set; }
    }
}
