//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TMigrationHistoryRow – ??????? ????????? ???? ??????. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("??????? ????????? ???? ??????")]
    [Table("migration_history")]
    public class TMigrationHistoryRow
    {
        public int Id { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int Revision { get; set; }
        public DateTime AppliedDatetime { get; set; }
    }
}
