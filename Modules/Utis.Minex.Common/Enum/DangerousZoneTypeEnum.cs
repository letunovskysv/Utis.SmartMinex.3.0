using System;
using System.Drawing;

namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип опасной зоны
    /// </summary>
    /// <remarks>
    /// В модуле ZoneDangerousModule происходит сортировка по убыванию, зоны с более высоким приоритетом должны иметь большее значение
    /// </remarks>
    [DisplayName("Типы опасной зоны")]
    [Serializable]
    public enum DangerousZoneType
    {
        /// <summary>
        /// Опасная
        /// </summary>
        [DisplayName("Опасная зона")]
        [CanSelectDangerousZoneTypeAttribute(true)]
        Default = 0,

        /// <summary>
        /// Зона взрывных работ
        /// </summary>
        [DisplayName("Зона взрывных работ")]
        [CanSelectDangerousZoneTypeAttribute(true)]
        Explosion = 1,

        /// <summary>
        /// Зона постового
        /// </summary>
        [DisplayName("Зона постового")]
        [CanSelectDangerousZoneTypeAttribute(false)]
        Guard = 2
    }

    public static class DangerousZoneTypeEnumextensions
    {
        public static Color DangerousZoneTypeToColor(this DangerousZoneType dangerousZoneType, bool active)
        {
            switch (dangerousZoneType)
            {
                case DangerousZoneType.Default:
                {
                    return Color.Red;
                }
                case DangerousZoneType.Explosion:
                {
                    return active ? Color.Tomato : Color.Goldenrod;
                }
                case DangerousZoneType.Guard:
                {
                    return active ? Color.Yellow : Color.Gray;
                }
                default:
                {
                    return Color.Red;
                }
            }
        }
    }
}
