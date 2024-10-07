using System;
using System.Collections.Generic;

namespace Utis.Minex.Common.JobManager
{
    /// <summary>
    /// Менеджер выполняемых работ по расписанию
    /// </summary>
    public static class JobManager
    {
        private static List<Job> _jobs = new();

        /// <summary>
        /// Добавить работу с указанным интервалом выполнения
        /// </summary>
        /// <param name="jobToRun">Делегат выполняемого метода</param>
        /// <param name="interval">Интервал выполнения работы</param>
        /// <param name="dueTime">Интервал между стартом таймера и первым выполнением работы</param>
        /// <param name="jobName">Наименование работы</param>
        public static void AddJob(Action jobToRun, TimeSpan interval, TimeSpan? dueTime = null, string? jobName = null)
        {
            var newJob = CreateJob(jobToRun, interval, dueTime, jobName);

            AddJob(newJob);
        }

        /// <summary>
        /// Остановка всех работ
        /// </summary>
        public static void StopAll()
        {
            _jobs.ForEach(j => j.Stop());
        }

        /// <summary>
        /// Инициалиазция объекта работы
        /// </summary>
        /// <param name="jobToRun">Делегат выполняемого метода</param>
        /// <param name="interval">Интервал выполнения работы</param>
        /// <param name="dueTime">Интервал между стартом таймера и первым выполнением работы</param>
        /// <param name="jobName">Наименование работы</param>
        /// <returns>Объект работы <see cref="Job"/></returns>
        private static Job CreateJob(Action jobToRun, TimeSpan interval, TimeSpan? dueTime = null,
            string? jobName = null)
        {
            if (jobToRun == null)
            {
                throw new ArgumentNullException(nameof(jobToRun));
            }

            dueTime ??= TimeSpan.Zero;

            return new Job(jobName, jobToRun, (TimeSpan)dueTime, interval);
        }

        /// <summary>
        /// Добавление в список и запуск работы
        /// </summary>
        /// <param name="job">Объект работы</param>
        private static void AddJob(Job job)
        {
            job.Run();

            _jobs.Add(job);
        }
    }
}