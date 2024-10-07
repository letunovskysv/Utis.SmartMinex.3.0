namespace Utis.Minex.Common
{
    /// <summary>
    /// Глобальные константы.
    /// </summary>
    public static class Constants
    {
        /// <summary>Префикс для DTO сборок</summary>
        public static readonly string DTO_POSTFIX = "DTO";

        /// <summary>Главный префикс для всех проектов</summary>
        public static readonly string UTIS_NAMESPACE_PERFIX = "Utis";

        /// <summary>Главный префикс для всего проекта namespace</summary>
        public static readonly string MAIN_NAMESPACE_PREFIX = "Utis.Minex";

        /// <summary>Пространство имён прото-модели протокола UTProto</summary>
        public static readonly string PROTO_MODEL_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.ProtoModel";

        /// <summary>Metamodel model Namespace</summary>
        public static readonly string META_MODEL_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.MetadataModel";

        /// <summary>Production model Namespace</summary>
        public static readonly string PROD_MODEL_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.ProductionModel";

        /// <summary>Interaction model Namespace</summary>
        public static readonly string INTER_MODEL_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.InteractionModel";

        /// <summary>DataAquisition model Namespace </summary>
        public static readonly string DATAACQ_MODEL_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.DataAcquisitionModel";

        public static readonly string CROSSMODULAR_EVENTS_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.CrossmodularEvents";

        /// <summary>Modules model namespace</summary>
        public static readonly string MODULES_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.Modules";

        /// <summary>Bussines namespace</summary>
        public static readonly string BUSINESS_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.Business";

        /// <summary>Patches namespace</summary>
        public static readonly string PATCHES_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.Patches";

        /// <summary>Common namespace</summary>
        public static readonly string COMMON_NAMESPACE = $"{MAIN_NAMESPACE_PREFIX}.Common";

        /// <summary>Register dimension namespace</summary>
        public static readonly string REGISTER_DIMENSION_POSTFIX = "RDimension";

        /// <summary>Register value namespace</summary>
        public static readonly string REGISTER_VALUE_POSTFIX = "RValue";

        /// <summary>Unified register namespace</summary>
        public static readonly string REGISTER_POSTFIX = "Register";

        /// <summary>Маска mdtype </summary>
        public static readonly long MASK_MDTYPE = 0x400000000000L;

        /// <summary>Маска выделения RowId</summary>
        public static readonly long MASK_ROWID = 0x3FFFFFFFFFFFL;
    }
}