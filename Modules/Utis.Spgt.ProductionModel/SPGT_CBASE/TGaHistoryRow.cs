//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGaHistoryRow – История сдачи/выдачи газоанализаторов ГА. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("История сдачи/выдачи газоанализаторов ГА")]
    [Table("ga_history")]
    public class TGaHistoryRow
    {
        /// <summary> Идентификатор таблицы.</summary>
        [DisplayName("Идентификатор таблицы")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Номер метки ГА.</summary>
        [DisplayName("Номер метки ГА")]
        [Column("ga_met_nom", TypeName = "int")]
        public int GaMetNom { get; set; }

        /// <summary> Дата и время регистрации.</summary>
        [DisplayName("Дата и время регистрации")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Серийный номер ГА.</summary>
        [DisplayName("Серийный номер ГА")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Год выпуска ГА.</summary>
        [DisplayName("Год выпуска ГА")]
        [Column("serial_year", TypeName = "int")]
        public int SerialYear { get; set; }

        /// <summary> Идентификатор сотрудника, которому выдан ГА.</summary>
        [DisplayName("Идентификатор сотрудника, которому выдан ГА")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Тип операции 1 - выдача, 0 - сдача ГА.</summary>
        [DisplayName("Тип операции 1 - выдача, 0 - сдача ГА")]
        [Column("type", TypeName = "int")]
        public int Type { get; set; }
    }
}
