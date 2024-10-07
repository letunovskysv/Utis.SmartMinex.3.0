using System.Collections.Generic;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Конфигурация линии
    /// </summary>
    [DisplayName("Конфигурация линии")]
    public interface ILineConfig :IObjectNamed
    {
        /// <summary>
        /// Тип линии считывателей
        /// </summary>
        [DisplayName("Тип линии считывателей")]
        LineType LineType
        { get; set; }

        /// <summary>
        /// Опрос линии
        /// </summary>
        [DisplayName("Опрос линии включен")]
        bool IsEnable
        { get; set; }

        /// <summary>
        /// Порт 1
        /// </summary>
        [DisplayName("Порт 1")]
        IMediaConverterPort Port1
        { get; set; }


        /// <summary>
        /// Порт 2
        /// </summary>
        [DisplayName("Порт 2")]
        IMediaConverterPort Port2
        { get; set; }

        /// <summary>
        /// Сервер ввода-вывода
        /// </summary>
        [DisplayName("Сервер ввода-вывода")]
        IDAServer DAServer
        { get; set; }

        /// <summary>
        /// Номер линии
        /// </summary>
        [DisplayName("Номер линии")]
        int Number
        { get; set; }

        /// <summary>
        /// Период опроса
        /// </summary>
        [DisplayName("Период опроса")]
        int QueryTime
        { get; set; }

        /// <summary>
        /// Периодичность опроса антенн, сек
        /// </summary>
        [DisplayName("Периодичность опроса антенн, сек.")]
        int CheckAntennaTime
        { get; set; }

        /// <summary>
        /// Попыток опроса
        /// </summary>
        [DisplayName("Попыток опроса")]
        int ReadRepeatCount
        { get; set; }

        /// <summary>
        /// Циклы до отказа
        /// </summary>
        [DisplayName("Циклы до отказа")]
        int ReadCycleCount
        { get; set; }
    }
}
