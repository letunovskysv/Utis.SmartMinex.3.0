using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.Catalog.Organize;
using Utis.Minex.ProductionModel.Devices;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Нарушения смен
    /// </summary>
    public class ShiftViolationJournal : Journal
    {
        /// <summary>
        /// Смена.
        /// </summary>
        [DisplayName("Смена")]
        public Shift Shift { get; set; }

        /// <summary>
        /// Начало смены.
        /// </summary>
        [DisplayName("Начало смены")]
        public DateTime ShiftBegin { get; set; }

        /// <summary>
        /// Конец смены.
        /// </summary>
        [DisplayName("Конец смены")]
        public DateTime ShiftEnd { get; set; }

        /// <summary>
        /// Индивидуальное устройство.
        /// </summary>
        [DisplayName("Индивидуальное устройство")]
        public IndividualDevice IndividualDevice { get; set; }

        /// <summary>
        /// Светильник.
        /// </summary>
        [DisplayName("Светильник")]
        public Lamp Lamp { get; set; }

        /// <summary>
        /// Человек.
        /// </summary>
        [DisplayName("Человек")]
        public Person Person { get; set; }

        /// <summary>
        /// Тип нарушения.
        /// </summary>
        [DisplayName("Тип нарушения")]
        public ViolationType ViolationType { get; set; }
    }

}
