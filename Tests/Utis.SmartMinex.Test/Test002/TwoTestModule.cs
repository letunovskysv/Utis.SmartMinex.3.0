//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TwoTestModule – Тестовый 2 модуль.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Test;

sealed class TwoTestModule : TestModuleBase
{
    int _count = 0;
    bool _messageEnable;
    readonly IThreeTestModule _module3;

    public TwoTestModule(IRuntime runtime, IThreeTestModule module3, bool messageEnable) : base(runtime)
    {
        Messages = [MSG_TEST1, MSG_SCHEDULE1];
        _module3 = module3;
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
            case MSG_TEST1:
                if (_messageEnable) Runtime.Send(MSG.InformMessage, ProcessId, m.HParam, string.Concat("Получено сообщение 1: ", m.Data));
                Runtime.Send(MSG_TEST2, ProcessId, new Random().NextInt64(), "Тестовое сообщение " + ++_count);
                break;

            case MSG_SCHEDULE1:
                if (_messageEnable) Runtime.Send(MSG.InformMessage, ProcessId, m.HParam, string.Concat("Получено сообщение: ", m.Data));
                break;
        }
        await DoEventsAsync(1000, stoppingToken);
    }

    public override void OnStop()
    {
    }
}
