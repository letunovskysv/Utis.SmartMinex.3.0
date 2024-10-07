using System;
using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Helpers
{
    public static class ResourceTypeExtensions
    {
        /// <summary>
        /// Получить ресурсы определенных категорий
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static IEnumerable<ResourceType> GetResourcesByCategory(params ResourceCategory[] categories)
        {
            if (categories?.Any() != true)
            {
                return Array.Empty<ResourceType>();
            }

            var enums = System.Enum.GetValues<ResourceType>();

            return enums
                    .Where(x => x.IsCategorized(out var categoryType) && categories.Contains(categoryType))
                    .ToArray();
        }

        /// <summary>
        /// Принадлежит ли ресурс категории
        /// </summary>
        /// <param name="rt"></param>
        /// <returns></returns>
        public static bool IsMatchResourceCategory(this ResourceType rt,
            ResourceCategory category = ResourceCategory.Any)
        {
            if (rt.IsCategorized(out var categoryLoc))
            {
                if (category == ResourceCategory.Any)
                    return true;
                else
                    return categoryLoc == category;
            }

            return false;
        }
    }
}
