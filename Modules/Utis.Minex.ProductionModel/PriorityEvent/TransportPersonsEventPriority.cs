using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.PriorityEvent
{
    /// <summary>
    /// Список людей, отмеченных на УРПТ-ИС-Т
    /// </summary>
    [DisplayName("Список людей, отмеченных на УРПТ-ИС-Т")]
    public class TransportPersonsEventPriority : PriorityEventBase
    {
        /// <summary>
        /// Идентификатор источника передачи данных
        /// </summary>
        [DisplayName("Идентификатор источника передачи данных")]
        public virtual long SourceId { get; set; }

        /// <summary>
        /// Тип источника данных
        /// </summary>
        [DisplayName("Тип источника данных")]
        public virtual RfidDeviceType SourceType { get; set; }

        /// <summary>
        /// Метка устройства транспорта
        /// </summary>
        [DisplayName("Метка устройства транспорта")]
        public virtual int TransportLabel { get; set; }

        /// <summary>
        /// Метка устройства транспорта
        /// </summary>
        [DisplayName("Метка устройства транспорта")]
        public virtual RfidDeviceType TransportType { get; set; }

        /// <summary>
        /// Пассажиры
        /// </summary>
        [DisplayName("Пассажиры")]
        public virtual IEnumerable<int> Passangers { get; set; }

        /// <summary>
        /// Водители
        /// </summary>
        [DisplayName("Водители")]
        public virtual IEnumerable<int> Drivers { get; set; }

        /// <summary>
        /// Флаг что событие было сгенерированно СП в TransportPersonAutoDropOff
        /// </summary>
        [DisplayName("Сгенерировано сервером приложений")]
        public virtual bool IsSintetic { get; set; }
    }
}
