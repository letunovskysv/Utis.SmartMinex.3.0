using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Справочник зон.
    /// </summary>
    [DisplayName("Справочник зон")]
    public interface IZone : IObjectNamed
    {
        /// <summary>
        /// Описание.
        /// </summary>
        [DisplayName("Описание")]
        string Description
        { get; set; }

        /// <summary>
        /// Признак "локальности".
        /// </summary>
        [DisplayName("Локальная")]
        bool? IsLocal
        { get; set; }

        /// <summary>
        /// Признак входа в участок.
        /// </summary>
        [DisplayName("Внутри участка")]
        bool? InsideArea
        { get; set; }

        /// <summary>
        /// Принадлежность к зоне родителю.
        /// </summary>
        [DisplayName("Родитель")]
        [Description("Принадлежность к зоне родителю")]
        IZone ParentZone
        { get; set; }
    }

}
