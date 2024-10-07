
namespace Utis.Minex.ProductionModel.Realtime
{
    using Utis.Minex.Common;

    /// <summary>
    /// Тэг реального времени
    /// </summary>
    [DisplayName("Справочник тэгов")]
    public class Tag
    {
        /// <summary>
        /// Описание, комментарий
        /// </summary>
        [DisplayName("Описание")]
        [Description("Произвольный комментарий")]
        public string Description 
        { get; set; }

        /// <summary>
        /// Источник значения
        /// </summary>
        [DisplayName("Источник значения")]
        public CatalogBase Source 
        { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [DisplayName("Значение")]
        public string TagValue 
        { get; set; }

        /// <summary>
        /// Тип значения
        /// </summary>
        [DisplayName("Тип значения")]
        public string ValueType 
        { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DisplayName("Имя")]
        public string Name
        { get; set; }
    }
}