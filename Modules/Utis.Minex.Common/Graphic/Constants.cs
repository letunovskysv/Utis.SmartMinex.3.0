namespace Utis.Minex.Common.Graphic
{
    /// <summary>Класс вспомогательной информации по графике</summary>
    public static class Constants
    {
        /// <summary>Максимальная длина секций</summary>
        public const float EDGE_LENGTH = 1F;

        /// <summary>Ширина сечения</summary>
        public const float SECTION_WIDTH = 4F;
        
        /// <summary>Максимальная длина действия анкера</summary>
        public const float MAX_ANCHOR_DISTANCE = 700F;

        /// <summary>Максимальная длина пути для поиска</summary>
        public const float MAX_PATH_FIND_DISTANCE = 2000F;

        /// <summary>Максимально допустимая ошибка в расстановке анкеров, которую будет "гасить" алгоритм</summary>
        public const float MAX_ANCHOR_LOCATION_ERROR = 15F;

        /// <summary>Зона анкера по обе стороны антенн, где происходит их стабилизация</summary>
        public const float ANCHOR_LOCAL_ZONE = 20F;

        /// <summary>Расстояние от акера до перекрёстка</summary>
        public const float ANCHOR_WITH_CROSSROAD = 10F;

        /// <summary> Минимальное расстояние, с которого при ведении одним анкером начинаем учитывать RSSI </summary>
        public const byte RSSI_DISTANCE_DELTA = 25;

        /// <summary> Минимальная разница в RSSI двух антен одного анкера для определения направления </summary>
        public const byte RSSI_DELTA = 4;

        /// <summary> Допустимая разница в дистанциях между антеннами </summary>
        public const byte ANTENNS_DELTA_DISTANCE = 10;
    }
}