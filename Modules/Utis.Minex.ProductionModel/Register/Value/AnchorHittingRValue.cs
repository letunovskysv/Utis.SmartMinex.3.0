//--------------------------------------------------------------------------------------------------
// (C) 2019 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий регистр наезда точного позиционирования.
//--------------------------------------------------------------------------------------------------
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.Register.Dimension;

namespace Utis.Minex.ProductionModel.Register.Value
{
    /// <summary>
    /// Регистр наезда точного позиционирования
    /// </summary>
    [DisplayName("Регистр наезда")]
    [Description("Регистр наезда точного позиционирования")]
    public class AnchorHittingRValue : RBindValueBase<AnchorHittingRDimension>
    {
        /// <summary>
        /// Устройство
        /// </summary>
        [DisplayName("Устройство")]
        public virtual Device Device { get; set; }
    }
}