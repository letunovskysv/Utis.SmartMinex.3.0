//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий справочник радиоблоков.
//--------------------------------------------------------------------------------------------------
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.ProductionModel.Devices
{
    /// <summary>
    /// Радиоблок
    /// </summary>
    [DisplayName("Радиоблок")]
    public class RFUnit : IndividualDevice
    {
        /// <summary>Конструктор</summary>
        public RFUnit()
        {
        }
        
        /// <summary>Тип радиоблока</summary>
        [DisplayName("Тип радиоблока")]
        public virtual RFUnitType RFUnitType { get; set; }

        /// <summary>Канал радиоблока</summary>
        [DisplayName("Канал радиоблока")]
        public virtual RFUnitRxType RFUnitRxType { get; set; }
        /// <summary>
        /// Код СУБР.
        /// </summary>
        [DisplayName("Код СУБР")]
        public long SUBRCode { get; set; }
    }
}