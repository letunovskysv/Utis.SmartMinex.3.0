//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRadioHistoryRow – История сдачи/выдачи радиостанций. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("История сдачи/выдачи радиостанций")]
    [Table("radio_history")]
    public class TRadioHistoryRow
    {
        /// <summary> Идентификатор таблицы.</summary>
        [DisplayName("Идентификатор таблицы")]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        /// <summary> Номер метки радиостанции.</summary>
        [DisplayName("Номер метки радиостанции")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Дата и время регистрации.</summary>
        [DisplayName("Дата и время регистрации")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Серийный номер радиостанции.</summary>
        [DisplayName("Серийный номер радиостанции")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Идентификатор сотрудника, которому выдана радиостанция.</summary>
        [DisplayName("Идентификатор сотрудника, которому выдана радиостанция")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Тип операции 1 - выдача/0 - сдача радиостанции.</summary>
        [DisplayName("Тип операции 1 - выдача/0 - сдача радиостанции")]
        [Column("type", TypeName = "int")]
        public int Type { get; set; }
    }
}
