using System;
using System.Collections.Generic;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Helpers
{
    public static class ResourceHelper
    {
        /// <summary>
        /// Проверка наличия права
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public static IEnumerable<OperationType> GetAccessOperations(params ResourceType[] resources)
        {
            List<OperationType> accessOpers = new();

            foreach (var resourceType in resources)
            {
                var access = AuthorizedUserData.GetActionTypeByCurrentRole(resourceType);
                if (access == RoleActionType.Read)
                    return Array.Empty<OperationType>();

                if (access.HasFlag(RoleActionType.Update))
                    accessOpers.Add(OperationType.Update);
                if (access.HasFlag(RoleActionType.Delete))
                    accessOpers.Add(OperationType.Delete);
                if (access.HasFlag(RoleActionType.Create))
                    accessOpers.Add(OperationType.Create);
            }

            return accessOpers;
        }
    }
}
