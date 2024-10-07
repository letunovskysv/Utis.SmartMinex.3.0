using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал приязок типов зон к зонам.
    /// </summary>
    [DisplayName("Журнал привязок типов зон к зонам")]
    public interface IZoneTypeJournal : IJournalClose
    {
        /// <summary>
        /// Зона.
        /// </summary>
        [DisplayName("Зона")]
        [Description("Зона")]
        IZone Zone
        { get; set; }


        /// <summary>
        /// Стационарное оборудование позиционирования для привязки.
        /// </summary>
        [DisplayName("Стационарное оборудование позиционирования для привязки")]
        IZoneType ZoneType
        { get; set; }
    }

    public interface IZoneType
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [DisplayName("Наименование")]
        string Name { get; set; }
    }
}
