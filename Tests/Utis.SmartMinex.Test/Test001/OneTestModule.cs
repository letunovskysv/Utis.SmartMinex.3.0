//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: OneTestModule – Тестовый 1 модуль.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Test;

sealed class OneTestModule : TestModuleBase
{
    int _count = 0;
    bool _messageEnable;
    readonly IMetadata _md;

    public OneTestModule(IRuntime runtime, IMetadata md, bool messageEnable) : base(runtime)
    {
        Messages = [MSG.Completed, MSG_TEST3];
        _md = md;
        _messageEnable = messageEnable;
    }

    public override bool OnStart()
    {
        return true;
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.Completed:
                Runtime.Send(MSG_TEST1, ProcessId, new Random().NextInt64(), "Тестовое сообщение " + ++_count);
                Runtime.Schedule(MSG_SCHEDULE1, ProcessId, new Random().NextInt64(), "Планируемое сообщение " + ++_count, 5000, 5000);
                break;

            case MSG_TEST3:
                if (_messageEnable) Runtime.Send(MSG.InformMessage, ProcessId, m.HParam, string.Concat("Получено сообщение 3: ", m.Data));
                Runtime.Send(MSG_TEST1, ProcessId, new Random().NextInt64(), "Тестовое сообщение " + ++_count);
                break;
        }
        await DoEventsAsync(1000, stoppingToken);
    }

    public override void OnStop()
    {
    }
}