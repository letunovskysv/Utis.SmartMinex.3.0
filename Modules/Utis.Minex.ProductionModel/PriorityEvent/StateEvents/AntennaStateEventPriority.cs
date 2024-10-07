using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent.StateEvents
{
    /// <summary>
    /// Состояние антенны
    /// </summary>
    [DisplayName("Состояние антенны")]
    [Ackable]
    public class AntennaStateEventPriority : PriorityEventBase, IAntennaStateEventPriority
    {
        /// <summary>
        /// Считыватель
        /// </summary>
        [DisplayName("Id сч.")]
        [Description("Считыватель")]
        public virtual Reader Reader { get; set; }

        /// <summary>
        /// Номер антенны
        /// </summary>
        [DisplayName("ант.№")]
        [Description("Номер антенны")]
        public virtual int Antenna { get; set; }

        /// <summary>
        /// Состояние антенны Antenna
        /// </summary>
        [DisplayName("Статус ант.")]
        [Description("Состояние антенны")]
        public virtual AntennaState AntennaState { get; set; }
        IReader IAntennaStateEventPriority.Reader { get => Reader; set => Reader = value as Reader; }
    }
}