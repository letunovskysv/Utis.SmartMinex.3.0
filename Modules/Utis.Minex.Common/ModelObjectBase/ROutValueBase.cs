namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект значений выходного регистра.
    /// </summary>
    [DisplayName("Значения выходного регистра")]
    [Description("Базовый объект значений выходного регистра")]
    public abstract class ROutValueBase<T> : RValueBase<T> where T : RDimensionBase
    {
        /// <summary>
        /// Дата/время выхода.
        /// </summary>
        [DisplayName("Дата/время выхода")]
        public virtual System.DateTime? Dateout 
        { get; set; }
    }
}