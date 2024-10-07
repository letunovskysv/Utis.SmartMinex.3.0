namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип привязки
    /// </summary>
    [DisplayName("Тип привязки")]
    public enum PersonBindType
    {
        /// <summary>
        /// Доступ к проведению ВР
        /// </summary>
        [DisplayName("Доступ к проведению ВР")]
        ExploseWork = 0,
        /// <summary>
        /// Принадлежность к ВГК
        /// </summary>
        [DisplayName("Принадлежность к ВГК")]
        VGK = 1
    }
}
