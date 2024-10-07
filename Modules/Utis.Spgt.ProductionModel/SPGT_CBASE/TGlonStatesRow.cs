//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGlonStatesRow – Справочник состояний глона. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний глона")]
    [Table("glon_states")]
    public class TGlonStatesRow
    {
        /// <summary> Код состояния глона: 0-состояние неизвестно, 1-исправен, 2-неисправен, 3-состояние неизвестно.</summary>
        [DisplayName("Код состояния глона: 0-состояние неизвестно, 1-исправен, 2-неисправен, 3-состояние неизвестно")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
