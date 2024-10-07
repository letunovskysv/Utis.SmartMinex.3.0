namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал допущенных лиц
    /// </summary>
    [DisplayName("Журнал допущенных лиц")]
    public interface IZoneAccessPersonsJournal : IJournalClose
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        IZoneDangerousJournal ZoneDangerous { get; set; }
        ///<summary>
        /// Допущенное лицо
        /// </summary>
        [DisplayName("Допущенное лицо")]
        IPerson Person { get; set; }
    }
}
