using Utis.Minex.Common.Settings;

namespace Utis.Minex.Common.Interfaces
{
    public interface IGrpcSettings : ISettingsManagerBase
    {
        /// <summary>
        /// Путь к папке логирования служб gRPC.
        /// </summary>
        [DisplayName("Путь к папке логирования служб gRPC")]
        string GrpcLogFolderPath
        { get; set; }

        /// <summary>
        /// Путь к папке сохранения архива логов служб gRPC.
        /// </summary>
        [DisplayName("Путь к папке сохранения архива логов служб gRPC")]
        string GrpcCollectLogFolderPath
        { get; set; }

        /// <summary>
        /// Уровень сжатия данных gRPC.
        /// 0 - No compression.
        /// 1 - Low compression.
        /// 2 - Medium compression.
        /// 3 - High compression.
        /// </summary>
        [DisplayName("Уровень сжатия данных gRPC")]
        int GrpcCompressionLevel
        { get; set; }

        /// <summary>
        /// Детализация логгирования gRPC.
        /// </summary>
        [DisplayName("Детализация логгирования gRPC")]
        string GRPC_TRACE
        { get; set; }

        /// <summary>
        /// Уровень логгирования gRPC.
        /// DEBUG - log all gRPC messages
        /// INFO  - log INFO and ERROR message
        /// ERROR - log only errors (default)
        /// NONE  - won't log any
        /// </summary>
        [DisplayName("Уровень логгирования gRPC")]
        string GRPC_VERBOSITY
        { get; set; }

        /// <summary>
        /// Уровень логгирования FUZZER gRPC.
        /// </summary>
        [DisplayName("Уровень логгирования FUZZER gRPC")]
        string GRPC_TRACE_FUZZER
        { get; set; }

        /// <summary>
        /// Уровень логгирования трассировки стека (stacktrace gRPC).
        /// Один из DEBUG, INFO, ERROR или NONE.
        /// </summary>
        [DisplayName("Уровень логгирования stacktrace gRPC")]
        string GRPC_STACKTRACE_MINLOGLEVEL
        { get; set; }
    }
}
