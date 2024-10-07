using System;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый объект.
    /// </summary>
    [DisplayName("Базовый объект")]
    public abstract class ObjectBase : IObjectBase
    {
        #region Properties

        /// <summary>
        /// Идентификатор объекта.
        /// </summary>
        [DisplayName("Идентификатор")]
        [Description("Уникальный идентификатор объекта")]
        public virtual long Id 
        { get; set; }

        /// <summary>
        /// Метка удаления.
        /// </summary>        
        [DisplayName("Удалено")]
        [Description("Метка удаления объекта")]
        [RegisterChangesIgnore(true)]
        public virtual bool Deleted 
        { get; set; }

        /// <summary>
        /// Дата/время создания объекта.
        /// </summary>
        [DisplayName("Создан")]
        [Description("Дата/время создания объекта")]
        [RegisterChangesIgnore(true)]
        public virtual DateTime? Created 
        { get; set; }

        /// <summary>
        /// Дата/время изменения объекта.
        /// </summary>
        [DisplayName("Изменён")]
        [Description("Дата/время изменения объекта")]
        [RegisterChangesIgnore(true)]
        public virtual DateTime? Updated 
        { get; set; }

        #endregion

        #region Equals

        public override int GetHashCode()
        {
            // Ридонли полей нет
            // Опираться на предлагаемую реализацию нельзя, поскольку она не соответсвует Equals
            // Даже если брать Id или хэш от него, могут возникнуть ошибки, уж лучше так, медленнее, но надёжнее
            return 0;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ObjectBase);
        }

        public virtual bool Equals(ObjectBase obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return Id == obj.Id;
        }

        public static bool operator == (ObjectBase a, ObjectBase b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator != (ObjectBase a, ObjectBase b)
        {
            return !(a == b);
        }

        #endregion
    }
}