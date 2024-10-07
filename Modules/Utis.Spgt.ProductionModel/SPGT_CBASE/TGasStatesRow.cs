//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGasStatesRow – Справочник состояний канала газа. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний канала газа")]
    [Table("gas_states")]
    public class TGasStatesRow
    {
        /// <summary> Код состояния (0-отказ канала, 1-канал отключен, 2- канал исправен).</summary>
        [DisplayName("Код состояния (0-отказ канала, 1-канал отключен, 2- канал исправен)")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
