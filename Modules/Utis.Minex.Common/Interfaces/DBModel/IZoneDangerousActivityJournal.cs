namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал изменений по опасным зонам
    /// </summary>
    [DisplayName("Журнал изменений по опасным зонам")]
    public interface IZoneDangerousActivityJournal: IJournal
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        IZoneDangerousJournal ZoneDangerous { get; set; }
        ///<summary>
        /// Автор изменения
        /// </summary>
        [DisplayName("Автор изменения")]
        IUserData User { get; set; }

        ///<summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        string Description { get; set; }
    }
}
