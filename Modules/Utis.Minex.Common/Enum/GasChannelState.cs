namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Состояние газового канала
    /// </summary>
    [DisplayName("Состояние газового канала")]
    public enum GasChannelState
    {
        /// <summary>
        /// Отказ канала
        /// </summary>
        [DisplayName("Отказ канала")]
        Error = 0,

        /// <summary>
        /// Канал отключен (отсутствует)
        /// </summary>
        [DisplayName("Канал отключен (отсутствует)")]
        Empty = 1,

        /// <summary>
        /// Канал исправен
        /// </summary>
        [DisplayName("Канал исправен")]
        Ok = 2
    }
}