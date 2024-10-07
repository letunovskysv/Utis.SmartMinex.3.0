
using Utis.Minex.ProductionModel.MineSpace;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    [DisplayName("Контроль местонахождения АТО")]
    [Ackable]
    public class MarkPointInMoveEventPriority : PriorityEventBase
    {
        /// <summary>
        /// ATO.
        /// </summary>
        [DisplayName("ATO")]
        public virtual MarkPoint MarkPoint 
        { get; set; }

        /// <summary>
        /// Положение
        /// </summary>
        [DisplayName("Положение")]
        public virtual PositionMarkPoint Position 
        { get; set; }

        /// <summary>
        /// Считыватель
        /// </summary>
        [DisplayName("Считыватель")]
        public virtual Reader Reader
        { get; set; }

        /// <summary>
        /// Антенна
        /// </summary>
        [DisplayName("Антенна")]
        public virtual int Antenna 
        { get; set; }

        /// <summary>
        /// Дистанция
        /// </summary>
        [DisplayName("Дистанция")]
        public virtual float Distance
        { get; set; }

        /// <summary>
        /// Зона
        /// </summary>
        [DisplayName("Зона")]
        public virtual Zone Zone 
        { get; set; }
    }
}