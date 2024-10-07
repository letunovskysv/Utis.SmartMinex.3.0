//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPeopleReportOperationsRow – Справочник кодов оперяций для отчета о спуске.подъеме людей. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Справочник кодов оперяций для отчета о спуске.подъеме людей")]
    [Table("people_report_operations")]
    public class TPeopleReportOperationsRow
    {
        /// <summary> Идентификатор операции: 1-получение светильника; 2-сдача светильника; 3-спуск в шахту; 4-выход из шахты.</summary>
        [DisplayName("Идентификатор операции: 1-получение светильника; 2-сдача светильника; 3-спуск в шахту; 4-выход из шахты")]
        [Column("code", TypeName = "int")]
        public int Code { get; set; }

        /// <summary> Название операции.</summary>
        [DisplayName("Название операции")]
        [Column("name", TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}
