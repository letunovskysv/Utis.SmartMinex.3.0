
namespace Utis.Minex.ProductionModel.Positioning
{
    using System.Collections.Generic;
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Common;
    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Interfaces;

        #endregion

    /// <summary>
    /// Конфигурация линии считывателей.
    /// </summary>
    [DisplayName("Конфигурация линии считывателей")]
    public class LineConfig : CatalogBase, IDeviceSurvey, ILineConfig
    {
        /// <summary>
        /// Уникальный вводимый пользователем номер линии.
        /// </summary>
        [DisplayName("Номер линии")]
        public virtual int Number 
        { get; set; }

        /// <summary>
        /// Опрос линии включен.
        /// </summary>
        [DisplayName("Опрос линии включен")]
        public virtual bool IsEnable 
        { get; set; } = true;

        /// <summary>
        /// ССД, к которому относится линия.
        /// </summary>
        [DisplayName("ССД")]
        [Description("ССД, к которому относится линия")]
        public virtual DAServer DAServer 
        { get; set; }

        /// <summary>
        /// Тип линии.
        /// </summary>
        [DisplayName("Тип")]
        [Description("Тип линии")]
        public virtual LineType LineType 
        { get; set; }

        /// <summary>
        /// Период опроса линии.
        /// </summary>
        [DisplayName("Период опроса")]
        [Description("Период опроса линии, мс.")]
        public virtual int QueryTime 
        { get; set; } = 1000;

        /// <summary>
        /// Периодичность опроса состояния антенн и крышки.
        /// </summary>
        [DisplayName("Периодичность опроса антенн, сек.")]
        [Description("Периодичность опроса состояния антенн и крышки, сек.")]
        public virtual int CheckAntennaTime 
        { get; set; }

        /// <summary>
        /// Количество попыток опроса считывателя в цикле.
        /// </summary>
        [DisplayName("Попыток опроса")]
        [Description("Количество попыток опроса считывателя в цикле")]
        public virtual int ReadRepeatCount 
        { get; set; }
        
        /// <summary>
        /// Количество циклов опроса перед фиксацией отказа.
        /// </summary>
        [DisplayName("Циклы до отказа")]
        [Description("Количество циклов опроса перед фиксацией отказа")]
        public virtual int ReadCycleCount 
        { get; set; }
        
        /// <summary>
        /// Конфигурация порта 1.
        /// </summary>
        [DisplayName("Порт 1")]
        [Description("Порт 1 медиаконвертера")]
        public virtual MediaConverterPort Port1 
        { get; set; }

        /// <summary>
        /// Конфигурация порта 2 кольцевой линии.
        /// </summary>
        [DisplayName("Порт 2")]
        [Description("Порт 2 медиаконвертера")]
        public virtual MediaConverterPort Port2 
        { get; set; }

        IMediaConverterPort ILineConfig.Port1 
        { get => Port1; set => Port1 = value as MediaConverterPort; }
        IMediaConverterPort ILineConfig.Port2
        { get => Port2; set => Port2 = value as MediaConverterPort; }
        IDAServer ILineConfig.DAServer 
        { get => DAServer; set => DAServer = value as DAServer; }
    }
}