//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TLiftRow – Точное позиционирование клети. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Точное позиционирование клети")]
    [Table("lift")]
    public class TLiftRow
    {
        /// <summary> Идентификатор считывателя.</summary>
        [DisplayName("Идентификатор считывателя")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Дистанция до клети.</summary>
        [DisplayName("Дистанция до клети")]
        [Column("dist", TypeName = "int")]
        public int Dist { get; set; }

        /// <summary> Дата и время последней регистрации.</summary>
        [DisplayName("Дата и время последней регистрации")]
        [Column("dt", TypeName = "datetime")]
        public DateTime Dt { get; set; }

        /// <summary> Номер метки позиционирования клети.</summary>
        [DisplayName("Номер метки позиционирования клети")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }
    }
}
