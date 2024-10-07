namespace Utis.Minex.Common.PropertyDelegate
{
    public class PropertyDelegates
    {
        public string PropertyName { get; }

        public DelegateInvokeBase PropertyInvoker { get; }

        public PropertyDelegates(
            string propertyName,
            DelegateInvokeBase propertyInvoker
        )
        {
            PropertyName = propertyName;
            PropertyInvoker = propertyInvoker;
        }

        public override int GetHashCode()
        {
            return PropertyName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is PropertyDelegates otherPropertyDelegates && PropertyName.Equals(otherPropertyDelegates.PropertyName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}