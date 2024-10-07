using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый класс для события внутрисистемного обмена.
    /// </summary>
    public class CrossmodularEventBase
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DisplayName("Идентификатор")]
        [Description("Идентификатор")]
        public long Id
        { get; set; }

        /// <summary>
        /// Дата/время поступления события из источника.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника")]
        public DateTime Datetime 
        { get; set; }
    }
}