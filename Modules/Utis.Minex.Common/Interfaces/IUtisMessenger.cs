using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Messages
{
    /// <summary>
    /// Мессенджер
    /// </summary>
    public interface IUtisMessenger
    {
        /// <summary>
        /// Опросить подписчиков
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемых объектов</typeparam>
        /// <param name="Topic">Имя топика</param>
        /// <param name="ActionSuccess">Действие при успешном запросе</param>
        /// <param name="ActionFaulted">Действие при исключении</param>
        Task RequestAsync<T>(string Topic, Action<IEnumerable<T>> ActionSuccess, Action<string> ActionFaulted = null);
        /// <summary>
        /// Отправить подписчикам
        /// </summary>
        /// <typeparam name="T">Тип отправляемых объектов</typeparam>
        /// <param name="Topic">Имя топика</param>
        /// <param name="Message">Сообщение</param>
        /// <param name="ActionSuccess">Действие при успешной отправке</param>
        /// <param name="ActionFaulted">Действие при исключении</param>
        Task SendAsync<T>(string Topic, T Message, Action ActionSuccess = null, Action<string> ActionFaulted = null);
        /// <summary>
        /// Подписаться на получение
        /// </summary>
        /// <typeparam name="T">Тип получаемых объектов</typeparam>
        /// <param name="Topic">Имя топика</param>
        /// <param name="SubscribeObject">Подписываемый объект</param>
        /// <param name="Action">Действие при получении</param>
        void Subscribe<T>(string Topic, object SubscribeObject, Action<T> Action);
        /// <summary>
        /// Подписаться на отправку
        /// </summary>
        /// <typeparam name="T">Тип отправляемых объектов</typeparam>
        /// <param name="Topic">Имя топика</param>
        /// <param name="SubscribeObject">Подписываемый объект</param>
        /// <param name="Action">Ответ</param>
        void Subscribe<T>(string Topic, object SubscribeObject, Func<T> Action);
        /// <summary>
        /// Отписать от подписок указанный объект
        /// </summary>
        /// <param name="Topic">Имя топика</param>
        /// <param name="SubscribeObject">Подписанный объект</param>
        void UnSubscribe(string Topic, object SubscribeObject);
        /// <summary>
        /// Отписать для всех объектов
        /// </summary>
        /// <param name="Topic">Имя топика</param>
        void UnSubscribe(string Topic);
    }
}
