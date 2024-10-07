//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TTimeInMineRow – Время спуска людей в шахту и время до которого разрешено находится в шахте с возможностью продления. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Время спуска людей в шахту и время до которого разрешено находится в шахте с возможностью продления")]
    [Table("time_in_mine")]
    public class TTimeInMineRow
    {
        /// <summary> Номер метки.</summary>
        [DisplayName("Номер метки")]
        [Column("met_nom", TypeName = "int")]
        public int MetNom { get; set; }

        /// <summary> Время спуска в шахту.</summary>
        [DisplayName("Время спуска в шахту")]
        [Column("descent_datetime", TypeName = "datetime")]
        public DateTime DescentDatetime { get; set; }

        /// <summary> Кол-во продлений срока.</summary>
        [DisplayName("Кол-во продлений срока")]
        [Column("ext_count", TypeName = "int")]
        public int ExtCount { get; set; }

        /// <summary> Время, до которого продлено разрешение.</summary>
        [DisplayName("Время, до которого продлено разрешение")]
        [Column("ext_to_datetime", TypeName = "datetime")]
        public DateTime ExtToDatetime { get; set; }

        /// <summary> Превышение разрешенного времени.</summary>
        [DisplayName("Превышение разрешенного времени")]
        [Column("excess", TypeName = "int")]
        public int Excess { get; set; }
    }
}
