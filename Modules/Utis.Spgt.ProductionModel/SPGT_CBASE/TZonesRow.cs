//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TZonesRow – Зоны. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Зоны")]
    [Table("zones")]
    public class TZonesRow
    {
        /// <summary> Номер зоны.</summary>
        [DisplayName("Номер зоны")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Название зоны.</summary>
        [DisplayName("Название зоны")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
        public int Safetime { get; set; }
    }
}
