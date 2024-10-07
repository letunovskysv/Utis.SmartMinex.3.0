
namespace Utis.Minex.ProductionModel.Journals
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Простой.
    /// </summary>
    [DisplayName("Простой")]
    [RegisterChanges(true)]
    public class Downtime : DateOutJournal
    {
        /// <summary>
        /// Причина простоя.
        /// </summary>
        [DisplayName("Причина простоя")]
        public virtual ReasonDowntime ReasonDowntime
        { get; set; }

        /// <summary>
        /// Транспорт.
        /// </summary>
        [DisplayName("Транспорт")]
        [RegisterChangesOnCreate(true)]
        public virtual Transport Transport
        { get; set; }

        /// <summary>
        /// Человек указавший простой.
        /// </summary>
        [DisplayName("Человек указавший простой")]
        public virtual Person PersonSetBegin
        { get; set; }

        /// <summary>
        /// Человек указавший причину простоя.
        /// </summary>
        [DisplayName("Человек указавший причину простоя")]
        public virtual Person PersonSetReason
        { get; set; }

        /// <summary>
        /// Человек указавший конец простоя.
        /// </summary>
        [DisplayName("Человек указавший конец простоя")]
        public virtual Person PersonSetEnd
        { get; set; }

        /// <summary>
        /// Подробности простоя.
        /// </summary>
        [DisplayName("Подробности простоя")]
        public virtual string DowntimeDetail
        { get; set; }
    }
}