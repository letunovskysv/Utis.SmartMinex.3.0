
namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект значений журнала.
    /// </summary>
    [DisplayName("Значения регистра")]
    [Description("Базовый объект значений регистра")]
    public abstract class RValueBase<T> : RegisterBase where T : RDimensionBase
    {
        /// <summary>
        /// Инициализирует базовый объект значений журнала.
        /// </summary>
        public RValueBase()
        {
            Datetime = System.DateTime.Now;
        }

        /// <summary>
        /// Дата/время записи.
        /// </summary>
        [DisplayName("Дата/время")]
        [Description("Дата/время записи")]
        public virtual System.DateTime Datetime 
        { get; set; }

        /// <summary>
        /// Измерение.
        /// </summary>
        [DisplayName("Измерение")]
        public virtual T Dimension 
        { get; set; }
    }
}