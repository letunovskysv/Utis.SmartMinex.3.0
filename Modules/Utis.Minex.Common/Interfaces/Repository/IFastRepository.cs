using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Utis.Minex.Common.Interfaces.Repository
{
    using System.Threading.Tasks;
    #region Using

    using Utis.Minex.Common.Enum;

        #endregion

    public interface IFastRepository : IBaseRepository { }

    public interface IBaseRepository: IDisposable, ICloneable
    {
        #region Session

        /// <summary>
        /// Открыть сессию
        /// </summary>
        /// <param name="toBeginTransaction">немендленно открыть транзакцию</param>
        /// <returns>сессия NHibenate</returns>
        SessionReleaser CreateSession(bool toBeginTransaction, int? timeOut = null);
        
        /// <summary>
        /// Текущая сессия
        /// </summary>
        ICustomSession Current { get; }



        #endregion

        #region Read

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById<T>(long id) where T : ObjectBase;

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="type">Type of entity</param>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        object GetById(Type type, long id);

        object GetByIdRefOnly(Type type, long id);

        T GetByIdRefOnly<T>(long id) where T : ObjectBase;

        /// <summary>
        /// Get identifiers by condition
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="query">Query condition</param>
        /// <returns>Collection of ientifiers</returns>
        IEnumerable<long> GetIds<T>(Expression<Func<T, bool>> query) where T : ObjectBase;

        /// <summary>
        /// Make query
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="query">Query condition</param>
        /// <returns>Result of query operation</returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> query = null) where T : ObjectBase;

        /// <summary> [LESEV] </summary>
        IQueryable<ObjectBase> Query(Type type, string where = null);

        /// <summary> [LESEV] </summary>
        Task<IQueryable<ObjectBase>> QueryAsync(Type type, string where = null);

        /// <summary>
        /// Формирует запросы на выборку только к корневой таблице(не грузит всю иерархию из БД)
        /// </summary>
        IQueryable<T> QueryRefOnly<T>() where T : ObjectBase;

        /// <summary>
        /// Получение данных из спецзапроса к БД
        /// </summary>
        IEnumerable<object> CustomQuery(CustomQueryType queryType, params string[] parametrs);

        /// <summary>
        /// Получение данных из спецзапроса к БД, с фильтрами
        /// </summary>
        IEnumerable<object> CustomQuery(CustomQueryType queryType, params Expression[] expressions);

        /// <summary>
        /// Получить последние события для каждого устройства с меткой
        /// </summary>
        IEnumerable<T> GetLastForMovementJournalByBegindDate<T>();
        
        /// <summary>
        /// Получить последние события для каждого устройства
        /// </summary>
        IEnumerable<T> GetLastForDeviceByDateTime<T>();
        
        /// <summary>
        /// Получить последние события для каждого устройства с меткой DeviceWithRfid
        /// </summary>
        IEnumerable<T> GetLastForDeviceWithRfidByDateTime<T>();

        /// <summary>
        /// Получить последние значения на указанную дату по выбранным устройствам
        /// </summary>
        /// <typeparam name="T">Тип журнала</typeparam>
        /// <param name="queryType">Тип запроса</param>
        /// <param name="dateTime">Максимальная дата последних значений</param>
        /// <param name="deviceIds">Идентификаторы устройств</param>
        /// <returns>Последние значения на указанную дату по выбранным устройствам</returns>
        IEnumerable<object> GetLastDateOutJournalValues(CustomQueryType queryType, DateTime dateTime, IEnumerable<long> deviceIds);

        /// <summary>
        /// Получить последние перемещения персонала для каждого определенного устройства и определенного времени (Tuple)
        /// </summary>
        /// <typeparam name="T">Тип журнала</typeparam>
        /// <param name="Tuple">Кортеж с Id индивидуального устройства и времени</param>
        /// <returns>Последние значения на указанную дату по выбранным устройствам</returns>
        IEnumerable<object> GetLastPersonMovmentsForEachDeviceDateTimeTuple(IEnumerable<Tuple<long, DateTime>> tuples);

        /// <summary>
        /// Получить мета данные по всем MimSchem из ветки, не запрашивает саму схему
        /// </summary>
        /// <returns>Возвращает коллекцию MimScheme в которых заполнены только поля 
        /// (Id, Created, Updated, Comments Changes)
        /// </returns>
        IEnumerable<object> GetMimSchemasByBranchOnId(long branchId);

        IEnumerable<T> GetLastValues<T>(Expression<Func<T, long>> groupKey, Expression<Func<T, bool>> valueQuery = null) where T : Journal;

        /// <summary>
        /// Кастомный запрос
        /// </summary>
        /// <returns></returns>
        public T CustomQuery<T>(string query) where T : VersionObjectBase;

        /// <summary>
        /// Кастомный запрос, возращающий список
        /// </summary>
        /// <returns></returns>
        public IList<T> CustomQueryList<T>(string query) where T : VersionObjectBase;

        /// <summary>
        /// Универсальный кастомный запрос
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="usingTypes">Используемые псевдоним-типы</param>
        /// <param name="parameters">Параметры</param>
        /// <returns></returns>
        dynamic CustomQuery(string query, IReadOnlyDictionary<string, Type> mappingEntities, IEnumerable<object> parameters = null);

        #endregion

        #region Add

        /// <summary>
        /// Вставка новой сущности
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="entity">сущность</param>
        /// <returns>сущность с обновлённым id</returns>
        T Add<T>(T entity, string clientId = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        /// <summary>
        /// Вставка новой сущности
        /// </summary>
        /// <typeparam name="T">тип сущности в списке</typeparam>
        /// <param name="entities">сущности</param>
        /// <returns>сущности с обновлёнными id</returns>
        IEnumerable<T> Add<T>(IEnumerable<T> entities, string clientId = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        #endregion

        #region Delete

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="entity">сущность</param>
        bool Delete<T>(T entity, bool sendToChangeAnalizer = true) where T : ObjectBase;

        /// <summary>
        /// Удалить сущности.
        /// </summary>
        /// <typeparam name="T">тип сущности в списке</typeparam>
        /// <param name="entities">сущности</param>
        bool Delete<T>(IEnumerable<T> entities, string clientId = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        #endregion

        #region Update

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="entity">сущность</param>
        /// <returns>обновлённая сущность</returns>
        /// <exception cref="StaleObjectStateException">При обновлении в репозиотрий если версия не найдена</exception>
        T Update<T>(T entity, string clientId = null, T oldEntity = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        /// <summary>
        /// Обновить сущности
        /// </summary>
        /// <typeparam name="T">тип сущности в списке</typeparam>
        /// <param name="entities">сущности</param>
        /// <returns>обновлённые сущности</returns>
        /// <exception cref="StaleObjectStateException">При обновлении в репозиотрий если версия не найдена</exception>
        IEnumerable<T> Update<T>(IEnumerable<T> entities, string clientId = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        /// <summary>
        /// Пометить сущность как удалённую(поле Deleted = true)
        /// </summary>
        /// <typeparam name="T">тип сущности</typeparam>
        /// <param name="entity">сущность</param>
        /// <returns>сущность с обновлённым Deleted</returns>
        T DeleteMark<T>(T entity, string clientId = null, T oldEntity = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        /// <summary>
        /// Пометить сущности как удалённые(поле Deleted = true)
        /// </summary>
        /// <typeparam name="T">тип сущности в списке</typeparam>
        /// <param name="entities">сущности</param>
        /// <returns>сущности с обновлёнными Deleted</returns>
        IEnumerable<T> DeleteMark<T>(IEnumerable<T> entities, string clientId = null, bool sendToChangeAnalizer = true) where T : ObjectBase;

        #endregion

        #region Set

        /// <summary>
        /// Обновить поле в бд.
        /// </summary>
        void Set<T>(
            T entity,
            Expression<Func<T, T>> setEntity,
            bool sendToChangeAnalizer = true
            ) where T : VersionObjectBase;

        #endregion

        #region ClearTable

        /// <summary>
        /// Удалить все записи из таблицы
        /// </summary>
        ///<remarks>Стоит помнить что удаление большого количества данных вызовет Vacuum</remarks>
        bool ClearTable<T>() where T : ObjectBase;

        /// <summary>
        /// Очистить таблицу полностью(не работает если на таблицу есть ссылки)
        /// </summary>
        /// <param name="timeout">0 будет ждать выполнения</param>
        void TruncateTable<T>(int? timeout = null) where T : ObjectBase;

        #endregion

        void Refresh<T>(T entity) where T : ObjectBase;

        bool CanBeLoadInRefOnly(Type type);

        #region GetShallowClone

        T GetShallowClone<T>(T entity) where T : ObjectBase;

        #endregion
    }
}