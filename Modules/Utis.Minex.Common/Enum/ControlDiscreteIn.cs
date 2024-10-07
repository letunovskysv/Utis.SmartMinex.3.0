using System;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Контроль дискретных входов.
    /// </summary>
    [Flags]
    [DisplayName("Контроль дискретных входов")]
    public enum ControlDiscreteIn
    {
        /// <summary>
        /// Отключено.
        /// </summary>
        [DisplayName("Отключено")]
        Disabled = 0,

        /// <summary>
        /// Вход 1.
        /// </summary>
        [DisplayName("Вход 1")]
        Input1 = 1,

        /// <summary>
        /// Вход 2.
        /// </summary>
        [DisplayName("Вход 2")]
        Input2 = 2,
    }
}