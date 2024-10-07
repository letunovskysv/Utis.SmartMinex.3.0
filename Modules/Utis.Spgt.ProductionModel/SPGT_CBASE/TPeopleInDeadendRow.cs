//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPeopleInDeadendRow – Люди в тупиковой выработке. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Люди в тупиковой выработке")]
    [Table("people_in_deadend")]
    public class TPeopleInDeadendRow
    {
        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Время вхождения в тупик.</summary>
        [DisplayName("Время вхождения в тупик")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Сообщение послано: 0-нет, 1-да.</summary>
        [DisplayName("Сообщение послано: 0-нет, 1-да")]
        [Column("event_sended", TypeName = "int")]
        public int EventSended { get; set; }
    }
}
