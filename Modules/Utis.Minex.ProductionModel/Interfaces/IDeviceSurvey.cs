using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Interfaces
{
    /// <summary>
    /// Устройство которое можно опрашивать
    /// </summary>
    public interface IDeviceSurvey
    {
        /// <summary>
        /// Опрос линии включен
        /// </summary>
        [DisplayName("Опрос линии включен")]
        bool IsEnable { get; set; }
    }
}