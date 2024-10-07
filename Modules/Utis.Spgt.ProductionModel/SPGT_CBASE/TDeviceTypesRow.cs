//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDeviceTypesRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("device_types")]
    public class TDeviceTypesRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название типа устройства.</summary>
        [DisplayName("Название типа устройства")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Класс устройства.</summary>
        [DisplayName("Класс устройства")]
        [Column("class_id", TypeName = "int")]
        public int ClassId { get; set; }
    }
}
