
namespace Utis.Minex.ProductionModel.Notes
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.Catalog.Organize;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    /// <summary>
    /// Журнал параметров АТО.
    /// </summary>
    [DisplayName("Журнал параметров АТО")]
    public class MarkPointParameters : NoteBase
    { 
        /// <summary>
        /// Сотрудник, пользователь мобильного устройства.
        /// </summary>
        [DisplayName("Сотрудник")]
        public virtual Person Person
        { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        [DisplayName("Подразделение")]
        public virtual Division Division
        { get; set; }

        /// <summary>
        /// Расстояние до 1 сопряжения.
        /// </summary>
        [DisplayName("Расстояние до 1 сопряжения")]
        public virtual float DistanceToCross1
        { get; set; }

        /// <summary>
        /// Расстояние до 2 сопряжения.
        /// </summary>
        [DisplayName("Расстояние до 2 сопряжения")]
        public virtual float DistanceToCross2
        { get; set; }

        /// <summary>
        /// ATO
        /// </summary>
        [DisplayName("ATO")]
        public virtual MarkPoint MarkPoint
        { get; set; }

        /// <summary>
        /// ATO.
        /// </summary>
        [DisplayName("ATO")]
        public virtual MarkPoint MarkPointCurrent
        { get; set; }

        /// <summary>
        /// Версия прошивки АТО.
        /// </summary>
        [DisplayName("Версия прошивки АТО")]
        public virtual string FirmwareVersion
        { get; set; }

        /// <summary>
        /// Статус АТО.
        /// </summary>
        [DisplayName("Статус АТО")]
        public virtual MarkPointState MarkPointState
        { get; set; }

        /// <summary>
        /// Состояние АТО.
        /// </summary>
        [DisplayName("Состояние АТО")]
        public virtual MarkPointCondition MarkPointCondition
        { get; set; }

        /// <summary>
        /// Статус АТО.
        /// </summary>
        [DisplayName("Статус АТО")]
        public virtual MarkPointState MarkPointStateCurrent
        { get; set; }

        /// <summary>
        /// Состояние АТО.
        /// </summary>
        [DisplayName("Состояние АТО")]
        public virtual MarkPointCondition MarkPointConditionCurrent
        { get; set; }

        /// <summary>
        /// Действие с АТО.
        /// </summary>
        [DisplayName("Действие с АТО")]
        public virtual MarkPointOperationType MarkPointOperationType
        { get; set; }

        /// <summary>
        /// Остаточный ресурс батареи АТО в мин.
        /// </summary>
        [DisplayName("Остаточный ресурс батареи АТО в мин.")]
        public virtual long RemainingBatteryInMinutes
        { get; set; }

        /// <summary>
        /// Фактические параметры АТО получены.
        /// </summary>
        [DisplayName("Фактические параметры АТО получены")]
        public virtual bool IsParametersReceived
        { get; set; }

        /// <summary>
        /// Ресурс батареи в норме.
        /// </summary>
        [DisplayName("Ресурс батареи в норме")]
        public virtual bool IsBatteryOk
        { get; set; }

        /// <summary>
        /// Измерение расстояния до АТО в норме.
        /// </summary>
        [DisplayName("Измерение расстояния в норме")]
        public virtual bool IsDistanceMeasurementOk
        { get; set; }

        /// <summary>
        /// Регламент монтажа АТО в норме.
        /// </summary>
        [DisplayName("Регламент монтажа в норме")]
        public virtual bool IsMountingRegulationOk
        { get; set; }

        /// <summary>
        /// Выработка на сопряжении 1
        /// </summary>
        [DisplayName("Выработка на сопряжении 1")]
        public virtual Working WorkingOnCross1
        { get; set; }

        /// <summary>
        /// Выработка на сопряжении 2
        /// </summary>
        [DisplayName("Выработка на сопряжении 2")]
        public virtual Working WorkingOnCross2
        { get; set; }

        /// <summary>
        /// Описание/комментарий
        /// </summary>
        [DisplayName("Описание/комментарий")]
        public virtual string Description
        { get; set; }
    }
}