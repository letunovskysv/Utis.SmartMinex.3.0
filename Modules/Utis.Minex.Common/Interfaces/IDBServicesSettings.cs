namespace Utis.Minex.Common.Interfaces
{
    public interface IDBServicesSettings
    {
        /// <summary>
        /// Хост для работы с gRPC службой операций с БД.
        /// </summary>
        [DisplayName("Хост для работы с gRPC службой операций с БД")]
        string DBServiceHost
        { get; set; }

         /// <summary>
        /// Порт для работы с gRPC службой операций с БД.
        /// </summary>
        [DisplayName("Порт для работы с gRPC службой операций с БД")]
        int DBServicePort
        { get; set; }

        /// <summary>
        /// Хост для работы с gRPC службой подписок.
        /// </summary>
        [DisplayName("Хост для работы с gRPC службой подписокe")]
        string SubscribeServiceHost
        { get; set; }

        /// <summary>
        /// Порт для работы с gRPC службой подписок.
        /// </summary>
        [DisplayName("Порт для работы с gRPC службой подписок")]
        int SubscribeServicePort
        { get; set; }
    }
}
