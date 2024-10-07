//--------------------------------------------------------------------------------------------------
// (C) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TGaAvarRow – Сигнал аварии от газоанализаторов. База данных. DTO.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Spgt
{
    #region Using
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    #endregion Using

    [Description("Сигнал аварии от газоанализаторов")]
    [Table("ga_avar")]
    public class TGaAvarRow
    {
        /// <summary> Идентификатор.</summary>
        [DisplayName("Идентификатор")]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary> Номер метки газоанализатора.</summary>
        [DisplayName("Номер метки газоанализатора")]
        [Column("ga_met_nom", TypeName = "int")]
        public int GaMetNom { get; set; }

        /// <summary> Дата и время подачи аварии от газоанализатора.</summary>
        [DisplayName("Дата и время подачи аварии от газоанализатора")]
        [Column("ga_datetime", TypeName = "datetime")]
        public DateTime GaDatetime { get; set; }

        /// <summary> Дата и время поступления сигнала.</summary>
        [DisplayName("Дата и время поступления сигнала")]
        [Column("datetime", TypeName = "datetime")]
        public DateTime Datetime { get; set; }

        /// <summary> Состояние: 1-поступил, 2-отображается, 3-обработан.</summary>
        [DisplayName("Состояние: 1-поступил, 2-отображается, 3-обработан")]
        [Column("state", TypeName = "int")]
        public int State { get; set; }

        /// <summary> Идентификатор считывателя, получившего сигнал аварии.</summary>
        [DisplayName("Идентификатор считывателя, получившего сигнал аварии")]
        [Column("reader_id", TypeName = "int")]
        public int ReaderId { get; set; }

        /// <summary> Дата и время начала отсчета таймера автоматического включения сигнала аварии.</summary>
        [DisplayName("Дата и время начала отсчета таймера автоматического включения сигнала аварии")]
        [Column("timer_begin_datetime", TypeName = "datetime")]
        public DateTime TimerBeginDatetime { get; set; }

        /// <summary> Результат: 1-Диспетчер включил аварию, 2-Диспетчер отменил, 3-Автоматическое включение аварии сервером.</summary>
        [DisplayName("Результат: 1-Диспетчер включил аварию, 2-Диспетчер отменил, 3-Автоматическое включение аварии сервером")]
        [Column("result", TypeName = "int")]
        public int Result { get; set; }
    }
}
