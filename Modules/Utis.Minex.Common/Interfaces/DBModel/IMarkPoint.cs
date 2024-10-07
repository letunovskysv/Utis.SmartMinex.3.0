namespace Utis.Minex.Common
{
    #region Using

    using Utis.Minex.Common.Enum;
    
    #endregion

    /// <summary>
    /// Справочник стационарных автономных точек отметки.
    /// </summary>
    [DisplayName("Справочник автономных точек отметки")]
    public interface IMarkPoint : IZoneDefineDevice
    {
        /// <summary>
        /// Серийный номер.
        /// </summary>
        [DisplayName("Серийный")]
        [Description("Серийный номер")]
        public int? Serial
        { get; set; }

        /// <summary>
        /// Статус АТО.
        /// </summary>
        [DisplayName("Статус АТО")]
        public MarkPointState MarkPointState
        { get; set; }

        /// <summary>
        /// Версия прошивки.
        /// </summary>
        [DisplayName("Прошивка")]
        [Description("Версия прошивки")]
        public string FirmwareVersion
        { get; set; }

        /// <summary>
        /// Выработки
        /// </summary>
        [DisplayName("Выработки")]
        public string Workings { get; set; }
    }
}
