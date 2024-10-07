using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Catalog;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.MineSpace;
using Utis.Minex.ProductionModel.MineSpace.MineModel;

namespace Utis.Minex.ProductionModel.Register.Dimension.Movement
{
    public class TransportMovement : MovementJournal
    {
        /// <summary>
        /// Транспорт
        /// </summary>
        [DisplayName("Транспорт")]
        public virtual Transport Transport
        { get; set; }

        /// <summary>
        /// Антенна.
        /// </summary>
        [DisplayName("Номер антенны устройства считывания")]
        public virtual int Antenna
        { get; set; }

        /// <summary>
        /// Устройство считывания.
        /// </summary>
        [DisplayName("Устройство считывания")]
        [Description("Устройство считывания, на котором произошла регистрация")]
        public virtual DeviceWithRfid RfidDevice
        { get; set; }

        /// <summary>
        /// Выработка.
        /// </summary>
        [DisplayName("Выработка")]
        public virtual Working Working
        { get; set; }

        /// <summary>
        /// Зона.
        /// </summary>
        [DisplayName("Зона")]
        [Description("Зона, в которой произошло событие регистрации")]
        public virtual Zone Zone
        { get; set; }

        /// <summary>
        /// Тип операции перемещения
        /// </summary>
        [DisplayName("Тип операции перемещения")]
        public virtual TransportOperationType OperationType 
        { get; set; } = TransportOperationType.InShaft;
    }
}