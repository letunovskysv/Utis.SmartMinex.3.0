using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Состав электровоза
    /// </summary>
    [DisplayName("Состав электровоза")]
    public class TrainJournal : DateOutJournal
    {
        /// <summary>
        /// Локомотив
        /// </summary>
        [DisplayName("Локомотив")]
        public virtual Transport Transport { get; set; }

        /// <summary>
        /// Тип вагонов
        /// </summary>
        [DisplayName("Тип вагонов")]
        public virtual RailCarType RailCarType { get; set; }

        /// <summary>
        /// Локомотив
        /// </summary>
        [DisplayName("Количество вагонов")]
        public virtual byte RailCarCount { get; set; } = 9;

        /// <summary>
        /// Длина м.
        /// </summary>
        [DisplayName("Длина м.")]
        public virtual float Lenght { get; set; } // => (RailCarCount * RailCarType.Lenght + Длина локомотива)
    }
}
