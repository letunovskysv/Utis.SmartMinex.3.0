//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGaInUseRow – Выданные газоанализаторы. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Выданные газоанализаторы")]
    [Table("ga_in_use")]
    public class TGaInUseRow
    {
        /// <summary> Номер метки газоанализатора.</summary>
        [DisplayName("Номер метки газоанализатора")]
        [Column("ga_met_nom", TypeName = "int")]
        public int GaMetNom { get; set; }

        /// <summary> Дата и время выдачи.</summary>
        [DisplayName("Дата и время выдачи")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Флаг выдачи: 0-не выдан, 1-выдан.</summary>
        [DisplayName("Флаг выдачи: 0-не выдан, 1-выдан")]
        [Column("in_use", TypeName = "int")]
        public int InUse { get; set; }

        /// <summary> Серийный номер газоанализатора.</summary>
        [DisplayName("Серийный номер газоанализатора")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Год выпуска газоанализатора.</summary>
        [DisplayName("Год выпуска газоанализатора")]
        [Column("serial_year", TypeName = "int")]
        public int SerialYear { get; set; }

        /// <summary> Флаг нахождения в шахте: 0-не в шахте, 1-в шахте.</summary>
        [DisplayName("Флаг нахождения в шахте: 0-не в шахте, 1-в шахте")]
        [Column("in_mine", TypeName = "int")]
        public int InMine { get; set; }

        /// <summary> Идентификатор сотрудника, которому выдан газоанализатор.</summary>
        [DisplayName("Идентификатор сотрудника, которому выдан газоанализатор")]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        /// <summary> Флаг состояния аварийного оповещения: 1-аварийное сообщение получено, 2-аварийное сообщение осознано.</summary>
        [DisplayName("Флаг состояния аварийного оповещения: 1-аварийное сообщение получено, 2-аварийное сообщение осознано")]
        [Column("alert_notify_state", TypeName = "int")]
        public int AlertNotifyState { get; set; }

        /// <summary> Время изменения состояния аварийного оповещения.</summary>
        [DisplayName("Время изменения состояния аварийного оповещения")]
        [Column("alert_notify_datetime", TypeName = "datetime")]
        public DateTime AlertNotifyDatetime { get; set; }
    }
}
