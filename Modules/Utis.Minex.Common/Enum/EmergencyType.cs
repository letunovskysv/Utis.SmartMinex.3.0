
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип аварийного события.
    /// </summary>
    [DisplayName("Тип аварийного события")]
    public enum EmergencyType
    {
        /// <summary>
        /// Событие отправки сигнала SOS и групповой аварии от диспетчера
        /// </summary>
        [DisplayName("Вызов отправлен")]
        [Description("Вызов отправлен")]
        Raise = 0,

        /// <summary>
        /// Подтверждение получения меткой аварийного сигнала.
        /// </summary>
        [DisplayName("Авто-подтверждение")]
        [Description("Подтверждение получения меткой аварийного сигнала")]
        AutoConfirm = 1,

        /// <summary>
        /// Подтверждение получения человеком аварийного сигнала.
        /// </summary>
        [DisplayName("Ручное подтверждение")]
        [Description("Подтверждение получения человеком аварийного сигнала")]
        ButtonConfirm = 2,

        /// <summary>
        /// По умолчанию.
        /// </summary>
        [DisplayName("По умолчанию")]
        [Description("По умолчанию")]
        Default = 4,

        /// <summary>
        /// Сброс по сдаче светильника
        /// </summary>
        [DisplayName("Сброс по сдаче светильника")]
        [Description("Сброс по сдаче светильника")]
        RfuReturn = 5,

        /// <summary>
        /// Сброс по выходу
        /// </summary>
        [DisplayName("Сброс по выходу")]
        [Description("Сброс по выходу")]
        OutputReader = 6,

        /// <summary>
        /// Вызов отправлен
        /// </summary>
        [DisplayName("Вызов отправлен через ССД")]
        [Description("Вызов отправлен через ССД")]
        CallSent = 7,

        /// <summary>
        /// Отмена вызова
        /// </summary>
        [DisplayName("Отмена вызова")]
        [Description("Отмена вызова")]
        RaiseReset = 8,

        /// <summary>
        /// Вызов отправлен
        /// </summary>
        [DisplayName("Вызов отправлен через СУБР")]
        [Description("Вызов отправлен через СУБР")]
        CallSentSubr = 9,

        /// <summary>
        /// Аварийный вызов квитирован
        /// </summary>
        [DisplayName("Аварийный вызов квитирован")]
        [Description("Аварийный вызов квитирован")]
        AckEvent = 10,

        /// <summary>
        /// Вызов подтвержден от канала Считыватель
        /// </summary>
        [DisplayName("Вызов подтвержден от канала Считыватель")]
        [Description("Вызов подтвержден от канала Считыватель")]
        CallConfirmedReader = 11,

        /// <summary>
        /// Вызов подтвержден от канала СУБР
        /// </summary>
        [DisplayName("Вызов подтвержден от канала СУБР")]
        [Description("Вызов подтвержден от канала СУБР")]
        CallConfirmedSubr = 12,

        /// <summary>
        /// Отмена по старту аварии
        /// </summary>
        [DisplayName("Отмена по старту аварии")]
        [Description("Отмена по старту аварии")]
        RaiseResetOnAlarm = 13,

        /// <summary>
        /// Сброс по времени
        /// </summary>
        [DisplayName("Сброс по времени")]
        [Description("Сброс по времени")]
        RaiseResetOnTimeOut = 14,
    }
}