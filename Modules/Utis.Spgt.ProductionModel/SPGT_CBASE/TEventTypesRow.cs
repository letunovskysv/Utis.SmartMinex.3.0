//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TEventTypesRow – Справочник событий системы. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник событий системы")]
    [Table("event_types")]
    public class TEventTypesRow
    {
        /// <summary> Идентификатор события (код).</summary>
        [DisplayName("Идентификатор события (код)")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Приоритет события: 0-самый низкий.</summary>
        [DisplayName("Приоритет события: 0-самый низкий")]
        [Column("priority", TypeName = "int")]
        public int Priority { get; set; }

        /// <summary> Текст события.</summary>
        [DisplayName("Текст события")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Группа событий: 0-аварийные события, 1-технологические события.</summary>
        [DisplayName("Группа событий: 0-аварийные события, 1-технологические события")]
        [Column("group", TypeName = "int")]
        public int Group { get; set; }
    }
}
