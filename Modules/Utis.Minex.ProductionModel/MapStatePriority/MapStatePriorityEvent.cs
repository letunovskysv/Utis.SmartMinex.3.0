using System.Collections.Generic;

namespace Utis.Minex.ProductionModel
{
        using Utis.Minex.Common;

    public class MapStatePriorityEvent : CatalogBase
    {
        public virtual string TFirst
        { get; set; }

        public virtual string TSecond
        { get; set; }

        public virtual IEnumerable<string> MapKeys
        { get; set; }

        public virtual IEnumerable<string> MapValues
        { get; set; }
    }
}