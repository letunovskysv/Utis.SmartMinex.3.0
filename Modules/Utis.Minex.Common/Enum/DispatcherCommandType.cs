namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип команды диспетчера
    /// </summary>
    public enum DispatcherCommandType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        [Description("Значение по умолчанию")]
        Default = 0,

        /// <summary>
        /// Групповой вызов
        /// </summary>
        [DisplayName("Групповой вызов")]
        [Description("Групповой вызов")]
        CommonGroupCall = 1,

        /// <summary>
        /// Сброс группового вызова
        /// </summary>
        [DisplayName("Сброс группового вызова")]
        [Description("Сброс группового вызова")]
        CommonGroupCallReset = 2,

        /// <summary>
        /// Индивидуальный вызов
        /// </summary>
        [DisplayName("Индивидуальный вызов")]
        [Description("Индивидуальный вызов")]
        IndividualCall = 3,

        /// <summary>
        /// Отмена индивидуального вызова
        /// </summary>
        [DisplayName("Отмена индивидуального вызова")]
        [Description("Отмена индивидуального вызова")]
        IndividualCallReset = 4,

        /// <summary>
        /// Сброс сигнала SOS из шахты
        /// </summary>
        [DisplayName("Сброс сигнала SOS из шахты")]
        [Description("Сброс сигнала SOS из шахты")]
        RaiseReset = 5,
    }
}
