namespace Utis.Minex.Common.Interfaces
{
    public interface ISslClientSettings
    {
        /// <summary>
        /// Корневой сертификат удостоверяющего центра.
        /// </summary>
        [DisplayName("Корневой сертификат удостоверяющего центра")]
        string SslCaFile
        { get; set; }
    }

    public interface ISslServerSettings
    {
        /// <summary>
        /// Файл сертификата сервера.
        /// </summary>
        [DisplayName("Файл сертификата сервера")]
        string SslCrtFile
        { get; set; }

        /// <summary>
        /// Файл закрытого ключа сертификата сервера.
        /// </summary>
        [DisplayName("Файл закрытого ключа сертификата сервера")]
        string SslKeyFile
        { get; set; }
    }
}
