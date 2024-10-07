using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.CommandAndCalls
{
    /// <summary>
    /// Тип вызова
    /// </summary>
    
    [DisplayName("Тип вызова")]
    [Description("Тип вызова")]
    public class CallType : CatalogBase
    {
        /// <summary>
        /// Номер вызова
        /// </summary>
        [DisplayName("Номер вызова")]
        [Description("Номер вызова")]
        public virtual int CallNumber { get; set; }

        /// <summary>
        /// Доступен для отображения
        /// </summary>
        [DisplayName("Доступен для отображения")]
        [Description("Доступен для отображения")]
        public virtual bool EnabledForDisplay { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DisplayName("Описание")]
        [Description("Описание")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Не отключаемый 
        /// </summary>
        [DisplayName("Отображается всегда")]
        [Description("Отображается всегда")]
        public virtual bool AlwaysEnabledForDisplay { get; set; }

        /// <summary>
        /// Не отключаемый 
        /// </summary>
        [DisplayName("Тип вызова по числу абонентов")]
        [Description("Тип вызова по числу абонентов")]
        public virtual CallQuantityType CallQuantityType { get; set; }
    }
}
