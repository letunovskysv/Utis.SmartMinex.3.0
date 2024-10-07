using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Catalog
{
    /// <summary>
    /// Параметры передачи сообщения на пейджер
    /// </summary>
    [DisplayName("Параметры передачи сообщения на пейджер")]
    public class PagerSettings : CatalogBase
    {
        /// <summary>
        /// Флаг периодического повторения до подтверждения человеком
        /// </summary>
        [DisplayName("Флаг периодического повторения до подтверждения человеком")]
        public virtual int RepeatUntilConfirm { get; set; } = 10;

        /// <summary>
        /// Длительность (вибра) сигнала 0(250 мс)...3(1000мс)
        /// </summary>
        [DisplayName("Длительность (вибра) сигнала 0(250 мс)...3(1000мс)")]
        public virtual int SignalTime { get; set; } = 0;

        /// <summary>
        /// Длительность (вибра) паузы 0(250 мс)...3 (1000мс)
        /// </summary>
        [DisplayName("Длительность (вибра) паузы 0(250 мс)...3 (1000мс)")]
        public virtual int PauseTime { get; set; } = 3;
    }
}