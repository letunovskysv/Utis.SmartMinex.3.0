using System;
using System.Collections.Generic;

namespace Utis.Minex.Common.PropertyDelegate
{
    /// <summary>
    /// Обёртка дабы избежать мдленного DynamicInvoke
    /// </summary>
    public class DelegateInvoke<T, U> : DelegateInvokeBase
    {
        public Func<T, U> GetValueDelegate { get; set; }

        public Action<T, U> SetValueDelegate { get; set; }

        public override object Get(object entity)
        {
            return GetValueDelegate.Invoke((T)entity);
        }

        public override void Set(object entity, object innerEntity)
        {
            SetValueDelegate.Invoke((T)entity, (U)innerEntity);
        }

        public override Type GetPropertyType()
        {
            return _propertyType;
        }
        private Type _propertyType = typeof(U);

        public override bool EqualProperty(ObjectBase right, ObjectBase left)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Обёртка дабы избежать мдленного DynamicInvoke
    /// </summary>
    public class DelegateInvokeObjectBase<T, U> : DelegateInvoke<T, U> where T : ObjectBase
    {
        /// <summary>
        /// Сравниваен конкретное свойство в классах избегая упаковки/распаковки
        /// </summary>
        public override bool EqualProperty(ObjectBase right, ObjectBase left)
        {
            var propertyInRight = GetValueDelegate.Invoke((T)right);
            var propertyInLeft = GetValueDelegate.Invoke((T)left);

            return (propertyInRight == null && propertyInLeft == null) || (propertyInRight != null && EqualityComparer<U>.Default.Equals(propertyInRight, propertyInLeft));
        }
    }
}