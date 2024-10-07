namespace Utis.Minex.Common
{
    /// <summary>
    /// Патчинг баз данных.
    /// </summary>
    public interface IPatchEngine
    {
        /// <summary>
        /// Запускает патчинг MetadataDB.
        /// </summary>
        void RunForMetadataDB();


        /// <summary>
        /// Запускает патчинг ProductionDB.
        /// </summary>
        void RunForProductionDB();

        /// <summary>
        /// Запускает патчинг InteractionDB.
        /// </summary>
        void RunForInteractionDB();

        /// <summary>
        /// Запускает патчинг DataAcquisitionDB.
        /// </summary>
        void RunForDataAcquisitionDB();

        /// <summary>
        /// Сохранить все патчи в MetadataDB, без их выполнения.
        /// </summary>
        void SetAllPatchSucsessMetadataDB();

        /// <summary>
        /// Сохранить все патчи в ProductionDB, без их выполнения.
        /// </summary>
        void SetAllPatchSucsessProductionDB();

        /// <summary>
        /// Сохранить все патчи в InteractionDB, без их выполнения.
        /// </summary>
        void SetAllPatchSucsessInteractionDB();

        /// <summary>
        /// Сохранить все патчи в DataAcquisitionDB, без их выполнения.
        /// </summary>
        void SetAllPatchSucsessDataAcquisitionDB();
    }
}
