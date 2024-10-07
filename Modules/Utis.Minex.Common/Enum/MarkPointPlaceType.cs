namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы размещения АТО
    /// </summary>
    [DisplayName("Типы размещения АТО")]
    public enum MarkPointPlaceType : byte
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        [DisplayName("Значение по умолчанию")]
        None = 0,

        /// <summary>
        /// В выработке
        /// </summary>
        [DisplayName("В выработке")]
        Excavation = 1,


        /// <summary>
        /// На сопряжении выработок
        /// </summary>
        [DisplayName("На сопряжении выработок")]
        JoinExcavation = 2
    }
}
