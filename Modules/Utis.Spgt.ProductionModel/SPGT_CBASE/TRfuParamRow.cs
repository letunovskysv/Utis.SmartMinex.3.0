//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRfuParamRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("rfu_param")]
    public class TRfuParamRow
    {
        public int MetNom { get; set; }
        public int MetType { get; set; }
        public int ValType { get; set; }
        public string Val { get; set; }
        public DateTime Dt { get; set; }
    }
}
