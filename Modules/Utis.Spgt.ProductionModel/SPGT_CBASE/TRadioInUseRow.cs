//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRadioInUseRow – Текущие выданные радиостанции. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Текущие выданные радиостанции")]
    [Table("radio_in_use")]
    public class TRadioInUseRow
    {
        /// <summary> Номер метки радиостанции.</summary>
        [DisplayName("Номер метки радиостанции")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Дата и время регистрации.</summary>
        [DisplayName("Дата и время регистрации")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Флаг выдачи: 0-не выдан, 1-выдан.</summary>
        [DisplayName("Флаг выдачи: 0-не выдан, 1-выдан")]
        [Column("in_use", TypeName = "int")]
        public int InUse { get; set; }

        /// <summary> Серийный номер радиостанции.</summary>
        [DisplayName("Серийный номер радиостанции")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Флаг выдачи: 0-не выдан, 1-выдан.</summary>
        [DisplayName("Флаг выдачи: 0-не выдан, 1-выдан")]
        [Column("in_mine", TypeName = "int")]
        public int InMine { get; set; }

        /// <summary> Идентификатор сотрудника, которому выдана радиостанция.</summary>
        [DisplayName("Идентификатор сотрудника, которому выдана радиостанция")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }
    }
}
