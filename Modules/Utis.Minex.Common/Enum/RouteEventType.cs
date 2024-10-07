namespace Utis.Minex.Common.Enum
{
    /// <summary>Типы событий маршрута</summary>
    [DisplayName("Типы событий маршрута")]
    public enum RouteEventType
    {
        Default = 0,

        /// <summary>Отклонение от маршрута</summary>
        [DisplayName("Отклонение от маршрута")]
        GetOffRoute = 1,

        /// <summary>Возврат на маршрут</summary>
        [DisplayName("Возврат на маршрут")]
        BackToRoute = 2
    }
}