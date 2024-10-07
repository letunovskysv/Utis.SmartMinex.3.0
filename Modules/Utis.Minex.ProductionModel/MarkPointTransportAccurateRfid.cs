using System;

namespace Utis.Minex.ProductionModel
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    /// <summary>
    /// Событие регистрации ATO.
    /// </summary>
    [DisplayName("Событие регистрации ATO")]
    [Description("Событие регистрации ATO с приоритетами")]
    public class MarkPointTransportAccurateRfid : NamedObjectBase
    {
        /// <summary>
        /// Мобильное устройство регистрации.
        /// </summary>
        [DisplayName("Устройство регистрации")]
        public virtual MobileRegDevice MobileRegDevice
        { get; set; }

        /// <summary>
        /// ATO.
        /// </summary>
        [DisplayName("ATO")]
        public virtual MarkPoint MarkPoint
        { get; set; }

        /// <summary>
        /// Номер антены.
        /// </summary>
        [DisplayName("Номер антены")]
        public virtual int AntNumber 
        { get; set; }
        
        /// <summary>
        /// Регистрируемое расстояние.
        /// </summary>
        [DisplayName("Регистрируемое расстояние")]
        public virtual float Distance 
        { get; set; }

        /// <summary>
        /// Уровень сигнала.
        /// </summary>
        [DisplayName("Уровень сигнала")]
        public virtual int Rssi
        { get; set; }

        /// <summary>
        /// Дата, время поступления события из источника, фиксации в БД.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника, фиксации в БД")]
        public virtual DateTime Datetime
        { get; set; }

        /// <summary>
        /// Тип события позиции транспорта.
        /// </summary>
        [DisplayName("Позиция транспорта")]
        public virtual TransportPositionEventType TransportPositionEventType
        { get; set; }

        /// <summary>
        /// Транспорт
        /// </summary>
        [DisplayName("Транспорт")]
        public virtual string TransportName
        { get; set; }
    }
}