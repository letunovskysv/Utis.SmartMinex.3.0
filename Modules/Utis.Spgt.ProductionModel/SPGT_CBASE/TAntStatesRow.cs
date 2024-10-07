//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TAntStatesRow – Справочник состояний антенн. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник состояний антенн")]
    [Table("ant_states")]
    public class TAntStatesRow
    {
        /// <summary> Коды состояний антенн: 0=Ок; 1=Антенна оборвана; 2=Антенна короткозамкнута; 128 (0x80)=Антенна не используется; 129 (0x81)=Контроль антенны отключен.</summary>
        [DisplayName("Коды состояний антенн: 0=Ок; 1=Антенна оборвана; 2=Антенна короткозамкнута; 128 (0x80)=Антенна не используется; 129 (0x81)=Контроль антенны отключен")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название состояния.</summary>
        [DisplayName("Название состояния")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
