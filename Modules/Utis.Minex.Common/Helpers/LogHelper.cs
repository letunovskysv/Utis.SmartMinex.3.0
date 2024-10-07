using System;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.Common.Helpers
{
    public static class LogHelper
    {
        public static void WriteToLogOnCatch(IPureLogger pureLogger, Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                pureLogger.WriteException(exception);
            }
        }
    }
}
