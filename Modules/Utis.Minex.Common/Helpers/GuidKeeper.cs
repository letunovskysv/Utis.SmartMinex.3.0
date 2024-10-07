using System;

namespace Utis.Minex.Common.Helpers
{
    public interface IGuidKeeper
    {
        public Guid Guid { get; }
    }

    public class GuidKeeper : IGuidKeeper
    {
        public Guid Guid { get; }

        public GuidKeeper() => Guid = System.Guid.NewGuid();

    }
}
