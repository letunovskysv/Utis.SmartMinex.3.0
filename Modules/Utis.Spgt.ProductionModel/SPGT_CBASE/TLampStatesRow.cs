//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLampStatesRow – Состояния светильников. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Состояния светильников")]
    [Table("lamp_states")]
    public class TLampStatesRow
    {
        /// <summary> Код состояния светильника: 0-в ремонте; 1-в работе; 2-в резерве.</summary>
        [DisplayName("Код состояния светильника: 0-в ремонте; 1-в работе; 2-в резерве")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
