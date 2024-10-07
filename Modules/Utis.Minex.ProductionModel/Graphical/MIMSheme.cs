
namespace Utis.Minex.ProductionModel.Graphical
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Catalog.Organize;

    #endregion

    public class MIMSheme : VersionObjectBase
    {
        /// <summary>
        /// Ветка.
        /// </summary>
        [DisplayName("Ветка")]
        public virtual MIMShemeBranch Branch
        { get; set; }

        /// <summary>
        /// Коментарий.
        /// </summary>
        [DisplayName("Коментарий")]
        public virtual string Comment 
        { get; set; }

        /// <summary>
        /// Коммит.
        /// </summary>
        [DisplayName("Коммит")]
        public virtual string Guid 
        { get; set; }

        /// <summary>
        /// Коммиты.
        /// </summary>
        [DisplayName("Коммиты")]
        public virtual string Guids 
        { get; set; }

        /// <summary>
        /// ИМР.
        /// </summary>
        [DisplayName("ИМР")]
        public virtual byte[] Data 
        { get; set; }

        /// <summary>
        /// Изменения.
        /// </summary>
        [DisplayName("Изменения")]
        public virtual byte[] Changes 
        { get; set; }

        /// <summary>
        /// Человек.
        /// </summary>
        [DisplayName("Человек")]
        public virtual Person Person 
        { get; set; }

        [DisplayName("Изменения графа")]
        public virtual bool IsGraphChanged 
        { get; set; }
    }
}