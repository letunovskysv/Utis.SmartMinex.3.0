
namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Матрица соответствия для обработки сообщения.
    /// </summary>
    [DisplayName("Матрица соответствия для обработки сообщения")]
    [Description("Матрица соответствия для обработки сообщения")]
    [RegisterChanges(true)]
    public class MatrixEventProcessingRights : CatalogBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль")]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Наименование типа сообщения.
        /// </summary>
        [DisplayName("Наименование типа сообщения")]
        [Description("Наименование типа сообщения")]
        public virtual ResourceEventType ResourceEventType
        { get; set; }

        /// <summary>
        /// Тип обработки сообщения.
        /// </summary>
        [DisplayName("Тип обработки сообщения")]
        [Description("Тип обработки сообщения")]
        [RegisterChangesOnCreate(true)]
        public virtual EventProcessingType ActionType
        { get; set; }
    }
}
