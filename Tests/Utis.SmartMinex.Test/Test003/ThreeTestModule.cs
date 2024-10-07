//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ThreeTestModule – Тестовый 3 модуль.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Test;

interface IThreeTestModule
{
}

sealed class ThreeTestModule : TestModuleBase, IThreeTestModule
{
    int _count = 0;
    bool _messageEnable;

    public ThreeTestModule(IRuntime runtime, bool messageEnable) : base(runtime)
    {
        Messages = [MSG.Test, MSG_TEST2];
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
            case MSG_TEST2:
                if (_messageEnable) Runtime.Send(MSG.InformMessage, ProcessId, m.HParam, string.Concat("Получено сообщение 2: ", m.Data));
                Runtime.Send(MSG_TEST3, ProcessId, new Random().NextInt64(), "Тестовое сообщение " + ++_count);
                break;
        }
        await DoEventsAsync(1000, stoppingToken);
    }

    public override void OnStop()
    {
    }
}
