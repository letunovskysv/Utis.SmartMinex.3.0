using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Positioning
{
    /// <summary>
    /// Таблица расстояний между субъектами, рассчитанными на основе сырых данных
    /// </summary>
    public class SubjectsDistances: NamedObjectBase
    {
        /// <summary>
        /// Первый субъект
        /// </summary>
        [DisplayName("Первый субъект")]

        public virtual ZoneDefineDevice Subject1 { get; set; }

        /// <summary>
        /// Второй субъект
        /// </summary>
        [DisplayName("Второй субъект")]
        public virtual ZoneDefineDevice Subject2 { get; set; }

        /// <summary>
        /// Расстояние
        /// </summary>
        [DisplayName("Расстояние")]
        public virtual double Distance { get; set; }

        /// <summary>
        /// Группы измеренных расстояний
        /// </summary>
        [DisplayName("Группы измеренных расстояний")]
        public virtual string[] MeasuringDistances { get; set; }
    }
}
