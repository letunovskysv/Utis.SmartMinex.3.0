
namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый класс именованного объекта.
    /// </summary>
    [Description("Именованный объект")]
    [DisplayName("Базовый класс именованного объекта")]
    public abstract class NamedObjectBase : VersionObjectBase, IObjectNamed
    {
        /// <summary>
        /// Инициализирует базовый класс именованного объекта.
        /// </summary>
        public NamedObjectBase() { }

        /// <summary>
        /// Инициализирует базовый класс именованного объекта.
        /// </summary>
        /// <param name="name">Наименование.</param>
        public NamedObjectBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DisplayName("Наименование")]
        public virtual string Name 
        { get; set; }

        public override string ToString()
        {
            return 
                string.IsNullOrEmpty(Name) 
                    ? $"{GetType().Name} Id{Id}" 
                    : Name;
        }
    }
}