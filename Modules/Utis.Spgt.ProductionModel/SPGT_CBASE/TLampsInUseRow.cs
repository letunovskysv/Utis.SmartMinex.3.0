//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLampsInUseRow – Выданные светильники. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Выданные светильники")]
    [Table("lamps_in_use")]
    public class TLampsInUseRow
    {
        /// <summary> Идентификатор светильника.</summary>
        [DisplayName("Идентификатор светильника")]
        [Column("lamp_id", TypeName = "int")]
        public int LampId { get; set; }

        /// <summary> Дата и время выдачи.</summary>
        [DisplayName("Дата и время выдачи")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Светильник выдан: 0-нет, 1-да.</summary>
        [DisplayName("Светильник выдан: 0-нет, 1-да")]
        [Column("in_use", TypeName = "bit")]
        public bool InUse { get; set; }

        /// <summary> Флаг выдачи взамен: 0-обычная выдача, 1-выдача взамен.</summary>
        [DisplayName("Флаг выдачи взамен: 0-обычная выдача, 1-выдача взамен")]
        [Column("instead", TypeName = "bit")]
        public bool Instead { get; set; }

        /// <summary> Идентификатор человека которому выдали светильник.</summary>
        [DisplayName("Идентификатор человека которому выдали светильник")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        #region Extensions

        /// <summary> [Расширение] Табельный номер сотрудника.</summary>
        [Column("person_id_tab_nom_view", TypeName = "int")]
        public int TabNo { get; set; }

        /// <summary> [Расширение] Фамилия сотрудника.</summary>
        [Column("person_id_lastname_view", TypeName = "nvarchar")]
        public string LastName { get; set; }

        /// <summary> [Расширение] Имя сотрудника.</summary>
        [Column("person_id_firstname_view", TypeName = "nvarchar")]
        public string FirstName { get; set; }

        /// <summary> [Расширение] Отчество сотрудника.</summary>
        [Column("person_id_middlename_view", TypeName = "nvarchar")]
        public string MiddleName { get; set; }

        /// <summary> [Расширение] Заводской номер светильника.</summary>
        [Column("lamp_id_serial_nom_view", TypeName = "nvarchar")]
        public string LampSerial { get; set; }

        /// <summary> [Расширение] Тип светильника.</summary>
        [Column("lamp_id_type_id_view", TypeName = "nvarchar")]
        public string LampType { get; set; }

        /// <summary> [Расширение] Номер ламповой.</summary>
        [Column("lamp_id_group_nom_view", TypeName = "nvarchar")]
        public string LampRoom { get; set; }

        #endregion Extensions
    }
}
