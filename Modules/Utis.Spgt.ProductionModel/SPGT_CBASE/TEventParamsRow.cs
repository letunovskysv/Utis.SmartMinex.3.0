//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TEventParamsRow – Параметры событий системы. Срок хранения - 3 месяца.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Параметры событий системы. Срок хранения - 3 месяца.")]
    [Table("event_params")]
    public class TEventParamsRow
    {
        /// <summary> Идентификатор  события.</summary>
        [DisplayName("Идентификатор  события")]
        [Column("event_id", TypeName = "int")]
        public int EventId { get; set; }

        /// <summary> Имя переменной.</summary>
        [DisplayName("Имя переменной")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Значение переменной.</summary>
        [DisplayName("Значение переменной")]
        [Column("val", TypeName = "int")]
        public int Val { get; set; }
    }
}
