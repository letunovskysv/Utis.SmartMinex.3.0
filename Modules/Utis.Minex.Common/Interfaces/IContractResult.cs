using System;
using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common.Interfaces
{
    /// <summary>
    /// Результат выполнения запроса коллекцией
    /// </summary>
    internal class ContractCollResult<T> : ContractResult, IContractObjResult, IContractCollResult<T>
    {
        IEnumerable<T> _result = Array.Empty<T>();

        /// <summary>
        /// Результат выполнения.
        /// </summary>
        public IEnumerable<T> Result
        {
            get => _result;
            set
            {
                _result = value ?? Array.Empty<T>();
            }
        }

        object IContractObjResult.Result
        {
            get => Result;
            set => Result = value as IEnumerable<T>;
        }
    }

    /// <summary>
    /// Результат выполнения запроса
    /// </summary>
    internal class ContractResult<T> : ContractResult, IContractObjResult, IContractResult<T>
    {
        /// <summary>
        /// Результат выполнения.
        /// </summary>
        public T Result
        { get; set; } = default(T);

        object IContractObjResult.Result
        {
            get => (object)Result;
            set => Result = (T)value;
        }
    }



    /// <summary>
    /// Результат выполнения запроса
    /// </summary>
    internal class ContractResult : IContractResult
    {
        /// <summary>
        /// Статус выполнения.
        /// </summary>
        public StateContract State
        { get; set; }

        /// <summary>
        /// Детали ошибки или пояснение статуса.
        /// </summary>
        public IEnumerable<string> StateMessages
        { get; set; }
    }

    /// <summary>
    /// Результат выполнения запроса с коллекцией
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContractCollResult<T> : IContractResult
    {
        /// <summary>
        /// Результат выполнения.
        /// </summary>
        public IEnumerable<T> Result
        { get; set; }

        /// <summary>
        /// Контракт пользовательский
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractCollResult<T> Create(IEnumerable<T> result, StateContract state, params string[] messages)
        {
            return new ContractCollResult<T>()
            {
                Result = result,
                State = state,
                StateMessages = messages ?? Enumerable.Empty<string>()
            };
        }

        /// <summary>
        /// Контракт с неверным запросом
        /// </summary>
        /// <param name="messages">Сообщение</param>
        /// <returns></returns>
        public new static IContractCollResult<T> CreateBadRequest(params string[] messages)
        {
            return IContractCollResult<T>.Create(default, StateContract.BadRequest, messages);
        }

        /// <summary>
        /// Контракт с успешным статусом
        /// </summary>
        /// <param name="result">Данные</param>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractCollResult<T> CreateSuccess(IEnumerable<T> result, params string[] messages)
        {
            return IContractCollResult<T>.Create(result, StateContract.Ok, messages);
        }
        /// <summary>
        /// Контракт сошибкой на сервере
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractCollResult<T> CreateServerError(params string[] messages)
        {
            return IContractCollResult<T>.Create(default, StateContract.ServerError, messages);
        }
        /// <summary>
        /// Контракт с отменой
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractCollResult<T> CreateCancel(params string[] messages)
        {
            return IContractCollResult<T>.Create(default, StateContract.Canceled, messages);
        }

        /// <summary>
        /// Контракт с ошибкой валидации
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractCollResult<T> CreateValidationError(params string[] messages)
        {
            return IContractCollResult<T>.Create(default, StateContract.ValidationError, messages);
        }

        /// <summary>
        /// Конвертировать контракт с динамическими объектами в типизированный контракт
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public IContractCollResult<TValue> ConvertDynamicToTypedContractColl<TValue>()
        {
            if (!typeof(IDynamicObject).IsAssignableFrom(typeof(T)))
                throw new Exception("Данный контракт не содержит динамические объекты");

            var castItems = Result?
                .Cast<IDynamicObject>()
                .Select(x => x.GetValueByType<TValue>(true))
                .ToArray() ?? Array.Empty<TValue>();

            var newContract = IContractCollResult<TValue>
                .Create(castItems, State, StateMessages.ToArray());

            return newContract;
        }

        /// <summary>
        /// Конвертировать в типизированный контракт
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public IContractCollResult<TValue> ConvertTo<TValue>()
        {
            var castItems = Result.OfType<TValue>();

            if (castItems.Count() != Result.Count())
                throw new Exception($"Контракт не может быть приведен к типу {typeof(TValue).Name}");

            var newContract = IContractCollResult<TValue>
                .Create(castItems, State, StateMessages.ToArray());

            return newContract;
        }
    }

    /// <summary>
    /// Результат запроса
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContractResult<T> : IContractResult
    {
        /// <summary>
        /// Результат
        /// </summary>
        T Result{ get; set; }

        /// <summary>
        /// Контракт пользовательский
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult<T> Create(T result, StateContract state, params string[] messages)
        {
            return new ContractResult<T>()
            {
                Result = result,
                State = state,
                StateMessages = messages ?? Enumerable.Empty<string>()
            };
        }

        /// <summary>
        /// Контракт с неверным запросом
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractResult<T> CreateBadRequest(params string[] messages)
        {
            return IContractResult<T>.Create(default, StateContract.BadRequest, messages);
        }

        /// <summary>
        /// Контракт с успешным статусом
        /// </summary>
        /// <param name="result">Данные</param>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult<T> CreateSuccess(T result, params string[] messages)
        {
            return IContractResult<T>.Create(result, StateContract.Ok, messages);
        }
        /// <summary>
        /// Контракт сошибкой на сервере
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractResult<T> CreateServerError(params string[] messages)
        {
            return IContractResult<T>.Create(default, StateContract.ServerError, messages);
        }
        /// <summary>
        /// Контракт с отменой
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractResult<T> CreateCancel(params string[] messages)
        {
            return IContractResult<T>.Create(default, StateContract.Canceled, messages);
        }

        /// <summary>
        /// Контракт с ошибкой валидации
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public new static IContractResult<T> CreateValidationError(params string[] messages)
        {
            return IContractResult<T>.Create(default, StateContract.ValidationError, messages);
        }


        /// <summary>
        /// Конвертировать в типизированный контракт
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public IContractResult<TValue> ConvertTo<TValue>()
            where TValue : IObjectBase
        {
            if (Result is not TValue value)
                throw new Exception($"Контракт не может быть приведен к типу {typeof(TValue).Name}");

            var newContract = IContractResult<TValue>
                .Create(value, State, StateMessages.ToArray());

            return newContract;
        }
    }

    public static class ContractResultExtensions
    {
        /// <summary>
        /// Кинуть исключение если не ОК
        /// </summary>
        /// <param name="contractResult"></param>
        /// <exception cref="Exception"></exception>
        public static void ThrowOnNotOkResult(this IContractResult contractResult)
        {
            if (contractResult.State != StateContract.Ok)
                throw new Exception(contractResult.StateMessages?.FirstOrDefault());
        }
    }

    public interface IContractObjResult : IContractResult
    {
        object Result
        { get; set; }

        static IContractObjResult Create(Type dto, StateContract stateContract, IEnumerable<string> stateMessages, object result)
        {
            var typeCR = typeof(ContractResult<>).MakeGenericType(dto);
            var contract = (IContractObjResult)Activator.CreateInstance(typeCR);//TODO закэшировать делегаты
            contract.State = stateContract;
            contract.StateMessages = stateMessages ?? Enumerable.Empty<string>();
            contract.Result = result;

            return contract;
        }
    }

    /// <summary>
    /// Результат запроса
    /// </summary>
    public interface IContractResult
    {
        /// <summary>
        /// Статус выполнения.
        /// </summary>
        StateContract State
        { get; set; }

        /// <summary>
        /// Детали ошибки или пояснение статуса.
        /// </summary>
        IEnumerable<string> StateMessages
        { get; set; }

        /// <summary>
        /// Успешность выполненения контракта
        /// </summary>
        bool IsOk => State == StateContract.Ok;

        /// <summary>
        /// Детали ошибки или пояснение статуса, объединенные в строку
        /// </summary>
        string JoinedMessage => StateMessages?.Any() ?? false ?
            string.Join(", ", StateMessages) : string.Empty;

        /// <summary>
        /// Контракт пользовательский
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult Create(StateContract state, params string[] messages)
        {
            return new ContractResult()
            {
                State = state,
                StateMessages = messages ?? Enumerable.Empty<string>()
            };
        }

        /// <summary>
        /// Контракт с неверным запросом
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult CreateBadRequest(params string[] messages)
        {
            return IContractResult.Create(StateContract.BadRequest, messages);
        }

        /// <summary>
        /// Контракт с успешным статусом
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult CreateSuccess(params string[] messages)
        {
            return IContractResult.Create(StateContract.Ok, messages);
        }
        /// <summary>
        /// Контракт с отменой
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult CreateCancel(params string[] messages)
        {
            return IContractResult.Create(StateContract.Canceled, messages);
        }
        /// <summary>
        /// Контракт с ошибкой на сервере
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult CreateServerError(params string[] messages)
        {
            return IContractResult.Create(StateContract.ServerError, messages);
        }
        /// <summary>
        /// Контракт с ошибкой валидации
        /// </summary>
        /// <param name="messages">Сообщения</param>
        /// <returns></returns>
        public static IContractResult CreateValidationError(params string[] messages)
        {
            return IContractResult.Create(StateContract.ValidationError, messages);
        }
    }
}