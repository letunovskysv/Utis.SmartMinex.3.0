namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус фиксации АТО
    /// </summary>
    [DisplayName("Статус фиксации АТО")]
    public enum FixationStatus : byte
    {
        /// <summary>
        /// Не задано
        /// </summary>
        [DisplayName("Не задано")]
        Default = 0,

        /// <summary>
        /// Не видели никогда
        /// </summary>
        [DisplayName("Не видели никогда")]
        NotSeen = 1,

        /// <summary>
        /// Видели менее 10 минут назад
        /// </summary>
        [DisplayName("Видели менее 10 минут назад")]
        SeenLessThan10Minutes = 2,

        /// <summary>
        /// Не видели более 10 минут
        /// </summary>
        [DisplayName("Не видели более 10 минут")]
        NotSeen10Minutes = 3,

        /// <summary>
        /// Не видели более 20 минут
        /// </summary>
        [DisplayName("Не видели более 20 минут")]
        NotSeen20Minutes = 4,

        /// <summary>
        /// Видели менее 12 часов назад
        /// </summary>
        [DisplayName("Видели менее 12 часов назад")]
        SeenLessThan12Hours = 5,

        /// <summary>
        /// Не видели более 12 часов
        /// </summary>
        [DisplayName("Не видели более 12 часов")]
        NotSeen12Hours = 6,

        /// <summary>
        /// Не видели более 24 часов
        /// </summary>
        [DisplayName("Не видели более 24 часов")]
        NotSeen24Hours = 7
    }
}