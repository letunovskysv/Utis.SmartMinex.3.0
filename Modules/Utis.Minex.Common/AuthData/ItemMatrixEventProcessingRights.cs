using Utis.Minex.Common;

namespace Utis.Minex.Common.AuthData
{
    /// <summary>
    /// Запись в матрице соответствия для обработки сообщения.
    /// </summary>
    public class ItemMatrixEventProcessingRights
    {
        public string RoleName { get; init; }
        public ResourceEventType ResourceType { get; init; }
        public EventProcessingType ActionType { get; init; }
    }
}
