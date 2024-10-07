//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TDeviceClassesRow – Вид устройств. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Вид устройств")]
    [Table("device_classes")]
    public class TDeviceClassesRow
    {
        /// <summary> Идентификатор вида устройств.</summary>
        [DisplayName("Идентификатор вида устройств")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название видов устройств.</summary>
        [DisplayName("Название видов устройств")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Коментарии к типу параметра.</summary>
        [DisplayName("Коментарии к типу параметра")]
        [Column("note", TypeName = "nvarchar")]
        public string Note { get; set; }
    }
}
