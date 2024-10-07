using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Devices;
using Utis.Minex.ProductionModel.MineSpace;

namespace Utis.Minex.ProductionModel.Journals
{
    public class ZoneBindDeviceJournal : JournalClose, IZoneBindDeviceJournal
    {
        public virtual Zone Zone
        { get; set; }

        public virtual int Antenna
        { get; set; }

        public virtual ZoneDefineDevice ZoneDefineDevice
        { get; set; }
        public virtual bool IsManual 
        { get; set; }

        IZoneDefineDevice IZoneBindDeviceJournal.ZoneDefineDevice
        { get => ZoneDefineDevice; set => ZoneDefineDevice = value as ZoneDefineDevice; }
        IZone IZoneBindDeviceJournal.Zone
        { get => Zone; set => Zone = value as Zone; }
    }
}
