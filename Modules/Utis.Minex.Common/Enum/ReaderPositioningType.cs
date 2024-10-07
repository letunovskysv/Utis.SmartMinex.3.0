namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип получаемых данных позиционирования
    /// </summary>
    [DisplayName("Тип получаемых данных")]
    public enum ReaderPositioningType
    {
        /// <summary>
        /// Точное
        /// </summary>
        [DisplayName("Точное")]
        Accurate = 0,

        /// <summary>
        /// Зональное
        /// </summary>
        [DisplayName("Зональное")]
        Zonal  = 1,

        /// <summary>
        /// Точно-зональное.
        /// </summary>
        [DisplayName("Точно-зональное")]
        Combined = 2,
    }
}