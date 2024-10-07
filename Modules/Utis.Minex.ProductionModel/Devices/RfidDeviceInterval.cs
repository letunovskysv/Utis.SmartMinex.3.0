using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Devices
{
    /// <summary>
    /// Соответствие меток типу (классу) устройства.
    /// </summary>
    public class RfidDeviceInterval:CatalogBase
    {
        /// <summary>
        /// Тип устройства в интервале меток.
        /// </summary>
        [UniqueKey]
        public virtual RfidDeviceType RfidDeviceType 
        { get; set; }

        /// <summary>
        /// Начало интервала меток.
        /// </summary>
        public virtual int RfidFrom 
        { get; set; }

        /// <summary>
        /// Окончание интервала меток.
        /// </summary>
        public virtual int RfidTo 
        { get; set; }
    }
}