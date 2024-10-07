using System;
using System.Reflection;
using System.ComponentModel;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Базовый класс объекта.
    /// </summary>
    public class ObjectBaseDTO : IObjectBase
    {
        #region Props
        
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [ReadOnly(true)]
        [Minex.Common.DisplayName("Идентификатор")]
        public virtual long Id 
        { get; set; }

        /// <summary>
        /// Время создания.
        /// </summary>
        [ReadOnly(true)]
        [Minex.Common.DisplayName("Создан")]
        public virtual DateTime? Created 
        { get; set; }

        /// <summary>
        /// Время изменения.
        /// </summary>
        [ReadOnly(true)]
        [Minex.Common.DisplayName("Изменён")]
        public virtual DateTime? Updated  
        { get; set; }

        /// <summary>
        /// Флаг удаления.
        /// </summary>
        [Browsable(false)]
        [Minex.Common.DisplayName("Удалено")]
        public virtual bool Deleted 
        { get; set; }

        #endregion

        #region Clone

        public virtual object Clone()
        {
            var clone = 
                GetType()
                    .GetMethod(nameof(MemberwiseClone), BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.Invoke(this, null);

            return 
                clone;
        }

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
            return obj != default && obj.GetType() == this.GetType() && (obj as ObjectBaseDTO).Id == Id;
        }        

        #endregion

        public override string ToString()
        {
            return $"Id:{Id}({GetType().GetDisplayName()})";
        }
    }
}