namespace Utis.Minex.Common.Enum
{
    [DisplayName("Состояние линии")]
    public enum LineState
    {
        /// <summary>
        ///Обрыв линии.
        /// </summary>
        [DisplayName("Обрыв линии")]
        Breakage = 0,

        /// <summary>
        ///Обрыв линии устранен.
        /// </summary>
        [DisplayName("Обрыв линии устранен")]
        Recovery = 1,
    }
}