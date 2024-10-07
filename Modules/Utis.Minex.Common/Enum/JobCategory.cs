
namespace Utis.Minex.Common.Enum
{   
    /// <summary>
    /// Категория (инженерно-технический работник).
    /// </summary>
    [DisplayName("Категория")]
    public enum JobCategory
    {
        /// <summary>
        /// Работник (Рабочие).
        /// </summary>
        [DisplayName("Рабочий")]
        Worker = 0,

        /// <summary>
        /// ИТР.
        /// </summary>
        [DisplayName("ИТР")]
        Engineer = 1,
    }
}