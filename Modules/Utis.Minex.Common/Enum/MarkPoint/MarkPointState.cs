
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Статус АТО. 
    /// </summary>
    [DisplayName("Статус АТО")]
    public enum MarkPointState
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [DisplayName("Не определено")]
        [Description("Не определено")]
        None = 0,

        /// <summary>
        /// Установлено.
        /// </summary>
        [DisplayName("Установлено")]
        [Description("Установлено")]
        Mounted = 1,

        /// <summary>
        /// На хранении.
        /// </summary>
        [DisplayName("На хранении")]
        [Description("На хранении")]
        Stored = 2,

        /// <summary>
        /// Утеряно.
        /// </summary>
        [DisplayName("Утеряно")]
        [Description("Утеряно")]
        Lost  = 4,
    }
}