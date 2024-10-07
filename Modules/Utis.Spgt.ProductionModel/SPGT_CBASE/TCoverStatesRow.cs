//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TCoverStatesRow – Справочник состояний крышки считывателя. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний крышки считывателя")]
    [Table("cover_states")]
    public class TCoverStatesRow
    {
        /// <summary> Коды состояний крышки считывателя: 0-закрыта; 1-открыта.</summary>
        [DisplayName("Коды состояний крышки считывателя: 0-закрыта; 1-открыта")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
