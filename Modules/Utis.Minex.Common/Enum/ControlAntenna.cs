using System;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Настройка контроля антенн.
    /// </summary>
    [Flags]
    [DisplayName("Настройка контроля антенн")]
    public enum ControlAntenna
    {
        /// <summary>
        /// Без контроля.
        /// </summary>
        [DisplayName("Без контроля")]
        None     = 0,

        /// <summary>
        /// Антенна 1.
        /// </summary>
        [DisplayName("Антенна 1")]
        Antenna1 = 1,

        /// <summary>
        /// Антенна 2.
        /// </summary>
        [DisplayName("Антенна 2")]
        Antenna2 = 2,

        /// <summary>
        /// Антенна 3.
        /// </summary>
        [DisplayName("Антенна 3")]
        Antenna3 = 4,

        /// <summary>
        /// Антенна 4.
        /// </summary>
        [DisplayName("Антенна 4")]
        Antenna4 = 8,
    }
}