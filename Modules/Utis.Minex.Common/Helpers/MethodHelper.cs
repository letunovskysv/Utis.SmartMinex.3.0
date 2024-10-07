using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utis.Minex.Common.Helpers
{
    public static class MethodHelper
    {
        /// <summary>
        /// Получить метод
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name">имя метода</param>
        /// <param name="parametrTypes">типы параметров</param>
        /// <param name="genericArgumentTypes">типы агрументов</param>
        /// <returns>метод</returns>
        /// <remarks>При поиске метода с сигнатурой params в <param name="parametrTypes"></param>указывать нужно массив</remarks>
        public static MethodInfo GetGenericMethod(
            this Type type,
            string name,
            Type[] parametrTypes,
            Type[] genericArgumentTypes)
        {
            var methodInfos = new List<MethodInfo>();

            foreach (var method in type.GetMethods())
            {
                if (!method.ContainsGenericParameters
                    || method.Name != name
                    || method.GetGenericArguments().Length != genericArgumentTypes.Length
                    )
                {
                    continue;
                }

                var methodParametrs = method.GetParameters();

                if (methodParametrs.Length != parametrTypes.Length)
                {
                    continue;
                }

                int i = 0;
                bool notSameParametrType = false;
                foreach (var parametr in methodParametrs)
                {
                    if (parametr.ParameterType != parametrTypes[i])
                    {
                        notSameParametrType = true;
                    }

                    i++;
                }

                if(notSameParametrType)
                    continue;

                if (!IsAssignableArgement(method))
                {
                    continue;
                }


                methodInfos.Add(method.MakeGenericMethod(genericArgumentTypes));
            }

            if (!methodInfos.Any())
            {
                throw new Exception("Метод не найден");
            }

            if (methodInfos.Count > 1)
            {
                throw new AmbiguousMatchException("Обнаружено не однозначное соответствие");
            }

            return
                methodInfos.First();

            //Определить применимость аргументов к параметрам
            bool IsAssignableArgement(MethodInfo method)
            {
                int index = 0;
                foreach (var argument in method.GetGenericArguments())
                {
                    var genericArgumentType = genericArgumentTypes[index].IsAssignableFromRvalue()
                        ? typeof(RValueBase<>) //аргумент метода ничего не знает о конкретике
                        : genericArgumentTypes[index];

                    if (argument.BaseType != null && argument.BaseType.IsGenericType && !argument.BaseType
                            .GetGenericTypeDefinition().IsAssignableFrom(genericArgumentType))
                    {
                        return false;
                    }
                    else if (argument.BaseType != null && !argument.BaseType.IsGenericType &&
                             !argument.BaseType.IsAssignableFrom(genericArgumentType))
                    {
                        return false;
                    }

                    index++;
                }

                return true;
            }
        }
    }
}