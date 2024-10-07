using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Enums
{
    /// <summary>
    /// Тип колонки
    /// </summary>
    public enum SettingsType
    {
        /// <summary>
        /// Кастомный (Задается отдельной настройкой)
        /// </summary>
        Custom = -1,
        /// <summary>
        /// Базовый
        /// </summary>
        Default = 0,

        /// <summary>
        /// ComboBox
        /// </summary>
        Combo = 1,

        /// <summary>
        /// DateTime
        /// </summary>
        Date = 2,

        /// <summary>
        /// RefObject
        /// </summary>
        Reference = 3,

        /// <summary>
        /// Enum collection
        /// </summary>
        Collection = 4,

        /// <summary>
        /// Изображение
        /// </summary>
        Image = 5,

        /// <summary>
        /// Коллекция значений
        /// </summary>
        CollectionValues = 6,

        /// <summary>
        /// Изменения пропертей (для журналов изменения справочников)
        /// </summary>
        Changes = 7,

        /// <summary>
        /// Как Date, но показывается только время
        /// </summary>
        Time = 8,

        /// <summary>
        /// Интервал 1д. 2ч. 3м. 4с.
        /// </summary>
        TimeSpan,

        /// <summary>
        /// Объект БД
        /// </summary>
        IObjectBase = 9
    }
}
