using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Helpers
{
    public static class TimeSyncHelper
    {
        public static bool CheckSync(TimeSpan machine1, TimeSpan machine2, out double deltaInMinutes)
        {
            deltaInMinutes = new TimeSpan(Math.Abs(machine1.Ticks - machine2.Ticks)).TotalMinutes;
            return deltaInMinutes > 1;
        }
    }
}
