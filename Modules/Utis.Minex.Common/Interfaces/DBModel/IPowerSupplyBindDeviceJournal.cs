using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Устройства подключённые к блоку питания
    /// </summary>
    [DisplayName("Устройства подключённые к блоку питания")]
    public interface IPowerSupplyBindDeviceJournal : IJournalClose
    {
        /// <summary>
        /// Устройство
        /// </summary>
        [DisplayName("Устройство")]
        public IDevice Device
        { get; set; }

        /// <summary>
        /// Блок питания
        /// </summary>
        [DisplayName("Блок питания")]
        public IReader Reader
        { get; set; }
    }
}
