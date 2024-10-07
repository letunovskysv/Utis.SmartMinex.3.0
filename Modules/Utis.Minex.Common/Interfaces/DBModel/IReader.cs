using System.ComponentModel;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{

    /// <summary>
    /// Считыватель.
    /// </summary>
    [DisplayName("Считыватель")]
    public interface IReader : IZoneDefineDevice
    {
        /// <summary>
        /// Modbus адрес.
        /// </summary>
        [DisplayName("Modbus адрес")]
        int ModbusAddress
        { get; set; }

        /// <summary>
        /// Опрос считывателя.
        /// </summary>
        [DisplayName("Опрос считывателя")]
        bool IsEnable
        { get; set; }

        /// <summary>
        /// Питание.
        /// </summary>
        [DisplayName("Питание")]
        int PowerIn
        { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        [DisplayName("Тип")]
        ReaderType ReaderType
        { get; set; }

        /// <summary>
        /// Прошивка.
        /// </summary>
        [DisplayName("Прошивка")]
        [ReadOnly(true)]
        string Version
        { get; set; }

        /// <summary>
        /// Контроль антенн.
        /// </summary>
        [DisplayName("Контроль антенн")]
        ControlAntenna ControlAntenna
        { get; set; }

        /// <summary>
        /// Контроль дискретных входов.
        /// </summary>
        [DisplayName("Контроль дискр. вх.")]
        ControlDiscreteIn ControlDiscreteIn
        { get; set; }

        /// <summary>
        /// Контроль состояния крышки.
        /// </summary>
        [DisplayName("Контроль состояния крышки")]
        bool IsCoverControl
        { get; set; }

        /// <summary>
        /// Флаг светофора.
        /// </summary>
        [DisplayName("Светофор")]
        bool IsTrafficLight
        { get; set; }

        /// <summary>
        /// Линия.
        /// </summary>
        [DisplayName("Линия")]
        [MetaProperty(true)]
        ILineConfig LineConfig
        { get; set; }

    }
}
