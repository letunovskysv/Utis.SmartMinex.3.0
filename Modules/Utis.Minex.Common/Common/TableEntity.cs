using System;

namespace Utis.Minex.Common
{    
    /// <summary>
    /// Хранение таблиц в бд и их уникальные id.
    /// </summary>
    [DisplayName("Объект БД")]
    [Description("Хранение таблиц в бд и их уникальные id")]
    public class TableEntity : ObjectBase
    {
        //[DisplayName("Идентификатор")]
        //[Description("Уникальный идентификатор объекта")]
        //public virtual long Id { get; set; }

        /// <summary>Type of entity</summary>
        [DisplayName("Тип")]
        public virtual string TypeEntity
        { get; set; }

        /// <summary>Table</summary>
        [DisplayName("Таблица")]
        public virtual string Table
        { get; set; }
    }
}
