namespace Utis.Minex.ProductionModel.Devices
{
    using Utis.Minex.Common;

    /// <summary>
    /// Считыватели неконтролирующие АТО.
    /// </summary>
    [DisplayName("Считыватели неконтролирующие АТО")]
    public class ReadersDontControlMarkPoint : CatalogBase, IReadersDontControlMarkPoint
    {
        /// <summary>
        ///  Роль.
        /// </summary>
        [DisplayName("АТО")]
        public virtual MarkPoint MarkPoint
        { get; set; }

        /// <summary>
        ///  Роль.
        /// </summary>
        [DisplayName("Устройство")]
        public virtual Reader Reader
        { get; set; }

        IMarkPoint IReadersDontControlMarkPoint.MarkPoint 
        { get => MarkPoint; set => MarkPoint = value as MarkPoint; }
        IReader IReadersDontControlMarkPoint.Reader 
        { get => Reader;    set => Reader = value as Reader;       }

    }
}
