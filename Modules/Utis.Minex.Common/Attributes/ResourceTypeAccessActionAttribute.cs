using System;
using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Attributes;

namespace Utis.Minex.Common.Attributes
{
    /// <summary>
    /// Атрибут допустимых прав <see cref="ResourceType"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ResourceTypeAccessActionAttribute : Attribute
    {
        public IEnumerable<RoleActionType> AccessActions { get; }
        public ResourceTypeAccessActionAttribute(params RoleActionType[] accessActions)
        {
            AccessActions = accessActions ??
                throw new ArgumentNullException(nameof(accessActions));
        }
    }
}

namespace Utis.Minex.Common
{
    public static class ResourceTypeAccessActionAttributeHelper
    {
        /// <summary>
        /// Получить доступные действия
        /// </summary>
        /// <param name="rt"></param>
        /// <returns></returns>
        public static IEnumerable<RoleActionType> GetAccessActions(this ResourceType rt)
        {
            if (rt.IsHasAttribute<ResourceTypeAccessActionAttribute>(out var attr))
                return attr.AccessActions;

            return new RoleActionType[]
            { 
                RoleActionType.Read, RoleActionType.Update, 
                RoleActionType.Create, RoleActionType.Delete 
            };
        }

        /// <summary>
        /// Проверяем возможность установки права ресурсу
        /// </summary>
        /// <param name="resourceObject">Ресурс</param>
        /// <param name="actionType">Права, которые хотим установить</param>
        /// <returns></returns>
        public static (bool IsAllowed, RoleActionType AllowedActionType) IsAllowedAction(this ResourceType resourceObject, RoleActionType actionType)
        {
            var right = resourceObject.GetAccessActions();
            var newRigthsCol = actionType.ToValues();

            if (right.Any() && actionType != RoleActionType.Forbidden)
            {
                var intersect = newRigthsCol.Intersect(right);
                if (intersect.Count() == newRigthsCol.Count())
                    return (true, actionType);
                else
                {
                    var outIntersect = newRigthsCol.Except(right);
                    return (false, outIntersect.ToCombined());
                }
            }
            return (true, right.ToCombined());
        }
    }
}
