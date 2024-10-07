using Utis.Minex.ProductionModel.Common;

namespace Utis.Minex.ProductionModel.Interfaces
{
    /// <summary>
    /// IP-устройство
    /// </summary>
    public interface IIPDevice
    {
        /// <summary>
        /// IP-адрес
        /// </summary>
        string Ip { get; }

        /// <summary>
        /// Сервер сбора
        /// </summary>
        DAServer DAServer { get; }
    }
}