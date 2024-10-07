//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRfuStatesRow – Справочник состояний радиоблока. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний радиоблока")]
    [Table("rfu_states")]
    public class TRfuStatesRow
    {
        /// <summary> Коды состояний радиоблока: 0-в ремонте; 1-рабочий.</summary>
        [DisplayName("Коды состояний радиоблока: 0-в ремонте; 1-рабочий")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
