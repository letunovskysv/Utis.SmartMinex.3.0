using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый класс события поступления сырых данных.
    /// </summary>
    [DisplayName("Событие поступления сырых данных")]
    public abstract class DAEventBase : ObjectBase
    {
        /// <summary>
        /// Дата, время поступления события из источника, фиксации в БД.
        /// </summary>
        [DisplayName("Зафиксировано")]
        [Description("Дата/время поступления события из источника, фиксации в БД")]
        public virtual DateTime Datetime 
        { get; set; } = DateTime.Now;
    }
}