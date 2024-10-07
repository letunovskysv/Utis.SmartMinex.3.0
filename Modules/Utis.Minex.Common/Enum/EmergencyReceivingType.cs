namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип канала получения вызова
    /// </summary>
    public enum EmergencyReceivingType
    {
        /// <summary>
        /// Не определен
        /// </summary>
        [DisplayName("Не определен")]
        Default = 0,

        /// <summary>
        /// Считыватель
        /// </summary>
        [DisplayName("Считыватель")]
        Reader = 1,

        /// <summary>
        /// СУБР
        /// </summary>
        [DisplayName("СУБР")]
        Subr = 2,
    }
}
