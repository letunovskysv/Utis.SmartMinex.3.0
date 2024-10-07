using System;
using System.Diagnostics;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.CommandAndCalls
{
    /// <summary>
    /// Команда диспечтера
    /// </summary>
    public class DispatcherCommand : CommandCallBase
    {
        /// <summary>
        /// Тип команды
        /// </summary>
        public DispatcherCommandType CommandType { get; set; }

        /// <summary>
        /// Номер аварии
        /// </summary>
        [DisplayName("Номер аварии")]
        public int AlarmNumber { get; set; }

        /// <summary>
        /// Вызываемая метка
        /// </summary>
        [DisplayName("Номер метки")]
        public virtual int Label { get; set; }

        /// <summary>
        /// Тип вызываемой метки
        /// </summary>
        [DisplayName("Тип метки")]
        public virtual IndividualDeviceType DeviceType { get; set; }

        /// <summary>
        /// Система передачи команды
        /// </summary>
        [DisplayName("Система передачи команды")]
        public virtual IndividualCallSystem CallSystem { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        public virtual string Description { get; set; }

        public override string ToString()
        {
            return CommandType switch
            {
                DispatcherCommandType.CommonGroupCall or DispatcherCommandType.CommonGroupCallReset => $"{CommandType} - Инициатор:{CallerName} Номер аварии:{AlarmNumber}",
                DispatcherCommandType.IndividualCall or DispatcherCommandType.IndividualCallReset => $"{CommandType} - Инициатор:{CallerName} Метка: {DeviceType} {Label} Система передачи команды: {CallSystem}",
                DispatcherCommandType.RaiseReset => $"{CommandType} - Инициатор:{CallerName} Метка: {DeviceType} {Label}",
                _ => base.ToString()
            };
        }
    }
}
