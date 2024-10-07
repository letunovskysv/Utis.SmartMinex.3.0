namespace Utis.Minex.Common
{
    /// <summary>
    /// Считыватели неконтролирующие АТО.
    /// </summary>
    [DisplayName("Считыватели неконтролирующие АТО")]
    public interface IReadersDontControlMarkPoint : ICatalog
    {
        /// <summary>
        ///  АТО.
        /// </summary>
        [DisplayName("АТО")]
        public IMarkPoint MarkPoint
        { get; set; }

        /// <summary>
        ///  Устройство.
        /// </summary>
        [DisplayName("Устройство")]
        public IReader Reader
        { get; set; }
    }
}
