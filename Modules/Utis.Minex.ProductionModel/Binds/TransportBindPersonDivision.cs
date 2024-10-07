
namespace Utis.Minex.ProductionModel.Binds
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    /// <summary>
    /// Журнал распределённой техники
    /// </summary>
    public class TransportBindPersonDivision : VersionObjectBase
    {
        /// <summary>
        /// Человек.
        /// </summary>
        [DisplayName("Человек")]
        public virtual Person Person 
        { get; set; }

        /// <summary>
        /// Транспорт.
        /// </summary>
        [DisplayName("транспорт")]
        public virtual Transport Transport 
        { get; set; }

        /// <summary>
        /// Назначенный участок для работы.
        /// </summary>
        [DisplayName("Участок работы")]
        public virtual Division Division 
        { get; set; }

        /// <summary>
        /// Дата/время начала привязки.
        /// </summary>
        [DisplayName("Дата/время начала привязки")]
        public virtual System.DateTime? DateIn
        { get; set; }

        /// <summary>
        /// Дата/время окончания привязки.
        /// </summary>
        [DisplayName("Дата/время окончания привязки")]
        public virtual System.DateTime? DateOut
        { get; set; }
    }
}