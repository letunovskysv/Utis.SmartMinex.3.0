using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Devices
{
    using Utis.Minex.Common;

    /// <summary>
    /// Справочник стационарных автономных точек отметки.
    /// </summary>
    [DisplayName("Справочник автономных точек отметки")]
    public class MarkPoint : ZoneDefineDevice, IMarkPoint
    {
        /// <summary>
        /// Серийный номер.
        /// </summary>
        [DisplayName("Серийный")]
        [Description("Серийный номер")]
        public virtual int? Serial
        { get; set; }

        /// <summary>
        /// Статус АТО.
        /// </summary>
        [DisplayName("Статус АТО")]
        public virtual MarkPointState MarkPointState
        { get; set; }

        /// <summary>
        /// Версия прошивки.
        /// </summary>
        [DisplayName("Прошивка")]
        [Description("Версия прошивки")]
        public virtual string FirmwareVersion
        { get; set; }

        /// <summary>
        /// Выработки
        /// </summary>
        [DisplayName("Выработки")]
        public virtual string Workings { get; set; }
    }
}