using System;

namespace Utis.Minex.Common.PropertyDelegate
{
    public abstract class DelegateInvokeBase
    {
        /// <summary>
        /// Стоит помнить что если это не класс то будет  упаковка/распаковка
        /// </summary>
        public abstract object Get(object entity);

        /// <summary>
        /// Стоит помнить что если это не класс то будет  упаковка/распаковка
        /// </summary>
        public abstract void Set(object entity, object innerEntity);

        public abstract Type GetPropertyType();

        /// <summary>
        /// Сравниваен конкретное свойство в классах избегая упаковки/распаковки
        /// </summary>
        public abstract bool EqualProperty(ObjectBase right, ObjectBase left);
    }
}