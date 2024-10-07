namespace Utis.Minex.Common
{
    public abstract class VersionObjectBase : ObjectBase, IVersionObjectBase
    {
        /// <summary>
        /// Версия объекта.
        /// </summary>
        [DisplayName("Версия объекта")]
        [Description("Версия объекта")]
        [RegisterChangesIgnore(true)]
        public virtual long VersionObject
        { get; set; }
    }
}