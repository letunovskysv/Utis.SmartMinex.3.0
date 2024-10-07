//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TMapsRow – Файлы графики. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Файлы графики")]
    [Table("maps")]
    public class TMapsRow
    {
        /// <summary> Дата и время сохранения файла графики.</summary>
        [DisplayName("Дата и время сохранения файла графики")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Файл графики.</summary>
        [DisplayName("Файл графики")]
        [Column("map", TypeName = "varbinary")]
        public byte[] Map { get; set; }
    }
}
