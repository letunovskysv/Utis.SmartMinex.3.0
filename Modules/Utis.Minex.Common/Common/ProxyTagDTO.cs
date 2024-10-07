
namespace Utis.Minex.Common
{
    using Utis.Minex.Common.Enum;

    /// <summary>
    /// Proxy-тэг.
    /// </summary>
    [DisplayName("Proxy-тэг")]
    public class ProxyTagDTO
    {
        /// <summary>
        /// Наименование свойства.
        /// </summary>
        [DisplayName("Наименование свойства")]
        public ProxyTagType ProxyTagType 
        { get; set; }

        /// <summary>
        /// Значение свойства.
        /// </summary>
        [DisplayName("Значение свойства")]
        public object Value 
        { get; set; }

        /// <summary>
        /// Признак добавления или удаления прокситэга, удаляются они только в плэйбэке в обратной перемотке, при прямом течении времени это не нужно
        /// </summary>
        [DisplayName("Действие с прокситэгом")]
        public ProxyTagActionType ActionType 
        { get; set; } = ProxyTagActionType.AddOrUpdate; 
    }
}