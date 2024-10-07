using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Interfaces
{
    public interface IZoneDefineDeviceCache
    {
        void Start();

        void Stop();

        CatalogBase GetZoneDeviceByLabel(int label, RfidDeviceType rfidDeviceType);
    }
}
