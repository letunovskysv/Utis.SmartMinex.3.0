//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPeopleRow – Люди. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Люди")]
    [Table("people")]
    public class TPeopleRow
    {
        /// <summary> Идентификатор человека.</summary>
        [DisplayName("Идентификатор человека")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Табельный номер. Для подрядчиков и гостей = Null.</summary>
        [DisplayName("Табельный номер. Для подрядчиков и гостей = Null")]
        [Column("tab_nom", TypeName = "int")]
        public int TabNom { get; set; }

        /// <summary> Фамилия.</summary>
        [DisplayName("Фамилия")]
        [Column("lastname", TypeName = "nvarchar")]
        public string Lastname { get; set; }

        /// <summary> Имя.</summary>
        [DisplayName("Имя")]
        [Column("firstname", TypeName = "nvarchar")]
        public string Firstname { get; set; }

        /// <summary> Отчество.</summary>
        [DisplayName("Отчество")]
        [Column("middlename", TypeName = "nvarchar")]
        public string Middlename { get; set; }

        /// <summary> Идентификатор должности. Для подрядчиков и гостей = Null.</summary>
        [DisplayName("Идентификатор должности. Для подрядчиков и гостей = Null")]
        [Column("appointment_id", TypeName = "int")]
        public int AppointmentId { get; set; }

        /// <summary> Идентификатор отдела (участка). Для подрядчиков и гостей = Null.</summary>
        [DisplayName("Идентификатор отдела (участка). Для подрядчиков и гостей = Null")]
        [Column("department_id", TypeName = "int")]
        public int DepartmentId { get; set; }

        /// <summary> Квалификация (разряд).</summary>
        [DisplayName("Квалификация (разряд)")]
        [Column("qualification", TypeName = "nvarchar")]
        public string Qualification { get; set; }

        /// <summary> Категория человека.</summary>
        [DisplayName("Категория человека")]
        [Column("staff_ctg", TypeName = "int")]
        public int StaffCtg { get; set; }

        /// <summary> Дата увольнения.</summary>
        [DisplayName("Дата увольнения")]
        [Column("dismissal_datetime", TypeName = "datetime")]
        public DateTime DismissalDatetime { get; set; }

        /// <summary> Табельный номер уволенного человека.</summary>
        [DisplayName("Табельный номер уволенного человека")]
        [Column("dismissal_tab_nom", TypeName = "int")]
        public int DismissalTabNom { get; set; }

        /// <summary> Режим вывода табеля: 1-по УРС, 2-по считывателям..</summary>
        [DisplayName("Режим вывода табеля: 1-по УРС, 2-по считывателям.")]
        [Column("tabel_mode", TypeName = "int")]
        public int TabelMode { get; set; }

        /// <summary> Идентификатор (код) предприятия..</summary>
        [DisplayName("Идентификатор (код) предприятия.")]
        [Column("company_id", TypeName = "int")]
        public int CompanyId { get; set; }
        public int MedicCheck { get; set; }

        /// <summary> признак о необходимости прохождения алкотестирования.</summary>
        [DisplayName("признак о необходимости прохождения алкотестирования")]
        [Column("alcohol_test", TypeName = "int")]
        public int AlcoholTest { get; set; }

        public string View => string.Concat("(", TabNom, ") ", Lastname, " ", Firstname, " ", Middlename);
    }
}
