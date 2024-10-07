namespace Utis.Minex.Common.Interfaces
{
    public interface IUTProtoSettings
    {
        /// <summary>
        /// Порт UTProto.
        /// </summary>
        [DisplayName("Порт UTProto")]
        int UTProtoPort
        { get; set; }

        /// <summary>
        /// Флаг включения проверки повторной регистрации UTProto.
        /// </summary>
        [DisplayName("Проверка повторной регистрации UTProto")]
        bool CheckDoubleUTProtoRegisterConnection
        { get; set; }

        /// <summary>
        /// Преобразовывать время из UTC и обратно для событий от ССД (int64).
        /// </summary>
        [DisplayName("Преобразовывать время из UTC и обратно для событий от ССД (int64)")]
        bool UTProtoConvertFromUTCAndBack
        { get; set; }

        /// <summary>
        /// Флаг вывода сообщений UTProto.
        /// </summary>
        [DisplayName("Вывод сообщений UTProto")]
        bool OutputUTProto
        { get; set; }

        /// <summary>
        /// Перечень типов сырых данных UTProto для вывода.
        /// </summary>
        [DisplayName("Перечень типов сырых данных UTProto для вывода")]
        string UTProtoTypesToOutput
        { get; set; }

        bool UTProtoShowTechnicalFields
        { get; set; }

    }
}
