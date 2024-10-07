using System;
using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog.Organize;

namespace Utis.Minex.ProductionModel.Journals
{
    /// <summary>
    /// Журнал допущенных лиц
    /// </summary>
    [DisplayName("Журнал допущенных лиц")]
    public class ZoneAccessPersonsJournal : JournalClose, IZoneAccessPersonsJournal
    {
        /// <summary>
        /// Опасная зона
        /// </summary>
        [DisplayName("Опасная зона")]
        public virtual ZoneDangerousJournal ZoneDangerous { get; set; }
        ///<summary>
        /// Допущенное лицо
        /// </summary>
        [DisplayName("Допущенное лицо")]
        public virtual Person Person { get; set; }

        IZoneDangerousJournal IZoneAccessPersonsJournal.ZoneDangerous
        { get => ZoneDangerous; set => ZoneDangerous = value as ZoneDangerousJournal; }
        IPerson IZoneAccessPersonsJournal.Person 
        { get => Person; set => Person = value as Person; }
    }
}
