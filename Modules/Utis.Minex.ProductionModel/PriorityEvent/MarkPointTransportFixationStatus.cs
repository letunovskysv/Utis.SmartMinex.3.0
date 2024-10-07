
namespace Utis.Minex.ProductionModel.PriorityEvent
{
    using System;


    #region Using
        
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;

    #endregion
    [Ackable]
    public class MarkPointTransportFixationStatus : PriorityEventBase
    {
        /// <summary>
        /// ATO.
        /// </summary>
        [DisplayName("ATO")]
        public virtual MarkPoint MarkPoint 
        { get; set; }

        /// <summary>
        /// Порог на основании которого выдан статус.
        /// </summary>
        [DisplayName("Порог на основании которого выдан статус")]
        public virtual int ThresholdAlarm 
        { get; set; }

        /// <summary>
        /// Мобильное устройство регистрации.
        /// </summary>
        [DisplayName("Мобильное устройство регистрации")]
        public virtual MobileRegDevice MobileRegDevice
        { get; set; }

        /// <summary>
        /// Время последнего события регистрации
        /// </summary>
        [DisplayName("Время последнего события регистрации")]
        [Description("Время последнего события регистрации")]
        public virtual DateTime LastDatetime
        { get; set; }
    }
}