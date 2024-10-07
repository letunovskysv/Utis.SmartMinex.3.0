//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
// Описание: Класс, описывающий журнал действия опасных зон.
//--------------------------------------------------------------------------------------------------
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;
using Utis.Minex.ProductionModel.MineSpace;

namespace Utis.Minex.ProductionModel.Journals
{

    /// <summary>
    /// Журнал действия опасных зон
    /// </summary>
    [DisplayName("Журнал действия опасных зон")]
    public class ZoneDangerousJournal : JournalClose, IZoneDangerousJournal
    {
        [DisplayName("Тип опасной зоны")]
        public virtual DangerousZoneType DangerousZoneType { get; set; }

        /// <summary>
        /// Зона
        /// </summary>
        public virtual Zone Zone { get; set; }

        /// <summary>
        /// Дополнительные данные
        /// </summary>
        public virtual byte[] Data { get; set; }

        IZone IZoneDangerousJournal.Zone 
        { get => Zone; set => Zone = value as Zone; }
    }
}