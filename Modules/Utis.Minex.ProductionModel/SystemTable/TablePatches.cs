
namespace Utis.Minex.ProductionModel.SystemTable
{
    using Utis.Minex.Common;

    /// <summary>
    /// Таблица применённых патчей.
    /// </summary>
    [DisplayName("Таблица применённых патчей")]
    public class TablePatches : ObjectBase
    {
        /// <summary>
        /// Имя патча (класса патча).
        /// </summary>
        [DisplayName("Имя патча")]
        public virtual string PatchName
        { get; set; }

        /// <summary>
        /// Порядковый номер патча.
        /// </summary>
        [UniqueKey]
        [DisplayName("Номер патча")]
        public virtual int PatchNumber
        { get; set; }

        /// <summary>
        /// Краткое описание патча.
        /// </summary>
        [DisplayName("Краткое описание патча")]
        public virtual string Description
        { get; set; }
    }
}