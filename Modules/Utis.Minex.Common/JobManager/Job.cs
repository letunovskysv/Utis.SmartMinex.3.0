using System;
using System.Threading;

namespace Utis.Minex.Common.JobManager
{
    /// <summary>
    /// Класс выполняемой работы
    /// </summary>
    internal class Job
    {
        #region Fields

        private readonly Timer _timer;
        private readonly Action _job;
        private readonly TimeSpan _dueTime;
        private readonly TimeSpan _period;

        #endregion

        /// <summary>
        /// Инициализация экземпляра класса <see cref="Job"/>
        /// </summary>
        /// <param name="name">Наименование работы</param>
        /// <param name="job">Делегат выполнямого метода</param>
        /// <param name="dueTime">Интервал между стартом таймера и первым выполнением работы</param>
        /// <param name="period">Интервал выполнения работы</param>
        public Job(string name, Action job, TimeSpan dueTime, TimeSpan period)
        {
            Name = name;
            _job = job;
            _dueTime = dueTime;
            _period = period;

            _timer = new Timer(TimerCallBack);
        }

        /// <summary>
        /// Наименование работы
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Дата следующего запуска
        /// </summary>
        public DateTime NextRun { get; private set; }

        /// <summary>
        /// Запуск работы
        /// </summary>
        public void Run()
        {
            NextRun = DateTime.Now + _dueTime;

            _timer.Change(_dueTime, _period);
        }

        /// <summary>
        /// Остановка работы
        /// </summary>
        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Выполняемый метод по истечению времени
        /// </summary>
        private void TimerCallBack(object? o)
        {
            NextRun = DateTime.Now + _period;

            _job.Invoke();
        }
    }
}
