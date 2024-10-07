//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TaskScheduler – Планировщик заданий.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

/// <summary> Планировщик заданий.</summary>
sealed class TaskScheduler : SmartModule
{
    #region Declarations

    readonly object _taskLock = new();

    List<TTaskRow> _tasks;
    List<TScheduleRow> _schedules;

    #endregion Declarations

    public TaskScheduler(IRuntime runtime) : base(runtime)
    {
        Messages = [MSG.ScheduleEventFired];
        Name = "Планировщик заданий";
    }

    public override bool OnStart()
    {
        //var db = Runtime.Metadata.CreateDbConnection().Open();
        try
        {
            //_tasks = db.Select<TTaskRow>().ToList();
            //_schedules = new();

            //_tasks.ForEach(tsk => AddSchedule(tsk));
        }
        catch
        {
            return false;
        }
        finally
        {
            //db.Close();
        }
        return true;
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.ScheduleEventFired:
                if (m.Data is TScheduleRow && _schedules.FirstOrDefault(s => s.Id == m.LParam) is TScheduleRow schedule)
                {
                    _schedules.Remove(schedule);
                    await DispatcherAsync(schedule);
                }
                break;
        }
    }

    #region Private methods

    void AddSchedule(TTaskRow task)
    {
        if ((task.Finish ?? DateTime.MaxValue) > DateTime.Now && task.Type >= TaskTypes.Seconds && task.Type <= TaskTypes.Days)
        {
            var delay_sec = task.Type switch
            {
                TaskTypes.Seconds => 1,
                TaskTypes.Minutes => 60,
                TaskTypes.Hours => 3600,
                _ => 86400,
            };
            var schedule = new TScheduleRow()
            {
                Id = _schedules.Count > 0 ? _schedules.Max(s => s.Id) + 1 : 0,
                Task = task,
                Datetime = task.Start.AddSeconds(Math.Ceiling((DateTime.Now - task.Start).TotalSeconds / delay_sec) * delay_sec)
            };
            _schedules.Add(schedule);
            //Runtime.Send(new TMessage(MSG.ScheduleEventFired, schedule.Id, schedule.Task.Target ?? schedule.Task.Id, schedule), schedule.Datetime);
        }
    }

    async Task DispatcherAsync(TScheduleRow schedule)
    {
        await Task.Run(() =>
        {
            switch (schedule.Task.Code)
            {
                case "CLEARSMLOG":
                    break;
            }
            AddSchedule(schedule.Task);
        });
    }

    #endregion Private methods
}
