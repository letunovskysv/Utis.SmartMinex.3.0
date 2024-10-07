
namespace Utis.Minex.ProductionModel.PriorityEvent.TelemetryEvent
{
    #region Using

    using Utis.Minex.Common;
    using Utis.Minex.ProductionModel.Devices;

    #endregion

    /// <summary>
    /// Базовый класс события телеметрии с приоритетом.
    /// </summary>
    [DisplayName("Базовый класс события телеметрии с приоритетом")]
    public abstract class TelemetryEventPriorityBase : PriorityEventBase
    {
        /// <summary>
        /// Метка устройства, которое регистрирует параметр телеметрии.
        /// </summary>
        [DisplayName("Устройство с меткой RFID")]
        public virtual DeviceWithRfid DeviceWithRfid
        { get; set; }
    }
}