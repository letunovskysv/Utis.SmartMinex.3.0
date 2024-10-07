//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPowersRow – Источники питания. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Источники питания")]
    [Table("powers")]
    public class TPowersRow
    {
        /// <summary> Идентификатор источника питания.</summary>
        [DisplayName("Идентификатор источника питания")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Номер линии связи.</summary>
        [DisplayName("Номер линии связи")]
        [Column("line_nom", TypeName = "int")]
        public int LineNom { get; set; }

        /// <summary> Номер источника питания на линии.</summary>
        [DisplayName("Номер источника питания на линии")]
        [Column("pow_nom", TypeName = "int")]
        public int PowNom { get; set; }

        /// <summary> Название источника питания.</summary>
        [DisplayName("Название источника питания")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Состояние.</summary>
        [DisplayName("Состояние")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Дата и время изменения состояния.</summary>
        [DisplayName("Дата и время изменения состояния")]
        [Column("state_changed", TypeName = "datetime")]
        public DateTime StateChanged { get; set; }

        /// <summary> Идентификатор места расположения.</summary>
        [DisplayName("Идентификатор места расположения")]
        [Column("location_id", TypeName = "int")]
        public int LocationId { get; set; }
    }
}
