using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Тип обработки сообщения.
    /// </summary>
    [Flags]
    [DisplayName("Тип обработки сообщения")]
    [Description("Тип обработки сообщения")]
    public enum EventProcessingType
    {
        /// <summary>             
        /// Не установлено.            
        /// </summary>
        [DisplayName("Не установлено")]
        NonSet = 0,

        /// <summary>
        /// Выводить в список сообщений.
        /// </summary>
        [DisplayName("Выводить в список сообщений")]
        ShowInListMsg = 1,

        /// <summary>
        /// Квитация сообщений.
        /// </summary>
        [DisplayName("Квитация сообщений")]
        AckingOfMessages = 2,

        //todo: ...

        /// <summary>
        /// Not changeable.
        /// </summary>
        [DisplayName("Неизменяемый")]
        [EnumDetailEditable(false)]
        NotChangeable = 16,
    }
}
