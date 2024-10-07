namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект значений выходного регистра.
    /// </summary>
    [DisplayName("Значения регистра, связывающего два каталога")]
    [Description("Базовый объект значений регистра, связывающего два каталога")]
    public abstract class RBindValueBase<T> : ROutValueBase<T> where T : RDimensionBase
    {

    }
}