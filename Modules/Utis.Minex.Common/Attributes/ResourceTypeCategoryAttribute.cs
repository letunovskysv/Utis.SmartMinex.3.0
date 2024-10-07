using System;
using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Attributes;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Attributes
{
    /// <summary>
    /// Аттрибут вкладки, для которой  <see cref="ResourceType"/> предназначен
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ResourceTypeCategoryAttribute : Attribute
    {
        public ResourceCategory Category { get; }

        public ResourceTypeCategoryAttribute(ResourceCategory category)
        {
            Category = category;
        }
    }
}

namespace Utis.Minex.Common
{
    public static class ResourceTypeCategoryAttributeHelper
    {
        /// <summary>
        /// Проверяем имеет ли ресурс категорию
        /// </summary>
        /// <param name="resourceObject">Ресурс</param>
        /// <returns></returns>
        public static bool IsCategorized(this ResourceType resourceObject, out ResourceCategory category)
        {
            category = ResourceCategory.CatalogsAndJournals;
            if (!resourceObject.IsHasAttribute<ResourceTypeCategoryAttribute>(out var categoryAttr))
                return false;

            category = categoryAttr.Category;
            return true;
        }
    }
}

