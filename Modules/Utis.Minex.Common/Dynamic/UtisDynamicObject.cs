using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Utis.Minex.Common.Helpers;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Динамический объект
    /// </summary>
    public interface IDynamicObject
    {
        /// <summary>
        /// Свойство - идентификатор объекта
        /// </summary>
        string IdNameProperty { get; }
        /// <summary>
        /// Является идентифицируемым
        /// </summary>
        bool IsIdentity { get; }

        /// <summary>
        /// Создать пустой объект
        /// </summary>
        static IDynamicObject Create() => new UtisDynamicObject();

        /// <summary>
        /// Создать объект с вычисляемым идентификатором
        /// </summary>
        /// <param name="idNameProperty"></param>
        /// <exception cref="ArgumentNullException"></exception>
        static IDynamicObject Create(string idNameProperty)
            => new UtisDynamicObject(idNameProperty);

        /// <summary>
        /// Создать объект со значениями
        /// </summary>
        static IDynamicObject Create(IDictionary<string, dynamic> values)
        {
            var obj = Create();
            if (values != default && values.Any())
            {
                foreach (var vaue in values)
                {
                    obj.SetValue(vaue.Key, vaue.Value);
                }
            }

            return obj;
        }

        #region Methods

        /// <summary>
        /// Назначить свойство - идентификатор
        /// </summary>
        /// <param name="idNameProperty"></param>
        void SetIdNameProperty(string idNameProperty);

        /// <summary>
        /// Копировать в другой <see cref="IDynamicObject"/>
        /// </summary>
        /// <param name="dynObj">Объект для заполнения</param>
        void CopyTo(IDynamicObject dynObj);

        /// <summary>
        /// Очистить
        /// </summary>
        void Clear();

        /// <summary>
        /// Получить все свойства
        /// </summary>
        /// <returns></returns>
        IDictionary<string, dynamic> GetProperties();

        /// <summary>
        /// Установить значение (для анонимной записи привести к dynamic: ((dynamic)IDynamicObject).MyProperty = ...)
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        void SetValue(string propertyName, object value);

        /// <summary>
        /// Найти значение по типу
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isInherited">true - учитывать наследование</param>
        /// <returns></returns>
        dynamic GetValueByType(Type type, bool isInherited = false);

        /// <summary>
        /// Найти значение по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isInherited">true - учитывать наследование</param>
        /// <returns></returns>
        T GetValueByType<T>(bool isInherited = false);

        /// <summary>
        /// Получить значение (для анонимного чтения привести к dynamic: var value = ((dynamic)IDynamicObject).MyProperty)
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        dynamic GetValue(string propertyName);

        /// <summary>
        /// Получить тип свойства
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Type GetPropertyType(string propertyName);

        #endregion
    }


    /// <summary>
    /// Динамический объект
    /// </summary>
    class UtisDynamicObject : DynamicObject, INotifyPropertyChanged,
        IDynamicObject
    {
        #region Properties/Fields

        /// <summary>
        /// Свойство - идентификатор
        /// </summary>
        public const string Id = "id_obj";

        public string IdNameProperty { get; private set; }

        public bool IsIdentity => !string.IsNullOrEmpty(IdNameProperty);

        /// <summary>
        /// Метаданные свойств
        /// </summary>
        private static readonly IDictionary<string, PropertyInfo> _metaData;

        /// <summary>
        /// Свойства текущего объекта
        /// </summary>
        internal Dictionary<string, dynamic> Properties;

        #endregion Properties/Fields

        #region Constructor

        static UtisDynamicObject()
        {
            _metaData = new Dictionary<string, PropertyInfo>();
        }

        /// <summary>
        /// Создать пустой объект
        /// </summary>
        public UtisDynamicObject()
        {
            Properties = new Dictionary<string, dynamic>();
        }

        /// <summary>
        /// Создать объект с вычисляемым идентификатором
        /// </summary>
        /// <param name="idNameProperty"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UtisDynamicObject(string idNameProperty)
            : this()
        {
            if (string.IsNullOrEmpty(idNameProperty))
                throw new ArgumentNullException(nameof(idNameProperty));

            IdNameProperty = idNameProperty;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Назначить свойство - идентификатор
        /// </summary>
        /// <param name="idNameProperty"></param>
        public void SetIdNameProperty(string idNameProperty)
        {
            IdNameProperty = idNameProperty;
        }

        /// <summary>
        /// Копировать в другой <see cref="IDynamicObject"/>
        /// </summary>
        /// <param name="dynObj">Объект для заполнения</param>
        public void CopyTo(IDynamicObject dynObj)
        {
            if (dynObj is not UtisDynamicObject utisObj)
                return;

            utisObj.Properties = Properties;
        }

        /// <summary>
        /// Очистить
        /// </summary>
        public void Clear()
        {
            Properties.Clear();
        }

        /// <summary>
        /// Получить все свойства
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, dynamic> GetProperties()
        {
            return Properties.ToDictionary(x => x.Key, v => v.Value);
        }

        /// <summary>
        /// Установить значение (для анонимной записи привести к dynamic: ((dynamic)IDynamicObject).MyProperty = ...)
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public virtual void SetValue(string propertyName, object value)
        {
            propertyName = propertyName.ToLower();

            if (propertyName == Id)
                throw new Exception($"Имя {Id} зарезервировано и не может использоваться");

            if (Properties.ContainsKey(propertyName))
            {
                Properties[propertyName] = value;
            }
            else
                Properties.Add(propertyName, value);

            OnPropertyChanged(propertyName);
        }

        public dynamic GetValueByType(Type type, bool isInherited = false)
        {
            var notNullProps = Properties.Values
                     .Where(x => x != null)
                     .Select(x => new { Type = x.GetType(), Value = x });

            if (!isInherited)
            {
                notNullProps = notNullProps
                     .Where(x => x.Type == type);
            } else
            {
                notNullProps = notNullProps
                 .Where(x => x.Type == type || type.IsAssignableFrom(x.Type));
            }

            var value = notNullProps.FirstOrDefault()?.Value;
            return value;
        }

        public T GetValueByType<T>(bool isInherited = false)
        {
            if (isInherited)
            {
                return Properties.Values
                     .Where(x => x?.GetType()?.IsAssignableTo(typeof(T)) ?? false)
                     .FirstOrDefault();
            }
            else
            {
                return Properties.Values
                     //.Where(FindValue)
                     .FirstOrDefault(FindValue);

                bool FindValue(dynamic value)
                {
                    var typeFind = typeof(T);
                    var typeVal = (Type)value?.GetType();

                    if (typeFind.IsValueType || typeFind.IsClass)
                        return typeVal == typeFind;
                    else
                    {
                        var interf = typeVal.GetInterfaces() ?? Array.Empty<Type>();
                        return interf.Contains(typeFind);
                    }
                }
            }
        }

        /// <summary>
        /// Получить значение (для анонимного чтения привести к dynamic: var value = ((dynamic)IDynamicObject).MyProperty)
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public virtual dynamic GetValue(string propertyName)
        {
            return GetPropertyValueInner(propertyName, out Type _);
        }

        /// <summary>
        /// Получить тип свойства
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Type GetPropertyType(string propertyName)
        {
            GetPropertyValueInner(propertyName, out var type);

            return type;
        }

        protected dynamic GetPropertyValueInner(string propertyName, out Type propertyType)
        {
            propertyName = propertyName.ToLower();
            if (propertyName == Id)
                propertyName = IdNameProperty.ToLower();

            propertyType = typeof(object);

            var propertyData = propertyName.Trim().Split('.').ToList();
            if (!propertyData.Any())
                return null;

            var keyProp = propertyData[0];
            object value = null;

            if (!Properties.ContainsKey(keyProp))
            {
                var keyPropChanging = keyProp.RemoveDTO();
                if (!Properties.ContainsKey(keyPropChanging))
                {
                    keyPropChanging = $"i{keyPropChanging}";
                    if (!Properties.ContainsKey(keyPropChanging))
                        return null;
                }

                value = Properties[keyPropChanging];
            }
            else
                value = Properties[keyProp];

            propertyData.Remove(keyProp);

            return GetPropertyValueRecurs(value, propertyData, out propertyType);
        }

        /// <summary>
        /// Получить значение рекурсивно
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyData"></param>
        /// <returns></returns>
        private dynamic GetPropertyValueRecurs(object obj, IList<string> propertyData, out Type propertyType)
        {
            propertyType = typeof(object);

            if (obj == default || !propertyData.Any())
                return obj;

            var strObjProperty = propertyData[0];
            var fullName = $"{obj.GetType().Name}.{strObjProperty}";

            PropertyInfo propertyInfo = null;

            if (!_metaData.TryGetValue(fullName, out propertyInfo))
            {
                var type = obj.GetType();
                var properties = type.GetPropertiesCust();

                propertyInfo = properties.FirstOrDefault(x => x.Name.ToLower() == strObjProperty);
                if (propertyInfo == null)
                {
                    strObjProperty = strObjProperty.RemoveRefDTO();
                    propertyInfo = properties.FirstOrDefault(x => x.Name.ToLower() == strObjProperty);
                }

                if (propertyInfo != null)
                    _metaData.Add(fullName, propertyInfo);
            }

            propertyType = propertyInfo?.PropertyType ?? typeof(object);

            var objProperty = propertyInfo?.GetValue(obj, null);

            if (objProperty == null || propertyData.Count == 1)
                return objProperty;

            // Для следующих вложений рекурсивно
            propertyData.Remove(strObjProperty);

            return GetPropertyValueRecurs(objProperty, propertyData, out propertyType);
        }

        #endregion Methods

        #region DynamicObject override

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetValue(binder.Name);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetValue(binder.Name, value);

            return true;
        }

        #endregion DynamicObject override

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
