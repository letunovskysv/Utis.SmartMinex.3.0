
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

    #endregion

    /// <summary>
    /// Журнал выдачи газоанализаторов.
    /// </summary>
    public class GasAnalyzerBindJournal : PersonBindResponsibleJournal
    {
        /// <summary>
        /// Газоанализатор (устройство обнаружения).
        /// </summary>
        [DisplayName("Газоанализатор")]
        public virtual GasAnalyzer GasAnalyzer
        { get; set; }
    }
}
