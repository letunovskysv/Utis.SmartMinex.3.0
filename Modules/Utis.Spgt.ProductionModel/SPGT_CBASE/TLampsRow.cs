//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLampsRow – Светильники. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Светильники")]
    [Table("lamps")]
    public class TLampsRow
    {
        /// <summary> Идентификатор светильника.</summary>
        [DisplayName("Идентификатор светильника")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Идентификатор радиоблока.</summary>
        [DisplayName("Идентификатор радиоблока")]
        [Column("rfu_id", TypeName = "int")]
        public int RfuId { get; set; }

        /// <summary> Идентификатор второго радиоблока.</summary>
        [DisplayName("Идентификатор второго радиоблока")]
        [Column("rfu2_id", TypeName = "int")]
        public int Rfu2Id { get; set; }

        /// <summary> Идентификатор глона.</summary>
        [DisplayName("Идентификатор глона")]
        [Column("glon_id", TypeName = "int")]
        public int GlonId { get; set; }

        /// <summary> Заводской номер светильника.</summary>
        [DisplayName("Заводской номер светильника")]
        [Column("serial_nom", TypeName = "int")]
        public int SerialNom { get; set; }

        /// <summary> Внутришахтный номер (обозначение) светильника.</summary>
        [DisplayName("Внутришахтный номер (обозначение) светильника")]
        [Column("lamp_nom", TypeName = "nvarchar")]
        public string LampNom { get; set; }

        /// <summary> Номер ламповой.</summary>
        [DisplayName("Номер ламповой")]
        [Column("group_nom", TypeName = "int")]
        public int GroupNom { get; set; }

        /// <summary> Тип светильника.</summary>
        [DisplayName("Тип светильника")]
        [Column("type_id", TypeName = "int")]
        public int TypeId { get; set; }

        /// <summary> Дата поступления.</summary>
        [DisplayName("Дата поступления")]
        [Column("expl_begin", TypeName = "datetime")]
        public DateTime ExplBegin { get; set; }

        /// <summary> Дата списания.</summary>
        [DisplayName("Дата списания")]
        [Column("expl_end", TypeName = "datetime")]
        public DateTime ExplEnd { get; set; }

        /// <summary> Дата окончания срока гарантии.</summary>
        [DisplayName("Дата окончания срока гарантии")]
        [Column("warranty_end", TypeName = "datetime")]
        public DateTime WarrantyEnd { get; set; }

        /// <summary> Дата окончания срока эксплуатации.</summary>
        [DisplayName("Дата окончания срока эксплуатации")]
        [Column("lifetime_end", TypeName = "datetime")]
        public DateTime LifetimeEnd { get; set; }

        /// <summary> Состояние светильника.</summary>
        [DisplayName("Состояние светильника")]
        [Column("lamp_state", TypeName = "int")]
        public int LampState { get; set; }

        /// <summary> Дата и время изменения состояния светильника.</summary>
        [DisplayName("Дата и время изменения состояния светильника")]
        [Column("lamp_state_changed", TypeName = "datetime")]
        public DateTime LampStateChanged { get; set; }
        public string SelfRescuerNum { get; set; }

        public string View => string.Concat(SerialNom);
    }
}
