using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utis.Minex.Common.Settings;

namespace Utis.Minex.Common.Interfaces
{
    public interface IDistanceLocalCacheSettings : ISettingsManagerBase
    {
        /// <summary>
        /// Сохранять кеш локальных дистанций
        /// </summary>
        [DisplayName("Сохранять кеш локальных дистанций")]
        bool SaveDistanceLocalCache
        { get; set; }
    }
}
