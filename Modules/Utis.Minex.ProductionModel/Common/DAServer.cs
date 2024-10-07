using System.Collections.Generic;

namespace Utis.Minex.ProductionModel.Common
{
    using System;
    using System.Linq;
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

    using Utis.Minex.ProductionModel.Positioning;

        #endregion

    /// <summary>
    /// Регистрация подключения сервера сбора данных
    /// </summary>
    [DisplayName("ССД")]
    [Description("Регистрация сервера сбора данных")]
    public class DAServer : DataProviderServer, IDAServer
    {
        /// <summary>
        /// Перечень конфигураций линий считывателей
        /// </summary>
        [DisplayName("Линии")]
        [Description("Перечень конфигураций линий считывателей")]
        public virtual ISet<LineConfig> LineConfigs
        { get; set; } = new HashSet<LineConfig>();

        /// <summary>
        /// Количество дней удаления старых данных позиционирования (не меньше месячной давности)
        /// </summary>
        [DisplayName("Кол-во дней хранения данных")]
        [Description("Количество дней удаления старых данных позиционирования (не меньше месячной давности)")]
        public virtual int StorageDays
        { get; set; } = 30;

        /// <summary>
        /// Кол-во минут до автоматической подачи аварии от газоанализаторов
        /// </summary>
        [DisplayName("Минут до подачи аварии от ГА")]
        [Description("Кол-во минут до автоматической подачи аварии от газоанализаторов")]
        public virtual int GAAlarmMinutes
        { get; set; } = 5;

        /// <summary>
        /// включает взаимодействие сервера и сервера голосовой связи  по сокету то есть когда от сервера голосовой связи приходит команда о необходимости передачи данных голоса в шахте все потоки пороса считывателей останавливаются
        /// </summary>
        [DisplayName("Взаимодействие сервера и сервера голосовой связи")]
        [Description("Включает взаимодействие сервера и сервера голосовой связи  по сокету")]
        public virtual bool SGSEnabled
        { get; set; } = true;

        /// <summary>
        /// детализация лога необходима для отладки и выявления ошибок
        /// </summary>
        [DisplayName("Детализация лога")]
        [Description("Детализация лога необходима для отладки и выявления ошибок")]
        public virtual LogDetails LogDetails
        { get; set; } = LogDetails.Normal;

        /// <summary>
        /// Кол-во дней хранения логов
        /// </summary>
        [DisplayName("Кол-во дней хранения логов")]
        public virtual int LogDays
        { get; set; } = 30;

        /// <summary>
        /// кодировка записи логов в текстовый файл
        /// </summary>
        [DisplayName("Кодировка записи логов")]
        [Description("Кодировка записи логов в текстовый файл")]
        public virtual CodecType LogCodec
        { get; set; }

        /// <summary>
        /// Побитово - включение оповещения с использованием комплекса СУБР
        /// </summary>
        [DisplayName("Оповещения СУБР")]
        [Description("Побитово - включение оповещения с использованием комплекса СУБР")]
        public virtual long AlarmsNotification
        { get; set; }

        /// <summary>
        /// Интервал усреднения перемещения 1-5 секунд по умолчанию 5
        /// </summary>
        [DisplayName("Интервал усреднения перемещения")]
        public virtual int MoveAverageTime
        { get; set; } = 5;

        /// <summary>
        /// Интервал усреднения RSSI 1-5 секунд по умолчанию 5
        /// </summary>
        [DisplayName("Интервал усреднения RSSI")]
        public virtual int RSSIAverageTime
        { get; set; } = 5;

    }
}