
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using
        
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

    #endregion

    /// <summary>
    /// Журнал выдачи радиостанций
    /// </summary>
    public class RadioBindJournal : PersonBindResponsibleJournal
    {
        /// <summary>
        /// Радиостанция.
        /// </summary>
        [DisplayName("Радиостанция")]
        public virtual Radio Radio
        { get; set; }
    }
}
