using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Interfaces
{
    public interface IUserThresholdSettings
    {
         /// <summary>
        /// Порог длительности простоя пользователя.
        /// </summary>
        [DisplayName("Порог длительности простоя пользователя")]
        int ThresholdIdleInMinutes
        { get; set; }

        /// <summary>
        /// Выполнять разрыв соединения при превышения порога длительности простоя.
        /// </summary>
        [DisplayName("Выполнять разрыв соединения при превышения порога длительности простоя")]
        bool TerminateConnectionByThresholdIdle
        { get; set; }
    }
}
