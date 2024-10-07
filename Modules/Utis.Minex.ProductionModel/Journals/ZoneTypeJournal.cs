using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Catalog;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.MineSpace;

namespace Utis.Minex.ProductionModel.Journals
{
    public class ZoneTypeJournal : JournalClose, IZoneTypeJournal
    {
        /// <summary>
        /// Тип
        /// </summary>
        [DisplayName("Тип")]
        public virtual ZoneType ZoneType { get; set; }

        /// <summary>
        /// Зона
        /// </summary>
        [DisplayName("Зона")]
        public virtual Zone Zone { get; set; }

        IZone IZoneTypeJournal.Zone
        { get => Zone; set => Zone = value as Zone; }
        IZoneType IZoneTypeJournal.ZoneType
        { get => ZoneType; set => ZoneType = value as ZoneType; }
    }
}
