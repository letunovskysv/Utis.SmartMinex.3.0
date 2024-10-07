using System;
using System.Runtime.CompilerServices;

namespace Utis.Minex.Common
{
    using Utis.Minex.Common.Interfaces.Repository;

    /// <summary>
    /// Фабрика репозиториев.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Получить репозиторий быстрых запросов (без Бизнесс логики).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IFastRepository GetFastRepository<T>([CallerFilePath] string nameOwner = "");

        /// <summary>
        /// Получить репозиторий быстрых запросов (без Бизнесс логики) по типу сущности.
        /// </summary>
        IFastRepository GetFastRepository(Type type, [CallerFilePath] string nameOwner = "");

        /// <summary>
        /// Получить репозиторий БД Production без бизнесс логики.
        /// </summary>
        IFastRepository GetProductionFastRepository([CallerFilePath] string nameOwner = "");

        /// <summary>
        /// Получить репозиторий БД Interaction без бизнесс логики.
        /// </summary>
        IFastRepository GetInteractionFastRepository([CallerFilePath] string nameOwner = "");

        /// <summary>
        /// Получить репозиторий БД DataAcquisition без бизнесс логики.
        /// </summary>
        IFastRepository GetDataAcquisitionFastRepository([CallerFilePath] string nameOwner = "");
    }
}