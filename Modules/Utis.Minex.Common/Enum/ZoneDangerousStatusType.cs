namespace Utis.Minex.Common
{
    /// <summary>
    /// Статус проверки события
    /// </summary>
    public enum ZoneDangerousStatusType: int
    {
        /// <summary>
        /// Наличие поврежденных устройств в зоне
        /// </summary>
        IsDamagedDevices,
        /// <summary>
        /// Не назначен постовой
        /// </summary>
        IsNotSetGuard,
        /// <summary>
        /// Не назначены допущенные лица
        /// </summary>
        IsNotSetAccessPersons,
        /// <summary>
        /// Не назначено расписание
        /// </summary>
        IsNotSetSheduler
    }
}
