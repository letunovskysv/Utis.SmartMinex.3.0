using System;

namespace Utis.Minex.ProductionModel.Notes
{
    using Utis.Minex.Common;

    public abstract class NoteBase : VersionObjectBase
    {
        /// <summary>
        /// Дата/время возникновения записи.
        /// </summary>
        [DisplayName("Дата/время возникновения записи")]
        public virtual DateTime DateTime
        { get; set; }
    }
}