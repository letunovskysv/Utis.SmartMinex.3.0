using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utis.Minex.Common.Helpers
{
    public static class ExeTimeMeasureHelper
    {
        public static void PrintExeTime(Action action, IServerInputOutput logger, string moduleName = "", string methodName = "")
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            action?.Invoke();
            var stopTime = stopWatch.ElapsedMilliseconds;

            Print($"{(moduleName.IsNullOrEmpty() ? action.Method.Module : moduleName)}",
                  $"{(methodName.IsNullOrEmpty() ? action.Method.Name : methodName)}",
                  TimeSpan.FromMilliseconds(stopTime).TotalSeconds,
                  logger);
        }

        public static void PrintExeTime<T>(out IEnumerable<T> values, Func<IEnumerable<T>> func, IServerInputOutput logger, string moduleName = "", string methodName = "")
        {
            var exeTime = new ExeTimeMeasure(logger, moduleName);
            values = func.Invoke();
            exeTime.PrintOnRunning(methodName);
        }

        public static void Print(string moduleName, string methodName, double seconds, IServerInputOutput serverInputOutput)
        {
            serverInputOutput.WriteLine($"{moduleName}: время выполнения {methodName} {seconds} секунд");
        }
    }

    public class ExeTimeMeasure
    {
        private readonly IServerInputOutput _serverInputOutput;
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private readonly string _moduleName = string.Empty;
        private long prevTime = 0;
        public ExeTimeMeasure(IServerInputOutput logger, string moduleName)
        {
            _serverInputOutput = logger ?? throw new ArgumentNullException(nameof(logger));
            _moduleName = moduleName;
            _stopWatch.Start();
        }

        public void Restart()
        {
            _stopWatch.Stop();
            _stopWatch.Start();
        }

        public void PrintOnRunning(string methodName)
        {
            var elapsedTicks = _stopWatch.ElapsedTicks;
            var time = new TimeSpan(elapsedTicks - prevTime).TotalSeconds;
            prevTime = elapsedTicks;
            ExeTimeMeasureHelper.Print(_moduleName, methodName, time, _serverInputOutput);
        }
    }
}
