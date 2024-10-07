using System;
using System.Collections.Generic;

namespace Utis.Minex.Common.Interfaces
{
    #region Using
    
    using Utis.Minex.Common.PropertyDelegate;
    using Utis.Minex.Common.QueryableWrapper;
    using Utis.Minex.Common.Interfaces.Repository;

        #endregion

    /// <summary>
    /// Содержит кэшированные делегаты
    /// </summary>
    public interface IReflectionCache
    {
        /// <summary>
        /// Проинициализировать известные заранее используемые делегаты.
        /// </summary>
        void InitializeCache();

        /// <summary>
        /// Проинициализировать кэш свойств типов телеметрии Proto.
        /// </summary>
        /// <param name="types"></param>
        void InitializeProtoCache(Type[] types);

        /// <summary>
        /// Проинициализировать делегаты расширений QueryOver.
        /// </summary>
        /// <param name="typeQueryOverExtensionClass"></param>
        void InitializeQueryOverCache(Type typeQueryOverExtensionClass);

        /// <summary>
        /// Получить свойства для типа модели.
        /// </summary>
        /// <param name="typeRootEntity">тип модели.</param>
        /// <param name="properties"></param>
        /// <returns>null если тип не содержится в кэше.</returns>
        bool GetPropertiesInModelClass(Type typeRootEntity, out HashSet<PropertyDelegates> properties);

        /// <summary>
        /// Получить свойства для типа прото ССД.
        /// </summary>
        /// <param name="typeRootEntity">тип прото.</param>
        /// <param name="properties"></param>
        /// <returns>null если тип не содержится в кэше.</returns>
        bool GetPropertiesInProtoTypes(Type typeRootEntity, out HashSet<PropertyDelegates> properties);

        /// <summary>
        /// Создать экземпляр.
        /// </summary>
        /// <param name="type">тип который требуется создать.</param>
        /// <param name="constructorTypeParametrs">типы параметров конструктора.</param>
        /// <param name="constructorParametrs">параметры конструктора.</param>
        /// <param name="addInCache"></param>
        /// <returns>экземпляр требуемого типа</returns>
        object CreateParametrisedConstructor(Type type, Type[] constructorTypeParametrs, object[] constructorParametrs, bool addInCache = true);

        /// <summary>
        /// Создать делегат создания типа.
        /// </summary>
        /// <param name="type">тип который требуется создать.</param>
        /// <param name="constructorTypeParametrs">типы параметров конструктора.</param>
        /// <param name="addInCache"></param>
        /// <returns>делегат создания типа.</returns>
        Func<object[], object> CreateFuncConstructor(Type type, Type[] constructorTypeParametrs, bool addInCache = true);

        /// <summary>
        /// Создать экземпляр по умолчанию.
        /// </summary>
        object CreateDefalut(Type type);

        /// <summary>
        /// Получить метод ToOnlyRefList расширение QueryOver для типа сущности.
        /// </summary>
        bool GetQueryOverExtensionMethod(Type typeEntity, out Func<object, object> method);

        /// <summary>
        /// Получить метод ToOnlyRefList конвертер расширение IList для типа сущности.
        /// </summary>
        bool GetRefOnlyConverterMethod(Type typeEntity, out Func<IList<object>, object> method);

        bool GetRefByIdMethod(Type typeEntity, out Func<IFastRepository, long, object> method);

        /// <summary>
        /// Может ли тип быть загружен из репозитория посредством WithRefOnlyNames расширения.
        /// </summary>
        bool CanBeLoadWithRefOnlyNames(Type typeEntity);

        /// <summary>
        /// Получить метод Queryable для типа сущности.
        /// </summary>
        QueryableWrapperBase GetQueryableMethod(Type typeEntity, string methodName, int parametrsCount);
    }
}