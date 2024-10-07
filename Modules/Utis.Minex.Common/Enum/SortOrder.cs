namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Порядок сортировки
    /// </summary>
    [DisplayName("Порядок сортировки")]
    public enum SortOrder
    {
        /// <summary>
        /// Без сортировки
        /// </summary>
        [DisplayName("Без сортировки")]
        None = 0,

        /// <summary>
        /// По возрастанию
        /// </summary>
        [DisplayName("По возрастанию")]
        Asc = 1,

        /// <summary>
        /// По убыванию
        /// </summary>
        [DisplayName("По убыванию")]
        Desc = 2
    }
}