namespace Utis.Minex.Common
{
    /// <summary>
    /// Base object for metadata.
    /// </summary>
    [Description("Метаописание")]
    [DisplayName("Метаописание")]
    public abstract class MetadataObjectBase : CatalogBase
    {
        /// <summary>
        /// Тип.
        /// </summary>
        [DisplayName("Тип объекта")]
        public virtual string Type 
        { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [DisplayName("Описание")]
        [Description("Описание")]
        public virtual string Description 
        { get; set; }

        /// <summary>
        /// Условный код сущности справочника.
        /// </summary>
        [DisplayName("Код")]
        [Description("Условный код")]        
        public virtual string Code
        { get; set; }
    }
}