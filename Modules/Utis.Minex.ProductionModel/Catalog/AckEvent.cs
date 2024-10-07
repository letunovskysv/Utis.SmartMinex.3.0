using System;

namespace Utis.Minex.ProductionModel.Catalog
{
    using Utis.Minex.Common;

    /// <summary>
    /// Получение клиентом и подтверждение пользователем события.
    /// </summary>
    [DisplayName("Получение и подтверждение события")]
    [Description("Получение клиентом и подтверждение пользователем события")]
    public class AckEvent : VersionObjectBase
    {
        /// <summary>
        /// IP-адрес компьютера.
        /// </summary>
        [DisplayName("IP-адрес компьютера")]
        [Description("IP-адрес компьютера")]
        public virtual string Ip4Address
        { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DisplayName("Пользователь")]
        [Description("Имя получившего и подтвердившего пользователя")]
        public virtual string Username
        { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        [DisplayName("Роль пользователя")]
        [Description("Роль получившего и подтвердившего пользователя")]
        public virtual string RoleName
        { get; set; }

        /// <summary>
        /// Тип исходного события.
        /// </summary>
        [DisplayName("Тип исходного события")]
        public virtual string EventType
        { get; set; }

        /// <summary>
        /// Описание исходного события.
        /// </summary>
        [DisplayName("Описание исходного события")]
        public virtual string EventDescription
        { get; set; }

        /// <summary>
        /// Идентификатор исходного события.
        /// </summary>
        [DisplayName("Идентификатор исходного события")]
        public virtual long EventPriorityId
        { get; set; }

        /// <summary>
        /// Имя типа исходного события
        /// </summary>
        [DisplayName("Имя типа исходного события")]
        public virtual string EventPriorityType
        { get; set; }

        /// <summary>
        /// Время получения события клиентом.
        /// </summary>
        [DisplayName("Время получения события клиентом")]
        public virtual DateTime ClientRecieved
        { get; set; }

        /// <summary>
        /// Время подтверждения события пользователем.
        /// </summary>
        [DisplayName("Время подтверждения события пользователем")]
        public virtual DateTime? ClientAck
        { get; set; }
    }
}