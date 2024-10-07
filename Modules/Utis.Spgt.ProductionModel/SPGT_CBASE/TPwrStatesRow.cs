//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPwrStatesRow – Состояния источников питания. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Состояния источников питания")]
    [Table("pwr_states")]
    public class TPwrStatesRow
    {
        /// <summary> Состояние: 0-источник работает от батареи; 1-источник исправен (работает от внешней сети).</summary>
        [DisplayName("Состояние: 0-источник работает от батареи; 1-источник исправен (работает от внешней сети)")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
