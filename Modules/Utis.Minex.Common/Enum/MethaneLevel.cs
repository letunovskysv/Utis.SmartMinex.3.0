
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Значение метана в кадегории ПДК.
    /// </summary>
    [DisplayName("Значение метана в кадегории ПДК")]
    public enum MethaneLevel : byte
    {
        /// <summary>
        /// Норма ПДК.
        /// </summary>
        [DisplayName("Норма ПДК")]
        NormaMPC = 0,

        /// <summary>
        /// Повышенный уровень ПДК.
        /// </summary>
        [DisplayName("Повышенный уровень ПДК")]
        ElevatedMPC = 1,

        /// <summary>
        /// Превышение ПДК.
        /// </summary>
        [DisplayName("Превышение ПДК")]
        ExcessMPC = 2,
    }
}