namespace Utis.Minex.Common.Enum
{
    [DisplayName("Тип вызова по числу абонентов")]
    public enum CallQuantityType
    {
        [DisplayName("Групповой вызов")]
        GroupCall = 0,
        [DisplayName("Индивидуальный вызов")]
        IndividualCall = 1,
        [DisplayName("Индивидуальный вызов из шахты")]
        IndividualCallFromMine = 2
    }
}
