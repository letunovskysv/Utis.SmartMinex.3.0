using System;
using Utis.Minex.Common.Enums;

namespace Utis.Minex.Common.Attributes
{
    /// <summary>
    /// Атрибут специального формата
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class CustomColumnAttribute : Attribute
    {
        public SettingsType CustomType { get; }

        public string CustomTemplate { get; }
        public CustomColumnAttribute(string customTemplate)
        {
            CustomTemplate = customTemplate;
        }
        public CustomColumnAttribute(SettingsType customType)
        {
            CustomType = customType;
        }
    }
}
