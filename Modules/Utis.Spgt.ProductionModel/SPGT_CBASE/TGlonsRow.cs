//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGlonsRow – Газоанализаторы. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Газоанализаторы")]
    [Table("glons")]
    public class TGlonsRow
    {
        /// <summary> Идентификатор глона.</summary>
        [DisplayName("Идентификатор глона")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Заводской номер.</summary>
        [DisplayName("Заводской номер")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Дата поступления.</summary>
        [DisplayName("Дата поступления")]
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

        /// <summary> Состояние.</summary>
        [DisplayName("Состояние")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Время изменения сотояния.</summary>
        [DisplayName("Время изменения сотояния")]
        [Column("state_changed", TypeName = "datetime")]
        public DateTime StateChanged { get; set; }

        /// <summary> Канал.</summary>
        [DisplayName("Канал")]
        [Column("channel", TypeName = "int")]
        public int Channel { get; set; }

        /// <summary> Частота.</summary>
        [DisplayName("Частота")]
        [Column("freq", TypeName = "int")]
        public int Freq { get; set; }
    }
}
