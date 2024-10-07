//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TVariablesRow – Таблица для хранения различных переменных. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Таблица для хранения различных переменных")]
    [Table("variables")]
    public class TVariablesRow
    {
        /// <summary> Имя переменной.</summary>
        [DisplayName("Имя переменной")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }

        /// <summary> Значение типа integer.</summary>
        [DisplayName("Значение типа int")]
        [Column("int_value", TypeName = "int")]
        public int IntValue { get; set; }

        /// <summary> Значение типа timestamp.</summary>
        [DisplayName("Значение типа timestamp")]
        [Column("datetime_value", TypeName = "datetime")]
        public DateTime DatetimeValue { get; set; }

        /// <summary> Значение типа float.</summary>
        [DisplayName("Значение типа float")]
        [Column("float_value", TypeName = "varbinary")]
        public string FloatValue { get; set; }

        /// <summary> Значение типа varchar.</summary>
        [DisplayName("Значение типа varchar")]
        [Column("str_value", TypeName = "nvarchar")]
        public string StrValue { get; set; }
    }
}
