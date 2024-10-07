
namespace Utis.Minex.Common.Enum
{
    /// <summary>
    /// Тип вызывающего аварию.
    /// </summary>
    [DisplayName("Тип аварийного вызова")]
    public enum EmergencyCallType
    {
        /// <summary>
        /// Не задано.
        /// </summary>
        [DisplayName("Не задано")]
        Default = 0,
        
        /// <summary>
        /// Команда диспетчера/оператора.
        /// </summary>
        [DisplayName("Авария в шахте!")]
        MineAlarm = 1,
        
        /// <summary>
        /// Сброс общего аварийного вызова.
        /// </summary>
        [DisplayName("Сброс общего аварийного вызова")]
        MineReset = 2,
        
        /// <summary>
        /// Сброс аварийного вызова.
        /// </summary>
        [DisplayName("Сброс аварийного вызова из шахты")]
        RaiseReset = 4,
    }
}