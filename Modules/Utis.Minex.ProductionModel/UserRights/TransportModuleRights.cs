using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel
{
    /// <summary>
    /// Права доступа к модулю управления транспортом
    /// </summary>
    [DisplayName("Права доступа к модулю управления транспортом")]
    [Description("Матрица доступа к модулю управления транспортом в зависимости от роли")]
    [RegisterChanges(true)]
    public class TransportModuleRights : CatalogBase
    {
        /// <summary>
        /// Роль.
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль")]
        [RegisterChangesOnCreate(true)]
        public virtual Role Role
        { get; set; }

        /// <summary>
        /// Распределение транспорта
        /// </summary>
        [DisplayName("Распределение транспорта")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableTransportChiefControl
        { get; set; }

        /// <summary>
        /// Открытые простои
        /// </summary>
        [DisplayName("Открытые простои")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableOpenedDowntimeControl
        { get; set; }
    }
}
