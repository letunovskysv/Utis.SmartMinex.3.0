
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Типы зональных событий.
    /// </summary>
    [DisplayName("Типы зональных событий")]
    public enum ZoneEventType
    {
        /// <summary>
        /// Вход в зону.
        /// </summary>
        [DisplayName("Вход в зону")]
        InZone = 0,

        /// <summary>
        /// Выход из зоны.
        /// </summary>
        [DisplayName("Выход из зоны")]
        OutZone = 1,
    }
}