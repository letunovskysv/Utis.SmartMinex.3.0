//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TRfUnitsRow – Радиоблоки. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Радиоблоки")]
    [Table("rf_units")]
    public class TRfUnitsRow
    {
        /// <summary> Идентификатор радиоблока.</summary>
        [DisplayName("Идентификатор радиоблока")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Заводской номер радиоблока.</summary>
        [DisplayName("Заводской номер радиоблока")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Номер метки радиоблока.</summary>
        [DisplayName("Номер метки радиоблока")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Идентификатор типа радиоблока.</summary>
        [DisplayName("Идентификатор типа радиоблока")]
        [Column("type_id", TypeName = "int")]
        public int TypeId { get; set; }

        /// <summary> Дата поступлания.</summary>
        [DisplayName("Дата поступлания")]
        [Column("expl_begin", TypeName = "datetime")]
        public DateTime ExplBegin { get; set; }

        /// <summary> Дата списания.</summary>
        [DisplayName("Дата списания")]
        [Column("expl_end", TypeName = "datetime")]
        public DateTime ExplEnd { get; set; }

        /// <summary> Дата окончания гарантийного срока.</summary>
        [DisplayName("Дата окончания гарантийного срока")]
        [Column("warranty_end", TypeName = "datetime")]
        public DateTime WarrantyEnd { get; set; }

        /// <summary> Дата окончания срока эксплуатации.</summary>
        [DisplayName("Дата окончания срока эксплуатации")]
        [Column("lifetime_end", TypeName = "datetime")]
        public DateTime LifetimeEnd { get; set; }

        /// <summary> Состояние радиоблока.</summary>
        [DisplayName("Состояние радиоблока")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Дата и время изменения состояния радиоблока.</summary>
        [DisplayName("Дата и время изменения состояния радиоблока")]
        [Column("state_changed", TypeName = "datetime")]
        public DateTime StateChanged { get; set; }

        /// <summary> Тип радиоблока (для СУБРа).</summary>
        [DisplayName("Тип радиоблока (для СУБРа)")]
        [Column("rx_type", TypeName = "int")]
        public int RxType { get; set; }
    }
}
