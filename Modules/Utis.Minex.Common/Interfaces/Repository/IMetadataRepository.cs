using System;
using System.Linq;
using System.Linq.Expressions;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Репозиторий метаданных
    /// </summary>
    public interface IMetadataRepository 
    {
        /// <summary>
        /// Вставить новую сущность
        /// </summary>
        void Insert<T>(T entity) where T : ObjectBase;

        /// <summary>
        /// Сохранить или обновить сущность
        /// </summary>
        /// <returns>Обновлённая сущность</returns>
        T SaveOrUpdate<T>(T entity) where T : ObjectBase;

        /// <summary>
        /// Запрос к БД
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="query">выражение запроса</param>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> query) where T : ObjectBase;

        /// <summary>
        /// Получить сущность по Id
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="id">идентификатор сущности</param>
        T Query<T>(long id) where T : ObjectBase;

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="entity">сущность</param>
        void DeleteEntity<T>(ObjectBase entity) where T : ObjectBase;
        
        /// <summary>
        /// Получить фабрику сессий
        /// </summary>
        object SessionFactory { get; }

        Type GetEntityType(long id);

        /// <summary>
        /// Нужно инициализировать данные
        /// </summary>
        bool NeedInizializeMetadata { get; set; }
    }
}