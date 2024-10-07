//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TEventsRow – Журнал событий с квитированием. Срок хранения - 3 месяца.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Журнал событий с квитированием. Срок хранения - 3 месяца.")]
    [Table("events")]
    public class TEventsRow
    {
        /// <summary> Идентификатор события.</summary>
        [DisplayName("Идентификатор события")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Код события.</summary>
        [DisplayName("Код события")]
        [Column("type_id", TypeName = "int")]
        public int TypeId { get; set; }

        /// <summary> Время возникновения события.</summary>
        [DisplayName("Время возникновения события")]
        [Column("beginning_datetime", TypeName = "datetime")]
        public DateTime BeginningDatetime { get; set; }

        /// <summary> Идентификатор квитировавшего пользователя.</summary>
        [DisplayName("Идентификатор квитировавшего пользователя")]
        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; }

        /// <summary> Дата и время квитирования.</summary>
        [DisplayName("Дата и время квитирования")]
        [Column("confirmation_datetime", TypeName = "datetime")]
        public DateTime ConfirmationDatetime { get; set; }
    }
}
