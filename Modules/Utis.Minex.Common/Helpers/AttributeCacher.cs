using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Utis.Minex.Common.Helpers
{
    public static class AttributeCacher<T> where T : Attribute
    {
        static ConcurrentDictionary<Type, bool> _cache { get; } =
            new ConcurrentDictionary<Type, bool>();

        public static bool IsHasAttribute(Type type) 
            => _cache.GetOrAdd(type, type.GetCustomAttribute<T>() != null);
    }
}
