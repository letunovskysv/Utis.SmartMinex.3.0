using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Utis.Minex.Common.Interfaces
{
    public interface ICatalogCache
    {
        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T GetEntity<T>(long id) where T : CatalogBase;

        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <param name="entityType">Тип сущности.</param>
        /// <returns>Сущность или null.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        CatalogBase GetEntity(long id, Type entityType);

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Cписок содержащий сущности или пустой список.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerable<T> GetAllEntities<T>() where T : CatalogBase;

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <param name="entityType">Тип сущности.</param>
        /// <returns>Список содержащий сущности или пустой список.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerable<CatalogBase> GetAllEntities(Type entityType);

        /// <summary>
        /// Содержатся ли сущности данного сипа в кэше.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IsContainsInCache(Type type);

        void Initialize(IRepositoryFactory repositoryFactory);

        void Start();

        void Stop();

        //TODO распутать ссылки и поменять тип аргумента на ObjectChangeEvent2
        /// <summary>
        /// Для оперативного обновления сущностей в кэше без отказа от рассылки событий об изменении в отдельной очереди
        /// </summary>
        /// <param name="objectChangeEvent2"></param>
        void OnObjectChangeEvent(object objectChangeEvent2);
    }
}