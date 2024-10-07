using System;
using System.Collections.Generic;
using Utis.Minex.Common;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    public class DamageDevicesCache
    {
        public DamageDevicesCache(IEnumerable<IZoneBindDeviceJournal> zoneDefineDeviceCache,
                                  Dictionary<long, DeviceState> deviceStateCache, 
                                  Dictionary<long, AntennaState> antennaStateCache,
                                  Dictionary<long, Tuple<long, LineState>> lineStateCache,
                                  Dictionary<long, Tuple<long, DeviceState>> portStateCache,
                                  List<IReadersToLineEvents> readersToLineCache)
        {
            ZoneDefineDeviceCache = zoneDefineDeviceCache;
            DeviceStateCache = deviceStateCache;
            AntennaStateCache = antennaStateCache;  
            LineStateCache = lineStateCache;
            PortStateCache = portStateCache;
            ReadersToLineCache = readersToLineCache;
        }

        public IEnumerable<IZoneBindDeviceJournal> ZoneDefineDeviceCache{ get; init; }
        public Dictionary<long, DeviceState> DeviceStateCache { get; init; }
        public Dictionary<long, AntennaState> AntennaStateCache { get; init; }
        public Dictionary<long, Tuple<long, LineState>> LineStateCache { get; init; }
        public Dictionary<long, Tuple<long, DeviceState>> PortStateCache{ get; init; }
        public List<IReadersToLineEvents> ReadersToLineCache { get; init; }
    }
}
