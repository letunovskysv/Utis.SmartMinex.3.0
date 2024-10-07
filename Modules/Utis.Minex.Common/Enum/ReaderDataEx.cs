using System;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Дополнительные сведения о считывателе: нажатие кнопки, регистрация метки на антеннах №1-4
    /// </summary>
    [Flags]
    [DisplayName("Блок данных от считывателя")]
    public enum ReaderDataEx : int
    {
        /// <summary>
        /// DefaultValue.
        /// </summary>
        [DisplayName("DefaultValue")]
        Empty    = 0,

        /// <summary>
        /// Событие нажатия кнопки.
        /// </summary>
        [DisplayName("Событие нажатия кнопки")]
        Button   = 1,

        /// <summary>
        /// Идентификация на антенне 1.
        /// </summary>
        [DisplayName("Идентификация на антенне 1")]
        Antenna1 = 2,

        /// <summary>
        /// Идентификация на антенне 2.
        /// </summary>
        [DisplayName("Идентификация на антенне 2")]
        Antenna2 = 4,

        /// <summary>
        /// Идентификация на антенне 3.
        /// </summary>
        [DisplayName("Идентификация на антенне 3")]
        Antenna3 = 8,

        /// <summary>
        /// Идентификация на антенне 4.
        /// </summary>
        [DisplayName("Идентификация на антенне 4")]
        Antenna4 = 16,
    }
}