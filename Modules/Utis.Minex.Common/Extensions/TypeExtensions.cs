using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common
{ 
    public static class TypeExtensions
    {
        private class TypeComparer : IEqualityComparer<Type>
        {
            public bool Equals(Type x, Type y)
            {
                return x.Assembly == y.Assembly &&
                    x.Namespace == y.Namespace &&
                    x.Name == y.Name;
            }

            public int GetHashCode(Type obj)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Поиск метода
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public static MethodInfo GetGenericMethod(this Type type, string name, Type[] parameterTypes)
        {
            var methods = type.GetMethods();
            foreach (var method in methods.Where(m => m.Name == name))
            {
                var methodParameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();

                if (methodParameterTypes.SequenceEqual(parameterTypes, new TypeComparer()))
                {
                    return method;
                }
            }

            return null;
        }
    }
}
