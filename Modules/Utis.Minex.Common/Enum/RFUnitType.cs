
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип радиоблока.
    /// </summary>
    [DisplayName("Тип радиоблока")]
    public enum RFUnitType
    {
        /// <summary>
        /// Не задано.
        /// </summary>
        [DisplayName("Не задано")]
        Default = 0,

        /// <summary>
        /// Субр-01СМ.
        /// </summary>
        [DisplayName("Субр-01СМ")]
        SUBR01 = 1,

        /// <summary>
        /// Субр-02СМ.
        /// </summary>
        [DisplayName("Субр-02СМ")]
        SUBR02 = 2,

        /// <summary>
        /// Субр-03СМ.
        /// </summary>
        [DisplayName("Субр-03СМ")]
        SUBR03 = 3,

        /// <summary>
        /// МГ-01 Исеть.
        /// </summary>
        [DisplayName("МГ-01 Исеть")]
        MG01ISet = 4,
    }
}