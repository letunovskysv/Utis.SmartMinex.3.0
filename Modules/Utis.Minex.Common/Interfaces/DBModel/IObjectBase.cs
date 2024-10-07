using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Utis.Minex.Common.Attributes;
using Utis.Minex.Common.Helpers;

namespace Utis.Minex.Common
{
    public static class ObjectBaseExt
    {
        /// <summary>
        /// Создать дубликат
        /// </summary>
        /// <returns></returns>
        public static T Clone<T>(this T obj) where T : IObjectBase
        {
            var type = obj.GetType();
            var typeInterface = type.GetParentInterface(typeof(IObjectBase));

            var clone = (T)Activator.CreateInstance(type);

            var props = typeInterface.GetPropertiesCust()
                .Where(x => x.CanRead & x.CanWrite)
                .ToArray(); 

            foreach (var prop in props)
            {
                var val = prop.GetValue(obj, null);
                prop.SetValue(clone, val);
            }
            return clone;
        }
    }


    /// <summary>
    /// Базовый элемент
    /// </summary>
    public interface IObjectBase : IDataErrorInfo, IComparable
    {
        bool IsNew => Id == default;
        /// <summary>
        /// Идентификатор объекта.
        /// </summary>
        [DisplayName("Идентификатор")]
        [Description("Уникальный идентификатор объекта")]
        long Id
        { get; set; }

        /// <summary>
        /// Метка удаления.
        /// </summary>        
        [DisplayName("Удалено")]
        [Description("Метка удаления объекта")]
        bool Deleted
        { get; set; }

        /// <summary>
        /// Дата/время создания объекта.
        /// </summary>
        [DisplayName("Создан")]
        [Description("Дата/время создания объекта")]
        DateTime? Created
        { get; set; }

        /// <summary>
        /// Дата/время изменения объекта.
        /// </summary>
        [DisplayName("Изменён")]
        [Description("Дата/время изменения объекта")]
        DateTime? Updated
        { get; set; }

        #region IComparable

        int IComparable.CompareTo(object? obj)
        {
            if (obj is not IObjectBase objBase || objBase.IsNew)
                return 1;

            return Id.CompareTo(objBase.Id);
        }

        #endregion IComparable

        #region IDataErrorInfo

        string IDataErrorInfo.Error => string.Empty;

        protected string ErrorByProps(params string[] properties)
        {
            var dataError = this as IDataErrorInfo;
            var errors = properties
                .Select(x=> dataError[x])
                .Where(x=> !string.IsNullOrEmpty(x));

            if (errors.Any())
                return string.Join(" ,", errors);
            else
                return string.Empty;
        }

        string IDataErrorInfo.this[string columnName] => string.Empty;

        #endregion IDataErrorInfo

        #region Equals

        public bool Equals(IObjectBase other)
        {
            if (this == other) return true;
            if (other == null) return false;

            var type = this.GetType().GetInterfaces().Last();
            var props = type.GetPropertiesCust()
                .Where(x => x.CanRead & x.CanWrite)
                .ToArray();

            bool isEquals = true;
            foreach (var prop in props)
            {
                var val1 = prop.GetValue(this, null);
                var val2 = prop.GetValue(other, null);

                if (val1 == null && val2 == null)
                    continue;

                bool locEquals = true;

                if (val1 is IEnumerable enum1 && val2 is IEnumerable enum2)
                {
                    locEquals = enum1.Cast<object>().SequenceEqual(enum2.Cast<object>());
                }
                else
                {
                    if (val1 is DateTime dt1 && val2 is DateTime dt2)
                        locEquals = DateTime.Equals(dt1, dt2);
                    else if (val1 is TimeSpan ts1 && val2 is TimeSpan ts2)
                        locEquals = TimeSpan.Equals(ts1, ts2);
                    else
                        locEquals = val1?.Equals(val2) ?? true;
                }

                if (!locEquals)
                {
                    isEquals = false;
                    break;
                }
            }

            return isEquals;
        }

        #endregion Equals
    }

    /// <summary>
    /// Элемент с версией
    /// </summary>
    public interface IVersionObjectBase : IObjectBase
    {
        /// <summary>
        /// Версия объекта.
        /// </summary>
        [DisplayName("Версия объекта")]
        [Description("Версия объекта")]
        [RegisterChangesIgnore(true)]
        long VersionObject { get; set; }
    }

    /// <summary>
    /// Журнал
    /// </summary>
    public interface IJournal : IVersionObjectBase
    {
        /// <summary>
        /// Дата/время записи.
        /// </summary>
        [DisplayName("Дата/время записи")]
        DateTime DateTime { get; set; }

        [EntityIninitialisation]
        void Init()
        {
            DateTime = DateTime.Now;
        }
    }

    /// <summary>
    /// Журнал с закрытием записи
    /// </summary>
    public interface IJournalClose : IJournal
    {
        /// <summary>
        /// Дата/время закрытия записи.
        /// </summary>
        [DisplayName("Дата/время закрытия записи")]
        DateTime? DateClose { get; set; }
    }

    /// <summary>
    /// Элемент каталога
    /// </summary>
    public interface ICatalog : IObjectNamed
    {

    }

    /// <summary>
    /// Именованный элемент
    /// </summary>
    public interface IObjectNamed : IVersionObjectBase
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        string Name { get; set; }
    }
}