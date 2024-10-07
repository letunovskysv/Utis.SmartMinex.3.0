namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Extensions for mobile device.
    /// </summary>
    public static class MobileDeviceTypeExtension
    {
        /// <summary>
        /// Проверить тип метки по её номеру и заменить при несовпадении
        /// </summary>
        public static LabelKey Check(this LabelKey labelKey)
        {
            var type = GetTypeByRfid(labelKey.Label);

            if (type == labelKey.Type)
                return labelKey;
            else
                return new LabelKey(labelKey.Label, type);
        }

        //На практике диапазоны игнорируются, вероятнее всего можно выпилить
        public static RfidDeviceType GetTypeByRfid(long rfid)
        {
            RfidDeviceType type;

            switch (rfid & 0xF000)
            {
                case 0xF000: type = RfidDeviceType.Anchor; break;
                case 0xE000: type = RfidDeviceType.Mur;    break;
                case 0x8000: type = RfidDeviceType.Ato;    break;
                case 0x7000: type = RfidDeviceType.Pager;  break;
                case 0x6000: type = RfidDeviceType.Ga;     break;
                case 0x0000: type = RfidDeviceType.Rfu;    break;

                default: 
                    type = default;
                    break;
            }

            return type;
        }

        /// <summary>
        /// Проверка устройств для персонала.
        /// </summary>
        public static bool IsPerson(this MobileDeviceType type)
        {
            return ((RfidDeviceType) type).IsPerson();
        }

        /// <summary>
        /// Проверка устройств для транспорта.
        /// </summary>
        public static bool IsTransport(this MobileDeviceType type)
        {
            return ((RfidDeviceType) type).IsTransport();
        }

        /// <summary>
        /// Проверка устройств для персонала.
        /// </summary>
        public static bool IsPerson(this RfidDeviceType type)
        {
            return 
                type.In(
                    RfidDeviceType.Ga, 
                    RfidDeviceType.Pager, 
                    RfidDeviceType.Rfu, 
                    RfidDeviceType.SelfRescuer);
        }


        /// <summary>
        /// Проверка устройств для транспорта.
        /// </summary>
        public static bool IsTransport(this RfidDeviceType type)
        {
            return 
                type.In(
                    RfidDeviceType.Mur,
                    RfidDeviceType.OmnidirectionalAnchor,
                    RfidDeviceType.Anchor, 
                    RfidDeviceType.Ato);
        }
    }
}
