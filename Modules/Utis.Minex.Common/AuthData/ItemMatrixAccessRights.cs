using Utis.Minex.Common;

namespace Utis.Minex.Common.AuthData
{
    /// <summary>
    /// Запись в матрице прав доступа.
    /// </summary>
    public class ItemMatrixAccessRights
    {
        public string RoleName { get; init;}
        public ResourceType ResourceType { get; init; }
        public RoleActionType ActionType {get; init; }

        public override string ToString()
        {
            return $"{RoleName}::{ResourceType}";
        }
    }
}
