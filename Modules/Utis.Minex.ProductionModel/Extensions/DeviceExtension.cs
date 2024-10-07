using System;
using System.Linq;
using System.Collections.Generic;

namespace Utis.Minex.ProductionModel
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;
    using Utis.Minex.ProductionModel.Devices;

        #endregion

    public static class DeviceExtension
    {
        public static IDictionary<RfidDeviceType, Type> DeviceTypeAssigns 
            = new Dictionary<RfidDeviceType, Type>()
            {
                { RfidDeviceType.Anchor,                typeof(Reader)           },
                { RfidDeviceType.Urpt,                  typeof(Reader)           },
                { RfidDeviceType.Rfu,                   typeof(RFUnit)           },
                { RfidDeviceType.Mur,                   typeof(MobileRegDevice)  },
                { RfidDeviceType.OmnidirectionalAnchor, typeof(MobileRegDevice)  },
                { RfidDeviceType.Pager,                 typeof(Pager)            },
                { RfidDeviceType.SelfRescuer,           typeof(IndividualDevice) },
                { RfidDeviceType.Urs,                   typeof(URS)              },
                { RfidDeviceType.Ga,                    typeof(IndividualDevice) },
                { RfidDeviceType.Ato,                   typeof(MobileMarkPoint)  },
            };

        public static bool IsPerson(this DeviceWithRfid device)
        {
            try
            {
                return ((MobileDeviceType)device.GetRfidDeviceType()).IsPerson();
            }
            catch
            {
                return false;
            }
        }

        public static bool IsTransport(this DeviceWithRfid device)
        {
            try
            {
                return ((MobileDeviceType)device.GetRfidDeviceType()).IsTransport();
            }
            catch
            {
                return false;
            }
        }

        public static LabelKey GetLabelKey(this RfidDevice rfidDevice)
        {
            if (rfidDevice is null)
                return default;

            return new LabelKey(rfidDevice.Rfid, rfidDevice.RfidDeviceType);
        }

        public static RfidDeviceType GetRfidDeviceType(this DeviceWithRfid device)
        {
            if (device == default)
                return default;

            if (device.RfidDevice != default)
                return device.RfidDevice.RfidDeviceType;

            if (device is Reader reader)
                return reader.PositioningType != ReaderPositioningType.Zonal ? RfidDeviceType.Anchor : RfidDeviceType.Urpt;

            return DeviceTypeAssigns.FirstOrDefault(p => p.Value == device.GetType()).Key;
        }

        public static bool IsSupportZonal(this ReaderPositioningType positioningType)
        {
            return positioningType != ReaderPositioningType.Accurate;
        }


        public static RfidDeviceType GetRfidDeviceType(this DeviceWithRfid device, RfidDevice rfidDevice)
        {
            if (device == default)
                return default;

            if (rfidDevice != default)
                return rfidDevice.RfidDeviceType;

            if (device is Reader reader)
                return reader.PositioningType != ReaderPositioningType.Zonal ? RfidDeviceType.Anchor : RfidDeviceType.Urpt;

            return DeviceTypeAssigns.FirstOrDefault(p => p.Value == device.GetType()).Key;
        }

        public static Type GetDeviceClass(this RfidDeviceType rfidDeviceType)
        {
            if (DeviceTypeAssigns.ContainsKey(rfidDeviceType))
            {
                return DeviceTypeAssigns[rfidDeviceType];
            }

            return typeof(RfidDevice);
        }

        public static Type GetDeviceClass(this MobileDeviceType mobileDeviceType)
        {
            return ((RfidDeviceType)mobileDeviceType).GetDeviceClass();
        }

        public static Type GetDeviceClass(this IndividualDeviceType individualDeviceType)
        {
            return ((RfidDeviceType)individualDeviceType).GetDeviceClass();
        }
    }
}