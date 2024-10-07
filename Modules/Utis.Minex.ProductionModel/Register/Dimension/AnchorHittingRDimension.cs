//--------------------------------------------------------------------------------------------------
// (C) 2019 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий регистр срезов наезда точного позиционирования.
//--------------------------------------------------------------------------------------------------
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Register.Dimension
{
    /// <summary>
    /// Срез регистра наезда точного позиционирования
    /// </summary>
    [DisplayName("Регистр срезов наезда")]
    [Description("Срез регистра наезда точного позиционирования")]
    public class AnchorHittingRDimension : RBindDimensionBase
    {
        /// <summary>
        /// Устройство с меткой
        /// </summary>
        [DisplayName("Устройство с меткой")]
        public virtual Device RfidDevice { get; set; }        
    }
}