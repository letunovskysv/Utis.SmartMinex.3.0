//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TTimeInHotZonesRow – . База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("")]
    [Table("time_in_hot_zones")]
    public class TTimeInHotZonesRow
    {
        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Количество минут проведенных в горячих зона.</summary>
        [DisplayName("Количество минут проведенных в горячих зона")]
        [Column("count_time", TypeName = "int")]
        public int CountTime { get; set; }

        /// <summary> Дата и время.</summary>
        [DisplayName("Дата и время")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Флаг индикации отправки события превышения времени.</summary>
        [DisplayName("Флаг индикации отправки события превышения времени")]
        [Column("event_sended", TypeName = "int")]
        public int EventSended { get; set; }
    }
}
