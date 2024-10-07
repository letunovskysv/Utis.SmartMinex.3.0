using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Delegate for notification change of proxy object
    /// </summary>
    /// <param name="tag">Tag</param>
    /// <param name="guidClient">guid клиента которому необходимо распространить тэги(если null - распространить всем)</param>
    public delegate void ProxyObjectChanged(List<ProxyTagAckable> tag, string guidClient = "");

    /// <summary>
    /// Менеджер событий реального времени
    /// </summary>
    public interface IProxyManager
    {
        event ProxyObjectChanged ProxyTagChanged;

        /// <summary>
        /// Получение значения тэга по идентифицирующим параметрам
        /// </summary>
        /// <param name="typeTag">Тип тэга</param>
        /// <param name="sourceType">тип источника тэга</param>
        /// <param name="sourceId">идентификатор источника тэга</param>
        /// <param name="value">значение тэга</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool TryGetTagValue(ProxyTagType typeTag, Type sourceType, long sourceId, out object value);

        /// <summary>
        /// Установить значения тэга события, для которого автоматически определяются идентифицирующие параметры (тип тэга в ProxyTagConverExtension, тип источника в ProxyTagTarget и идентификатор источника в ProxyTagName)
        /// </summary>
        /// <param name="typeTag">Тип тэга</param>
        /// <param name="value">значение для установки</param>
        /// <param name="toPublic">Распространить ли событие ProxyTagChanged</param>
        void AddOrUpdateTagValue(ObjectBase value, bool toPublic = false);

        /// <summary>
        /// Установить значения тэга по идентифицирующим параметрам
        /// </summary>
        /// <param name="typeTag">Тип тэга</param>
        /// <param name="sourceType">тип источника тэга</param>
        /// <param name="sourceId">идентификатор источника тэга</param>
        /// <param name="value">значение для установки</param>
        /// <param name="toPublic">Распространить ли событие ProxyTagChanged</param>
        void AddOrUpdateTagValue(ProxyTagType typeTag, long sourceId, Type sourceType, object value, bool toPublic = false);

        /// <summary>
        /// Активизация тегов выбранного типа
        /// </summary>
        /// <param name="type">тип тэга</param>
        /// <param name="guidClient">guid клиента которому необходимо распространить тэги</param>
        /// <param name="userRole"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Invoke(ProxyTagType proxyTagType, string guidClient, string userRole, string user);

        /// <summary>
        /// Обновить признак квитированности события с автоматическим определением его идентифицирующих параметров
        /// </summary>
        /// <param name="ackEvent">событие подтверждения</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool AckProxyEvent(object ackEvent, PriorityEventBase priorityEvent);

        /// <summary>
        /// Обновить признак квитированности события по его идентифицирующим параметрам
        /// </summary>
        /// <param name="typeTag">Тип тэга</param>
        /// <param name="sourceType">тип источника тэга</param>
        /// <param name="sourceId">идентификатор источника тэга</param>
        /// <param name="ackEvent">событие подтверждения</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool AckProxyEvent(ProxyTagType typeTag, long sourceId, Type sourceType, object ackEvent);

        /// <summary>
        /// Отправить на клиент
        /// </summary>
        /// <param name="typeTag">Тип тэга</param>
        /// <param name="value">значение для установки</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ProxyTagChangedInvoke(ProxyTagType typeTag, object value);

        Type[] GetPriorityTypes();

        bool ToProxyTagType(Type type, out ProxyTagType proxyTagType);
    }
}