namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус активности опасной зоны
    /// </summary>
    [DisplayName("Статус активности опасной зоны")]
    public enum ZoneDangerousEventType
    {
        /// <summary>
        /// Зона неактивна
        /// </summary>
        [DisplayName("Зона неактивна")]
        Stopped,
        /// <summary>
        /// Событие перед активацией зоны (30 мин)
        /// </summary>
        [DisplayName("До активации зоны менее 30 мин")]
        PreStart30minActivity,
        /// <summary>
        /// Событие перед активацией зоны (10 мин)
        /// </summary>
        [DisplayName("До активации зоны менее 10 мин")]
        PreStart10minActivity,
        /// <summary>
        /// Активация зоны
        /// </summary>
        [DisplayName("Активация зоны")]
        StartActivity,
        /// <summary>
        /// Зона активна
        /// </summary>
        [DisplayName("Зона активна")]
        Active,
        /// <summary>
        /// Деактивация зоны
        /// </summary>
        [DisplayName("Деактивация зоны")]
        EndActivity,
        /// <summary>
        /// Ручная деактивация
        /// </summary>
        [DisplayName("Ручная деактивация")]
        ManualStopped,
        /// <summary>
        /// Ожидает активации
        /// </summary>
        [DisplayName("Ожидает активации")]
        WaitActivated,
        /// <summary>
        /// Ожидает активации
        /// </summary>
        [DisplayName("Ожидает деактивации")]
        WaitDeactivated,
    }
}
