using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Utis.Minex.ProductionModel
{
    #region Using
    
    using Utis.Minex.Common;
    using Utis.Minex.Common.Enum;

        #endregion

    /// <summary>
    /// Запись о изменении статуса у события.
    /// </summary>
    [DisplayName("Запись о изменении статуса у события")]
    public class MapStatePriorityEventChangeHistory : CatalogBase
    {
        /// <summary>
        /// Данные пользователя.
        /// </summary>
        [DisplayName("Данные пользователя")]
        [Description("Данные пользователя")]
        public virtual UserData UserData
        { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DisplayName("Логин")]
        public virtual string UserName
        { get; set; }

        /// <summary>
        /// ФИО cотрудника.
        /// </summary>
        [DisplayName("ФИО cотрудника")]
        public virtual string PersonFullName
        { get; set; }


        /// <summary>
        /// Запись сопоставления событий.
        /// </summary>
        [DisplayName("Запись сопоставления событий")]
        public virtual MapStatePriorityEvent MapStatePriorityEvent
        { get; set; }

        /// <summary>
        /// Наименование типа события (Например MethaneLevel - Значение метана).
        /// </summary>
        [DisplayName("Наименование типа события")]
        public virtual string TFirst
        { get; set; }

        /// <summary>
        /// Наименование типа статуса события (т.е. StateEvent).
        /// </summary>
        [DisplayName("Наименование типа статуса события")]
        public virtual string TSecond
        { get; set; }

        /// <summary>
        /// Перечень значений события 
        /// (Например NormaMPC/ExcessMPC/ExcessMPC == Норма ПДК/Повышенный уровень ПДК/Превышение ПДК).
        /// </summary>
        [DisplayName("Перечень значений события")]
        public virtual IEnumerable<string> MapKeys
        { get; set; }

        /// <summary>
        /// Перечень статусов события
        /// (Например Default/Notification/Alarm == По умолчанию/Уведомление/Тревога).
        /// </summary>
        [DisplayName("Перечень статусов события")]
        public virtual IEnumerable<string> MapValues
        { get; set; }


        /// <summary>
        /// Дата/время внесения изменений.
        /// </summary>
        [DisplayName("Дата/время внесения изменений")]
        [Description("Дата/время внесения изменений")]
        public virtual DateTime? BeginDate
        { get; set; }

        /// <summary>
        /// Дата/время окончания актуальности изменений.
        /// </summary>
        [DisplayName("Дата/время окончания актуальности изменений")]
        [Description("Дата/время окончания актуальности изменений")]
        public virtual DateTime? EndDate
        { get; set; }
    }
}