using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Utis.Minex.ProductionModel.Extensions
{
    #region Using 
    
    using Utis.Minex.Common.Enum;
    using Utis.Minex.Common.Interfaces;

    using Utis.Minex.ProductionModel.Devices;
    using Utis.Minex.ProductionModel.MineSpace;
    using Utis.Minex.ProductionModel.MineSpace.MineModel;

        #endregion

    public static class PMCatalogCacheExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetRfidDeviceFromDeviceWithRfid(
            this ICatalogCache catalogCache,
            Type deviceWithRfidType,
            long deviceWithRfidId,
            out RfidDevice rfidDevice
            )
        {
            if (deviceWithRfidId == 0)
            {
                rfidDevice = null;
                return false;
            }

            var deviceWithRfidCache = (DeviceWithRfid)catalogCache.GetEntity(deviceWithRfidId, deviceWithRfidType);

            if (deviceWithRfidCache?.RfidDevice == null)
            {
                rfidDevice = null;
                return false;
            }

            rfidDevice = catalogCache.GetEntity<RfidDevice>(deviceWithRfidCache.RfidDevice.Id);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetDeviceWithRfidByRfidDeviceId<T>(this ICatalogCache catalogCache, long rfidDeviceId, bool includeDeletedEntities = false) where T : DeviceWithRfid
        {
            if (includeDeletedEntities)
            {
                var devices = catalogCache
                    .GetAllEntities<T>()
                    .Where(wh => wh.RfidDevice != null && wh.RfidDevice.Id == rfidDeviceId)
                    .ToList()
                    .OrderByDescending(x => x.Updated)
                    .ThenByDescending(x => x.Created)
                    .ToList();

                return devices.FirstOrDefault(x => !x.Deleted) ?? devices.FirstOrDefault();
            }

            return catalogCache
                .GetAllEntities<T>()
                .FirstOrDefault(wh => wh.RfidDevice != null && wh.RfidDevice.Id == rfidDeviceId && wh.Deleted == false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetDeviceWithRfidByLabel<T>(this ICatalogCache catalogCache, int rfid, RfidDeviceType deviceType, bool includeDeletedEntities = false) where T : DeviceWithRfid
        {
            var rfidDevice = catalogCache.GetRfidDeviceByLabel(rfid, deviceType, includeDeletedEntities:includeDeletedEntities);

            if (rfidDevice == null)
            {
                return default;
            }

            return
                catalogCache.GetDeviceWithRfidByRfidDeviceId<T>(rfidDevice.Id, includeDeletedEntities:includeDeletedEntities);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RfidDevice GetRfidDeviceByLabel(this ICatalogCache catalogCache, int rfid, RfidDeviceType deviceType, bool includeDeletedEntities = false)
        {
            return catalogCache
                    .GetAllEntities<RfidDevice>()
                    .FirstOrDefault(wh => wh.Rfid == rfid && wh.RfidDeviceType == deviceType && (wh.Deleted == false || wh.Deleted == includeDeletedEntities));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInMine(this ZoneDefineDevice device, int antenna = 0)
        {
            var isOutputAntenna = ((device as Reader)?.ReaderType == ReaderType.Output ||
                                   ((device as Reader)?.ReaderType == ReaderType.Combined && antenna == 2));

            return !isOutputAntenna;
        }
    }
}