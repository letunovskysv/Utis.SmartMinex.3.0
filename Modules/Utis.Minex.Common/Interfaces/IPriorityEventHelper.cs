using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    public interface IPriorityEventHelper
    {
        /// <summary>
        /// Сконвертировать в событие с приоритетом
        /// </summary>
        /// <param name="eventBase">событие(сырые данные)</param>
        T ConvertToPriorityEvent<T>(DAEventBase eventBase, CatalogBase source = null, bool logging=true) where T : PriorityEventBase;

        /// <summary>
        /// Сохранить событие в БД
        /// </summary>
        T PriorityEventSave<T>(T priorityEvent) where T : PriorityEventBase;

        /// <summary>
        /// Получить статус события
        /// </summary>
        StateEvent GetStateEvent(dynamic otherValue);
    }
}