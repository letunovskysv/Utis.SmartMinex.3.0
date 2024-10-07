using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект интеграционной таблицы.
    /// </summary>
    [DisplayName("Базовый объект интеграционной таблицы")]
    public abstract class AcceptObjectBase : VersionObjectBase
    {
        /// <summary>
        /// Флаг статуса получения данных принимающей стороной.
        /// 0 - По умолчанию.
        /// 1 – Принимающая сторона вычитала данные. 
        /// </summary>
        [DisplayName("Cтатус получения данных")]
        [Description("Cтатус получения данных")]
        public virtual long Accepted
        { get; set; }

        /// <summary>
        /// Отметка времени когда принимающая сторона получила данные.
        /// По умолчанию NULL, заполняется принимающей стороной. 
        /// Заполнение этой колонки вызывает простановку флага Accepted.
        /// </summary>
        [DisplayName("Дата/время получения данных")]
        [Description("Дата/время получения данных")]
        public virtual DateTime? AcceptedDate
        { get; set; }
    }
}