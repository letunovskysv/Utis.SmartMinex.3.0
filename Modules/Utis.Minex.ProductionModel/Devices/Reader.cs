namespace Utis.Minex.ProductionModel.Devices
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Interfaces;
    using Utis.Minex.ProductionModel.Positioning;

        #endregion

    /// <summary>Считыватель/анкер</summary>
    [DisplayName("Считыватель/анкер")]
    public class Reader : ZoneDefineDevice, IPoweredDevice, IDeviceSurvey, IReader
    {
        /// <summary>
        /// Адрес в сети Modbus.
        /// </summary>
        [DisplayName("Адрес")]
        [Description("Modbus-адрес в сети RS485")]
        public virtual int ModbusAddress
        { get; set; }

        /// <summary>
        /// Опрос считывателя включен.
        /// </summary>
        [DisplayName("Опрос считывателя включен")]
        [Description("Опрос считывателя включен")]
        public virtual bool IsEnable
        { get; set; } = true;

        /// <summary>
        /// Входное питание.
        /// </summary>
        [DisplayName("Питание")]
        [Description("Напряжение питания, В")]
        public virtual int PowerIn
        { get; set; }

        /// <summary>
        /// Конфигурация линии, к которой подключается считыватель.
        /// </summary>
        [DisplayName("Линия")]
        [Description("Линия, к которой подключен считыватель")]
        public virtual LineConfig LineConfig
        { get; set; }

        /// <summary>
        /// Тип УРПТ.
        /// </summary>
        [DisplayName("Тип")]
        [Description("Тип УРПТ")]
        public virtual ReaderType ReaderType
        { get; set; }

        /// <summary>
        /// Версия прошивки.
        /// </summary>
        [DisplayName("Прошивка")]
        [Description("Версия прошивки")]
        public virtual string Version
        { get; set; }

        /// <summary>
        /// Настройка контроля антенн считывателя.
        /// </summary>
        [DisplayName("Контроль антенн")]
        [Description("Настройка контроля антенн считывателя")]
        public virtual ControlAntenna ControlAntenna
        { get; set; }

        /// <summary>
        /// Контроль дискретных входов считывателя.
        /// </summary>
        [DisplayName("Контроль дискр.вх.")]
        [Description("Контроль дискретных входов считывателя")]
        public virtual ControlDiscreteIn ControlDiscreteIn
        { get; set; }

        /// <summary>
        /// Признак контроля состояния крышки.
        /// </summary>
        [DisplayName("Контроль состояния крышки")]
        [Description("Контроль состояния крышки")]
        public virtual bool IsCoverControl
        { get; set; } = true;

        /// <summary>
        /// Признак контроля источника питания.
        /// </summary>
        [DisplayName("Контроль источника питания")]
        [Description("Контроль источника питания")]
        public virtual bool IsPowerSupplyControl
        { get; set; } = true;

        /// <summary>
        /// Признак контроля уровня заряда.
        /// </summary>
        [DisplayName("Контроль уровня заряда")]
        [Description("Контроль уровня заряда")]
        public virtual bool IsChargeLevelControl
        { get; set; } = true;

        /// <summary>
        /// Флаг светофора.
        /// </summary>
        [DisplayName("Светофор")]
        public virtual bool IsTrafficLight
        { get; set; }

        /// <summary>
        /// Тип получаемых данных
        /// </summary>
        [DisplayName("Тип получаемых данных")]
        [Description("Тип получаемых данных")]
        public ReaderPositioningType PositioningType { get; set; }


        ILineConfig IReader.LineConfig
        { get => LineConfig; set => LineConfig = value as LineConfig; }
    } 
}