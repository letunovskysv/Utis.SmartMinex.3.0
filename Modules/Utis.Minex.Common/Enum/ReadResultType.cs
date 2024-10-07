
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип заполнения DTO от сервера к клиенту.
    /// </summary>
    [DisplayName("Тип заполнения DTO от сервера к клиенту")]
    public enum ReadResultType : byte
    {
        /// <summary>
        /// По умолчанию.
        /// </summary>
        [DisplayName("По умолчанию")]
        Default = 0,

        /// <summary>
        /// Заполнить <c>RefObjectDTO</c>.
        /// </summary>
        [DisplayName("Заполнить RefObjectDTO")]
        ReturnRefObjectDTO = 1,

        /// <summary>
        /// Заполнить реальные свойства DTO.
        /// </summary>
        [DisplayName("Заполнить реальные свойства DTO")]
        ReturnFullDTO = 2,
    }
}