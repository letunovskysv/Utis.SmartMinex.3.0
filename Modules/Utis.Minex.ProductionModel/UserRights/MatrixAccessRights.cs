namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Матрица соответствия прав доступа.
    /// </summary>
    [DisplayName("Матрица соответствия прав доступа")]
    [Description("Матрица соответствия прав доступа")]

    [RegisterChanges(true)]
    public class MatrixAccessRights : CatalogBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль")]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Ресурс.
        /// </summary>
        [DisplayName("Ресурс")]
        [Description("Имя ресурса")]
        public virtual ResourceType ResourceType
        { get; set; }

        /// <summary>
        /// Доступ.
        /// </summary>
        [DisplayName("Доступ")]
        [Description("Тип доступа (CRUD)")]
        [RegisterChangesOnCreate(true)]
        public virtual RoleActionType ActionType
        { get; set; }
    }
}