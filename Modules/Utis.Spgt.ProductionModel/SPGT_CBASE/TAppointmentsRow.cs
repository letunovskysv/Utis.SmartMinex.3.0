//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TAppointmentsRow – Должности. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Должности")]
    [Table("appointments")]
    public class TAppointmentsRow
    {
        /// <summary> Идентификатор должности.</summary>
        [DisplayName("Идентификатор должности")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Признак ИТР / не ИТР (1 / 0).</summary>
        [DisplayName("Признак ИТР / не ИТР (1 / 0)")]
        [Column("engeneer", TypeName = "int")]
        public int Engeneer { get; set; }

        /// <summary> Название должности..</summary>
        [DisplayName("Название должности.")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
