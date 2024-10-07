//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRefBcnStatesRow – Справочник кодов состояния АТО.. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник кодов состояния АТО.")]
    [Table("ref_bcn_states")]
    public class TRefBcnStatesRow
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
