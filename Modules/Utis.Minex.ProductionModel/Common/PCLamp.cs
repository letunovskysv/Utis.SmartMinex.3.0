using Utis.Minex.ProductionModel.Positioning;

namespace Utis.Minex.ProductionModel.Common
{
    using Utis.Minex.Common;

    /// <summary>
    /// Регистрация подключения АРМ Ламповой
    /// </summary>
    [DisplayName("АРМ-Л")]
    [Description("Регистрация подключения АРМ Ламповой")]
    public class PCLamp : DataProviderServer
    {
        /// <summary>
        /// Ламповая
        /// </summary>
        [DisplayName("Ламповая")]
        public virtual IndividualDevicesRoom Room { get; set; }
    }
}