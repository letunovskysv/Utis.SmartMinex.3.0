using System;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.CommandAndCalls
{
    /// <summary>
    /// Базовый класс вызова/команды/сообщения
    /// </summary>
    [DisplayName("Базовый класс вызова/команды/сообщения")]
    public abstract class CommandCallBase : CatalogBase
    {
        /// <summary>
        /// Имя осуществляющего вызов
        /// </summary>
        [DisplayName("Имя осуществляющего вызов")]
        public virtual string CallerName { get; set; }

        /// <summary>
        /// Время вызова
        /// </summary>
        [DisplayName("Время вызова")]
        public virtual DateTime DateTime { get; set; } = DateTime.Now;
    }
}