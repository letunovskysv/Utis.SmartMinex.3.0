
namespace Utis.Minex.ProductionModel.Common
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Поставщик данных.
    /// </summary>
    [DisplayName("Поставщик данных")]
    public class DataProviderServer : Device, IDataProviderServer
    {
        /// <summary>
        /// Имя или IP-адрес сервера.
        /// </summary>
        [DisplayName("Хост")]
        [Description("Имя или IP-адрес сервера")]
        public virtual string Host
        { get; set; }
    }
}