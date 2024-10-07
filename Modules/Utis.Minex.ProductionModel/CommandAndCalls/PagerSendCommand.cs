
namespace Utis.Minex.ProductionModel.CommandAndCalls
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    #endregion

    /// <summary>
    /// Команда отправки сообщения.
    /// </summary>
    [DisplayName("Команда отправки сообщения")]
    public class PagerSendCommand : CommandCallBase
    {
        /// <summary>
        /// Количество вибраций.
        /// </summary>
        [DisplayName("Количество вибраций")]
        public virtual int Vibration 
        { get; set; }

        /// <summary>
        /// Сообщение.
        /// </summary>
        [DisplayName("Сообщение")]
        public virtual string Text 
        { get; set; }

        /// <summary>
        /// Флаг периодического повторения до подтверждения человеком.
        /// </summary>
        [DisplayName("Флаг периодического повторения до подтверждения человеком")]
        public virtual int RepeatUntilConfirm
        { get; set; } = 10;

        /// <summary>
        /// Длительность (вибра) сигнала 250 мс (значение 0) 1000мс (значение 3).
        /// </summary>
        [DisplayName("Длительность (вибра) сигнала 250 мс (значение 0) 1000мс (значение 3)")]
        public virtual byte SignalTime 
        { get; set; }

        /// <summary>
        /// Длительность (вибра) паузы 250 мс (значение 0) 1000мс (значение 3).
        /// </summary>
        [DisplayName("Длительность (вибра) паузы 250 мс (значение 0) 1000мс (значение 3)")]
        public virtual byte PauseTime 
        { get; set; } = 3;

        /// <summary>
        /// Тип канала передачи.
        /// </summary>
        [DisplayName("Тип канала передачи")]
        public virtual PagerChannelType PagerChannelType
        { get; set; }
    }
}