using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Журнал действия опасных зон
    /// </summary>
    [DisplayName("Журнал действия опасных зон")]
    public interface IZoneDangerousJournal : IJournalClose
    {
        /// <summary>
        /// Тип опасной зоны
        /// </summary>
        [DisplayName("Тип опасной зоны")]
        DangerousZoneType DangerousZoneType { get; set; }

        /// <summary>
        /// Бинарные данные
        /// </summary>
        byte[] Data { get; set; }

        /// <summary>
        /// Зона географическая
        /// </summary>
        [DisplayName("Зона географическая")]
        IZone Zone { get; set; }

        public string ToString()
        {
            return Zone?.Name;
        } 
    }
}
