namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип события позиционирования УРПТ-ИС-Т относительно АТО.
    /// </summary>
    public enum TransportRTLSEventType
    {
        DEFAULT = 0,
        APPEAR = 1,  //появление
        MAX_CLOSE = 2,  //макс. сближение
        DISAPPEAR = 3,  //пропадание
        APPEAR_NO_DISTANCE = 4,  //появление  (без расстояний)
        DISAPPEAR_NO_DISTANCE = 5,  //пропадание (без расстояний)
    }
}
