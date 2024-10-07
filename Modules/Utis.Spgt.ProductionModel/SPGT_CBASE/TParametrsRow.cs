//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TParametrsRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("parametrs")]
    public class TParametrsRow
    {
        /// <summary> Идентификатор устройства.</summary>
        [DisplayName("Идентификатор устройства")]
        [Column("device_id", TypeName = "int")]
        public int DeviceId { get; set; }

        /// <summary> Идентификатор типа параметра.</summary>
        [DisplayName("Идентификатор типа параметра")]
        [Column("par_type_id", TypeName = "int")]
        public int ParTypeId { get; set; }

        /// <summary> Значение параметра double.</summary>
        [DisplayName("Значение параметра double")]
        [Column("val_dp", TypeName = "double")]
        public string ValDp { get; set; }

        /// <summary> Значение параметра дата и время.</summary>
        [DisplayName("Значение параметра дата и время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Значение параметра строка.</summary>
        [DisplayName("Значение параметра строка")]
        [Column("val_str", TypeName = "nvarchar")]
        public string ValStr { get; set; }
    }
}
