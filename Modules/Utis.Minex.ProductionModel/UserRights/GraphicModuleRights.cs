namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    /// <summary>
    /// Права доступа к графическому модулю.
    /// </summary>
    [DisplayName("Права доступа к графическому модулю")]
    [Description("Матрица доступа к графическому модулю в зависимости от роли")]
    [RegisterChanges(true)]
    public class GraphicModuleRights : CatalogBase
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
        /// Обозреватель 3Dx.
        /// </summary>
        [DisplayName("Обозреватель 3Dx")]
        [RegisterChangesOnCreate(true)]
        public virtual bool AccessViewer3Dx
        { get; set; }

        /// <summary>
        /// Воспроизведение 3D.
        /// </summary>
        [DisplayName("Воспроизведение 3D")]
        [Description("Воспроизведение 3D")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnablePlayBack
        { get; set; }

        /// <summary>
        /// Сообщение об Аварии.
        /// </summary>
        [DisplayName("Сообщение об Аварии")]
        [Description("Сообщение об Аварии")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableEmergencyCall
        { get; set; }

        /// <summary>
        /// Сброс сообщения об Аварии.
        /// </summary>
        [DisplayName("Сброс сообщения об Аварии")]
        [Description("Сброс сообщения об Аварии")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableEmergencyReset
        { get; set; }

        /// <summary>
        /// Сообщение на пейджер.
        /// </summary>
        [DisplayName("Сообщение на пейджер")]
        [Description("Сообщение на пейджер")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnablePagerCall
        { get; set; }

        /// <summary>
        /// Редактор.
        /// </summary>
        [DisplayName("Редактор")]
        [Description("Редактор")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableSchemeEditor
        { get; set; }

        /// <summary>
        /// Индивидуальные вызовы.
        /// </summary>
        [DisplayName("Индивидуальные вызовы")]
        [Description("Индивидуальные вызовы")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableIndividualCalls
        { get; set; }

        /// <summary>
        /// Редактор 3D.
        /// </summary>
        [DisplayName("Редактор 3D")]
        [Description("Редактор 3D")]
        [RegisterChangesOnCreate(true)]
        public virtual bool EnableEditor3D
        { get; set; }
    }
}