
namespace Utis.Minex.ProductionModel.Notes
{
    using Utis.Minex.Common;

    /// <summary>
    /// Двоичные данные журнала параметров АТО
    /// </summary>
    [DisplayName("Двоичные данные журнала параметров АТО")]
    public class MarkPointParametrsRaw : NamedObjectBase
    {
        /// <summary>
        /// Запись в журнале.
        /// </summary>
        [DisplayName("Запись в журнале")]
        public virtual MarkPointParametrsRaw MarkPointParametrs 
        { get; set; }

        /// <summary>
        /// Данные.
        /// </summary>
        [DisplayName("Данные")]
        public virtual byte[] Data 
        { get; set; }
    }
}