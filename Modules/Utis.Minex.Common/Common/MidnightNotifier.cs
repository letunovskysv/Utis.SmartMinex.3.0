using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Utis.Minex.SeniorLampman.Managers
{
    //https://stackoverflow.com/questions/8480063/event-for-datechange-at-midnight

    /// <summary>
    /// Уведомлятор смены суток/изменения времени системного.
    /// </summary>
    public static class MidnightNotifier
    {
        private static readonly Timer _timer;

        public static DateTime CurrentDay
        { get; private set; }

        static MidnightNotifier()
        {
            _timer =
                new Timer(GetSleepTime());

            _timer.Elapsed
                += (s, e) =>
                {
                    _timer.Interval = GetSleepTime();
                    OnDayChanged();
                };

            _timer.Start();
        }

        private static double GetSleepTime()
        {
            CurrentDay = DateTime.Now;
            var midnightTonight = DateTime.Today.AddDays(1);
            var differenceInMilliseconds = (midnightTonight - CurrentDay).TotalMilliseconds;
            return differenceInMilliseconds;
        }

        public static void SetSleepTime()
        {
            _timer.Interval = GetSleepTime();
        }

        private static void OnDayChanged()
        {
            DayChanged?.Invoke(null, null);
        }

        public static event EventHandler<EventArgs> DayChanged;
    }
}