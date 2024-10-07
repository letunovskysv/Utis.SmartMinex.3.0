using System.ComponentModel;

namespace Utis.Minex.Common
{
    public class VersionObjectBaseDTO : ObjectBaseDTO, IVersionObjectBase
    {
        /// <summary>
        /// Версия объекта.
        /// </summary>
        [Browsable(false)]
        [DisplayName("Версия объекта")]
        public virtual long VersionObject
        { get; set; }
    }
}