using System.Collections.Generic;
using System.Linq;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Результат проверки опасной зоны
    /// </summary>
    public interface IZoneDangerousCheckResult : IZoneDangerousCheckBase
    {
        void AddStatuses(params ZoneDangerousStatusType[] statuses);

        IEnumerable<ZoneDangerousStatusType> Statuses { get; }
        static IZoneDangerousCheckResult Create(IEnumerable<ZoneDangerousStatusType> statuses, IEnumerable<long> damagedDevices = null)
        {
            return new ZoneDangerousCheckResult(statuses, damagedDevices);
        }
    }

    internal class ZoneDangerousCheckResult : IZoneDangerousCheckResult
    {
        readonly List<ZoneDangerousStatusType> _typeStatuses = new();
        public IEnumerable<ZoneDangerousStatusType> Statuses => _typeStatuses;

        public long[] DamagedDevices { get; }

        public int[] TypeStatuses => _typeStatuses.Cast<int>().ToArray();

        internal ZoneDangerousCheckResult(IEnumerable<ZoneDangerousStatusType> statuses, IEnumerable<long> damagedDevices = null)
        {
            _typeStatuses.AddRange(statuses);
            DamagedDevices = damagedDevices.ToArray();
        }

        public void AddStatuses(params ZoneDangerousStatusType[] statuses)
        {
            foreach (var status in statuses)
            {
                if (!_typeStatuses.Contains(status))
                    _typeStatuses.Add(status);
            }
        }
    }
}
