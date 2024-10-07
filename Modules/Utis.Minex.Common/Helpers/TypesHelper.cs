using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Utis.Minex.Common.Synchronization;

namespace Utis.Minex.Common.Helpers
{
    /// <summary>
    /// Содержит все типы из всех сборок.
    /// </summary>
    public static class TypesHelper
    {
        private static readonly Dictionary<Type, Type> _mappingInterfaceTypes = new();
        private static readonly Dictionary<string, Type> _possibleTypes = new();
        private static readonly ISyncSlim<Dictionary<Type, PropertyInfo[]>> _cashePoperties =
            ISyncSlim<Dictionary<Type, PropertyInfo[]>>.Create();

        private static readonly ISyncSlim<Dictionary<Type, MethodInfo[]>> _casheMethods =
    ISyncSlim<Dictionary<Type, MethodInfo[]>>.Create();

        /// <summary>Коллекция типов</summary>
        public static Type[] Types;

        /// <summary>Конструктор</summary>
        static TypesHelper()
        {
            AddTypes();
        }

        public static void StubInit()
        {
            return;
        }

        /// <summary>
        /// Найти родительский интерфейс
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseInterface">Базовый тип искомого интерфейса</param>
        /// <returns></returns>
        public static Type GetParentInterface(this Type type, Type baseInterface)
        {
            var interfaces = type.GetInterfaces()
             .Where(x => baseInterface.IsAssignableFrom(x))
             .OrderBy(x => x.GetInterfaces()
                .Where(x2 => baseInterface.IsAssignableFrom(x2)).Count()
             );

            var mainInterface = interfaces.LastOrDefault();

            // Проверка пока не все сущности имеют интерфейсы
            if (mainInterface != null && baseInterface == typeof(IObjectBase) && type.IsClass)
            {
                if (!mainInterface.Name.Contains(type.Name.RemoveDTO()))
                {
                    return null;
                }
            }

            return mainInterface;
        }

        /// <summary>
        /// Создать список по типу элемента
        /// </summary>
        /// <param name="elementType">Тип элемента</param>
        /// <returns></returns>
        public static IList CreateListByElementType(this Type elementType)
        {
            var listType = typeof(List<>).MakeGenericType(elementType);
            return Activator.CreateInstance(listType) as IList;
        }

        /// <summary>
        /// Является ли тип структурой
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsPrimitive;
        }

        /// <summary>
        /// Найти свойство с учетом интерфейсов
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyCust(this Type type, string propertyName)
        {
            var props = GetPropertiesCust(type);

            return props
                .FirstOrDefault(x => x.Name.Equals(propertyName));
        }

        /// <summary>
        /// Найти свойства с учетом интерфейсов
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertiesCust(this Type type)
        {
            PropertyInfo[] props;
            bool isExist = false;

            using (_cashePoperties.Read(out var cache))
            {
                isExist = cache.TryGetValue(type, out props);
            }

            if (!isExist)
            {
                if (type.IsInterface)
                {
                    props = type
                        .GetInterfaces()
                        .Concat(new Type[] { type })
                        .SelectMany(x => x.GetProperties())
                        .ToArray();
                }
                else
                {
                    props = type.GetProperties();
                }

                using (_cashePoperties.Write(out var cache))
                {
                    cache.Add(type, props);
                }
            }

            return props;
        }

        /// <summary>
        /// Найти методы с учетом интерфейсов
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethodsCust(this Type type)
        {
            MethodInfo[] props;
            bool isExist = false;

            using (_casheMethods.Read(out var cache))
            {
                isExist = cache.TryGetValue(type, out props);
            }

            if (!isExist)
            {
                if (type.IsInterface)
                {
                    props = type
                        .GetInterfaces()
                        .Concat(new Type[] { type })
                        .SelectMany(x => x.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                        .Where(x=> !x.IsSpecialName)
                        .ToArray();
                }
                else
                {
                    props = type.GetMethods();
                }

                using (_casheMethods.Write(out var cache))
                {
                    cache.Add(type, props);
                }
            }

            return props;
        }

        /// <summary>
        /// Добавление типов
        /// </summary>
        private static void AddTypes()
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var files = System.IO.Directory.GetFiles(folder, "*.dll");

            var tempList = new List<Type>();
            foreach (var file in files)
            {
                //Bad IL format. The format of the file ...

                if (file.Contains("sni.dll")) continue;
                if (file.Contains("clretwrc.dll")) continue;
                if (file.Contains("clrjit.dll")) continue;
                if (file.Contains("coreclr.dll")) continue;
                if (file.Contains("msquic.dll")) continue;
                if (file.Contains("mscorrc.dll")) continue;
                if (file.Contains("mscordbi.dll")) continue;
                if (file.Contains("ucrtbase.dll")) continue;
                if (file.Contains("hostfxr.dll")) continue;
                if (file.Contains("hostpolicy.dll")) continue;
                if (file.Contains("clrcompression.dll")) continue;
                if (file.Contains("dbgshim.dll")) continue;
                if (file.Contains("grpc_csharp_ext.x64.dll")) continue;
                if (file.Contains("System.Private.CoreLib.dll")) continue;

                if (file.Contains("_cor3.dll")) continue;
                if (file.Contains(".Native.dll")) continue;

                if (file.Contains("api-ms-win")) continue;
                if (file.Contains("Microsoft.")) continue;
                if (file.Contains("mscordaccore")) continue;
                if (file.Contains("apidsp_windows")) continue;
                if (file.Contains("haspvlib")) continue;
                if (file.Contains("haspdnert")) continue;
                if (file.Contains("hasp_net_")) continue;
                if (file.Contains("hasp_windows_")) continue;

                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                    if (!assembly.FullName.Contains(Constants.UTIS_NAMESPACE_PERFIX))//из-за Utis.Platform а так вообще Constants.MAIN_NAMESPACE_PREFIX
                    {
                        continue;
                    }

                    foreach (var type in assembly.GetTypes())
                    {
                        tempList.Add(type);

                        if(type.IsAbstract && !type.IsInterface && type.Name.Contains("DTO"))
                        {
                            var interType = type.GetParentInterface(typeof(IObjectBase));
                            if (interType != null && type.Name.Contains(interType.Name.Remove(0, 1)))
                            {
                                _mappingInterfaceTypes.TryAdd(interType, type);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            Types = tempList.ToArray();

            foreach (var type in Types)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(type.FullName))
                    {
                        if (!_possibleTypes.ContainsKey(type.FullName))
                        {
                            _possibleTypes.Add(type.FullName, type);

                            var parentInterf = type.GetParentInterface(typeof(IObjectBase));
                            if (parentInterf != null)
                            {
                                _possibleTypes.TryAdd(parentInterf.FullName, type);
                            }
                        }
                        else
                        {
                            Debug.WriteLine($"An item with the same key has already been added. Key:[{type.FullName}]");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"TypesHelper::Exception::AddTypes::[{type.FullName}]");
                    Debug.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Получить тип по полному имени типа
        /// </summary>
        /// <param name="fullName">полное имя типа</param>
        /// <param name="findType">найденый тип</param>
        /// <returns>false если соответствие не изветсно</returns>
        public static bool TryGetTypeDtoByFullName(this string fullName, out Type findType)
        {
            return _possibleTypes.TryGetValue(fullName, out findType);
        }

        /// <summary>
        /// Получить тип по имени типа
        /// </summary>
        /// <param name="name">имя типа</param>
        /// <returns>Type если нашли, иначе null</returns>
        public static Type TryGetTypeDtoByName(this string name)
        {
            return _possibleTypes.FirstOrDefault(x => x.Value.Name == name).Value;
        }

        /// <summary>
        /// Получить тип по полному имени интерфейса
        /// </summary>
        /// <param name="fullName">полное имя типа</param>
        /// <param name="findType">найденый тип</param>
        /// <returns>false если соответствие не изветсно</returns>
        public static Type TryGetInstanceType(this Type type)
        {
            if (type.IsClass)
                return type;
            if (_mappingInterfaceTypes.TryGetValue(type, out var instanceType))
                return instanceType;

            return null;
        }
        public static HashSet<Type> GetSubClusses(Type fromType)
        {
            return Types.Where(wh => (fromType.IsAssignableFrom(wh))
                                    && wh.Namespace.StartsWith(Constants.PROD_MODEL_NAMESPACE))
                   .ToHashSet();
        }

        /// <summary>
        /// Проверка на связь типов
        /// </summary>
        /// <param name="givenType">Проверяемый тип</param>
        /// <param name="genericType">Базовый тип</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            var baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }

        /// <summary>
        /// Get register pair (dimension-value)
        /// </summary>
        /// <param name="registerType">Register type</param>
        public static Type GetRegisterPairType(Type registerType)
        {
            var basetype = registerType.IsAssignableFromRvalue() ? 
                typeof(RDimensionBase) :
                registerType.GetRvalueType();

            var name = registerType.IsAssignableFromRvalue() ? 
                registerType.Name.Replace(Constants.REGISTER_VALUE_POSTFIX,     Constants.REGISTER_DIMENSION_POSTFIX) : 
                registerType.Name.Replace(Constants.REGISTER_DIMENSION_POSTFIX, Constants.REGISTER_VALUE_POSTFIX);

            return Types.FirstOrDefault(x => basetype.IsAssignableFrom(x) && x.Name.EqualsInsensitive(name));
        }

        public static IEnumerable<Type> GetTypesWithAttribute(Type attributeType)
        {
            foreach(Type type in _possibleTypes.Values) {
            if (type.GetCustomAttributes(attributeType, true).Length > 0) {
                yield return type;
                }
            }
        }

        /// <summary>
        /// Определить является ли тип наследником от RValue
        /// </summary>
        /// <param name="entityType">тип</param>
        /// <returns>результат определения</returns>
        public static bool IsAssignableFromRvalue(this Type entityType)
        {
            if (entityType.BaseType == null || !entityType.BaseType.GenericTypeArguments.Any())
            {
                return false;
            }

            Type genparam = entityType.BaseType.GenericTypeArguments.First();

            if (!typeof(RDimensionBase).IsAssignableFrom(genparam))
            {
                return false;
            }

            var type = typeof(RValueBase<>).MakeGenericType(genparam);
            return
                type.IsAssignableFrom(entityType);
        }

        /// <summary>
        /// Получить тип RValue
        /// </summary>
        /// <param name="entityType">тип</param>
        /// <returns>результат определения</returns>
        /// Возможен возврат null если тип не RValue
        public static Type GetRvalueType(this Type entityType)
        {
            if (entityType.BaseType == null || !entityType.BaseType.GenericTypeArguments.Any())
            {
                return null;
            }

            Type genparam = entityType.BaseType.GenericTypeArguments[0];

            if (!typeof(RDimensionBase).IsAssignableFrom(genparam))
            {
                return null;
            }


            return
                typeof(RValueBase<>).MakeGenericType(genparam);
        }

        /// <summary>
        /// Типы регистра, связывающего два каталога
        /// </summary>
        public class RegisterBindTypes
        {
            /// <summary>
            /// Возвращает типы регистров, которые реализуют связку двух каталогов
            /// </summary>
            public static List<RegisterBindTypes> GetAll { get; } = new List<RegisterBindTypes>
            {
                new RegisterBindTypes("RFUnitDTO",              "AnchorHittingRDimensionDTO",           "AnchorHittingRValueDTO",       "MobileRegDeviceDTO"),
                new RegisterBindTypes("MobileRegDeviceDTO",     "EquipmentDeviceBindRDimensionDTO",     "EquipmentDeviceBindRValueDTO", "EquipmentDTO"      ),
                new RegisterBindTypes("IndividualDeviceDTO",    "IndividualDeviceBindRDimensionDTO",    "IndividualDeviceBindRValueDTO","PersonDTO"         ),
                new RegisterBindTypes("LampDTO",                "LampDeviceBindRDimensionDTO",          "LampDeviceBindRValueDTO",      "RFUnitDTO"         ),
                new RegisterBindTypes("PersonDTO",              "PersonCardBindRDimensionDTO",          "PersonCardBindRValueDTO",      "PersonalCardDTO"   ),
            };

            private RegisterBindTypes(string tDimensionObject, string tDimension, string tValue, string tValueObject)
            {
                TDimensionObject = Types.FirstOrDefault(x => x.Name.Equals(tDimensionObject));
                TDimension       = Types.FirstOrDefault(x => x.Name.Equals(tDimension));
                TValue           = Types.FirstOrDefault(x => x.Name.Equals(tValue));
                TValueObject     = Types.FirstOrDefault(x => x.Name.Equals(tValueObject));
            }

            /// <summary>
            /// Тип среза
            /// </summary>
            public Type TDimension { get; }

            /// <summary>
            /// Тип значения
            /// </summary>
            public Type TValue { get; }

            /// <summary>
            /// Тип каталога, на который ссылается срез
            /// </summary>
            public Type TDimensionObject { get; }

            /// <summary>
            /// Тип каталога, на который ссылается значение
            /// </summary>
            public Type TValueObject { get; }
        }
    }
}