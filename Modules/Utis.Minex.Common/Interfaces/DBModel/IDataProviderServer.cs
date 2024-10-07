namespace Utis.Minex.Common
{
    /// <summary>
    /// Поставщик данных.
    /// </summary>
    [DisplayName("Поставщик данных")]
    public interface IDataProviderServer : IDevice
    {
        /// <summary>
        /// Имя или IP-адрес сервера.
        /// </summary>
        [DisplayName("Хост")]
        [Description("Имя или IP-адрес сервера")]
        string Host
        { get; set; }
    }
}
