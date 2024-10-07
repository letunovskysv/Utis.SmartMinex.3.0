using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Состояние антенны
    /// </summary>
    [DisplayName("Состояние антенны")]
    [Ackable]
    public interface IAntennaStateEventPriority : IPriorityEventBase
    {
        /// <summary>
        /// Считыватель
        /// </summary>
        [DisplayName("Id сч.")]
        [Description("Считыватель")]
        IReader Reader { get; set; }

        /// <summary>
        /// Номер антенны
        /// </summary>
        [DisplayName("ант.№")]
        [Description("Номер антенны")]
        int Antenna { get; set; }

        /// <summary>
        /// Состояние антенны Antenna
        /// </summary>
        [DisplayName("Статус ант.")]
        [Description("Состояние антенны")]
        AntennaState AntennaState { get; set; }
    }
}
