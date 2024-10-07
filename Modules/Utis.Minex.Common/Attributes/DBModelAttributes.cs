using System;

namespace Utis.Minex.Common.Attributes
{
    /// <summary>
    /// Атрибут метода инициализации сущности
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class EntityIninitialisationAttribute : Attribute
    {
    }
}
