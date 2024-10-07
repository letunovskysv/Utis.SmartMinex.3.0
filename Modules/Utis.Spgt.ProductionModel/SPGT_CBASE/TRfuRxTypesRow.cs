//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRfuRxTypesRow – Справочник типов радиоблоков (для Субра). База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник типов радиоблоков (для Субра)")]
    [Table("rfu_rx_types")]
    public class TRfuRxTypesRow
    {
        /// <summary> Коды типов радиоблока (для СУБРа): 0-прямой; 1-зеркальный.</summary>
        [DisplayName("Коды типов радиоблока (для СУБРа): 0-прямой; 1-зеркальный")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название типа.</summary>
        [DisplayName("Название типа")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
