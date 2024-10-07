using System;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.MineSpace;
using Utis.Minex.ProductionModel.MineSpace.MineModel;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал фиксации разрывов позиционирования между выработками 
    /// </summary>
    [DisplayName("Журнал фиксации разрывов позиционирования")]
    [Description("Журнал фиксации разрывов позиционирования между выработками")]
    public class WorkingBreakeJournal : VersionObjectBase
    {
        /// <summary>
        /// Номер метки
        /// </summary>
        [DisplayName("Номер метки")]
        public virtual int Label
        { get; set; }

        /// <summary>
        /// Тип метки
        /// </summary>
        [DisplayName("Тип метки")]
        public virtual MobileDeviceType DeviceType
        { get; set; }

        /// <summary>
        /// Горизонт с которого происходит перемещение метки
        /// </summary>
        [DisplayName("Начальный горизонт")]
        [Description("Горизонт с которого происходит перемещение метки")]
        public virtual Horizon HorizonOut { get; set; }

        /// <summary>
        /// Выработка с которой происходит перемещение метки
        /// </summary>
        [DisplayName("Начальная выработка")]
        [Description("Выработка с которой происходит перемещение метки")]
        public virtual Working WorkingOut { get; set; }

        /// <summary>
        /// Длина выработки с которой происходит перемещение метки
        /// </summary>
        [DisplayName("Длина начальной выработки")]
        [Description("Длина выработки с которой происходит перемещение метки")]
        public virtual int WorkingOutLenght { get; set; }

        /// <summary>
        /// Начальная выработка - тупик
        /// </summary>
        [DisplayName("Начальная выработка - тупик")]
        [Description("Начальная выработка является тупиком")]
        public virtual bool WorkingOutDeadEnd { get; set; }

        /// <summary>
        /// Выработка с которой происходит перемещение метки
        /// </summary>
        [DisplayName("Начальная зона")]
        [Description("Зона с которой происходит перемещение метки")]
        public virtual Zone ZoneOut { get; set; }

        /// <summary>
        /// Время последней фиксации на ихсодной выработке
        /// </summary>
        [DisplayName("Время последней фиксации")]
        [Description("Время последней фиксации на начальной выработке")]
        public virtual DateTime LastFixationOnWorkingOut { get; set; }

        /// <summary>
        /// Горизонт на который происходит перемещение метки
        /// </summary>
        [DisplayName("Конечный горизонт")]
        [Description("Горизонт на который происходит перемещение метки")]
        public virtual Horizon HorizonIn { get; set; }

        /// <summary>
        /// Выработка на которую происходит перемещение метки
        /// </summary>
        [DisplayName("Конечная выработка")]
        [Description("Выработка на которую происходит перемещение метки")]
        public virtual Working WorkingIn { get; set; }

        /// <summary>
        /// Длина выработки на которую происходит перемещение метки
        /// </summary>
        [DisplayName("Длина конечной выработки")]
        [Description("Длина выработки на которую происходит перемещение метки")]
        public virtual int WorkingInLenght { get; set; }

        /// <summary>
        /// Конечная выработка - тупик
        /// </summary>
        [DisplayName("Конечная выработка - тупик")]
        [Description("Конечная выработка является тупиком")]
        public virtual bool WorkingInDeadEnd { get; set; }

        /// <summary>
        /// Выработка на которую происходит перемещение метки
        /// </summary>
        [DisplayName("Конечная зона")]
        [Description("Зона на которую происходит перемещение метки")]
        public virtual Zone ZoneIn { get; set; }

        /// <summary>
        /// Время входа в конечную выработку
        /// </summary>
        [DisplayName("Время входа")]
        [Description("Время входа в конечную выработку")]
        public virtual DateTime InTime { get; set; }
    }
}
