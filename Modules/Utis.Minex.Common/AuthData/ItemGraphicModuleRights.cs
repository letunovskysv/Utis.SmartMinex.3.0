namespace Utis.Minex.Common
{
    /// <summary>
    /// Запсить в таблице "Права доступа к графическому модулю".
    /// </summary>
    public class ItemGraphicModuleRights
    {
        /// <summary>
        /// Обозреватель 3Dx.
        /// </summary>
        public bool AccessViewer3Dx
        { get; init; }

        /// <summary>
        /// Отбражение Воспроизведения 3D.
        /// </summary>
        public bool EnablePlayBack
        { get; init; }

        /// <summary>
        /// Отображение сообщения об Аварии.
        /// </summary>
        public bool EnableEmergencyCall
        { get; init; }

        /// <summary>
        /// Отображение Сброса сообщения об Аварии.
        /// </summary>
        public bool EnableEmergencyReset
        { get; init; }

        /// <summary>
        /// Отображение отправки сообщения на пейджер.
        /// </summary>
        public bool EnablePagerCall
        { get; init; }

        /// <summary>
        /// Отображение Редактора.
        /// </summary>
        public bool EnableSchemeEditor
        { get; init; }

        /// <summary>
        /// Выполнение индивидуальных вызовов.
        /// </summary>
        public bool EnableIndividualCalls
        { get; init; }

        /// <summary>
        /// Отображение редактора 3D.
        /// </summary>
        public bool EnableEditor3D
        { get; init; }
    }
}
