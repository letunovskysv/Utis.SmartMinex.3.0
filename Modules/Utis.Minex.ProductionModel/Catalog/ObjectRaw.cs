namespace Utis.Minex.ProductionModel.Catalog
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Graphical;

        #endregion

    /// <summary>
    /// Представляет сущность хранения двоичных данных.
    /// </summary>
    [DisplayName("Двоичные данные")]
    public class ObjectRaw : CatalogBase
    {
        /// <summary>
        /// Инициализирует сущность хранения двоичных данных.
        /// </summary>
        public ObjectRaw() {}
        
        /// <summary>
        /// Инициализирует сущность хранения двоичных данных.
        /// </summary>
        /// <param name="data">Бинарные данные.</param>
        /// <param name="objectParent">Объект, с которым связаны данные.</param>
        /// <param name="fileExtension">Расширение файла.</param>
        public ObjectRaw(byte[] data, GraphicalObject objectParent, string fileExtension)
        {
            Data = data;
            ObjectParent = objectParent;
            FileExtension = fileExtension;
        }

        /// <summary>
        /// Данные.
        /// </summary>
        [DisplayName("Данные")]
        public virtual byte[] Data 
        { get; set; }

        /// <summary>
        /// Идентификатор объекта.
        /// </summary>
        [DisplayName("Идентификатор объекта")]
        public virtual GraphicalObject ObjectParent 
        { get; set; }

        /// <summary>
        /// Расширение файла.
        /// </summary>
        [DisplayName("Расширение файла")]
        public virtual string FileExtension 
        { get; set; }

        /// <summary>
        /// Признак архивных данных.
        /// </summary>
        [DisplayName("Признак архивных данных")]
        public virtual bool IsArchive 
        { get; set; }
    }
}