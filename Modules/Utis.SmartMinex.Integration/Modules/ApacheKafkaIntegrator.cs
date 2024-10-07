//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ApacheKafkaIntegrator – Интеграция. Работа с брокером сообщений Apache Kafka.
// Библиотека: Confluent.Kafka.2.5.3 https://kafka.apache.org/
// Confluent: https://docs.confluent.io/kafka-clients/dotnet/current/overview.html
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
using Confluent.Kafka;
#endregion Using

namespace Utis.SmartMinex.Integration;

/// <summary> Работа с брокером сообщений Apache Kafka.</summary>
sealed class ApacheKafkaIntegrator : SmartModule
{
    #region Declarations

    readonly ProducerConfig _incfg;
    readonly ConsumerConfig _outcfg;
    readonly string _topic;

    #endregion Declarations

    public ApacheKafkaIntegrator(IRuntime runtime, string? BootstrapServers, string[]? subscribe) : base(runtime)
    {
        Messages = [MSG.Test, MSG.BrokerMessageOut, MSG.BrokerMessageIn];
        _incfg = new ProducerConfig
        {
            BootstrapServers = BootstrapServers ?? "localhost:9092", // через запятую, может быть указано несколько сервисов Kafka
        };
        _outcfg = new ConsumerConfig
        {
            BootstrapServers = BootstrapServers ?? "localhost:9092",
            GroupId = "foo",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _topic = subscribe?.FirstOrDefault() ?? "UTIS";
    }

    public override bool OnStart()
    {
        if (Heartbeat())
            ReceiveLoop(CancellationToken.None).ConfigureAwait(false);

        return true;
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.Test:
                await SendMessage(_topic, "Hello Kafka!");
                break;

            case MSG.BrokerMessageIn:
                Runtime.Send(MSG.WarningMessage, ProcessId, 0, m.Data.ToString());
                break;

            case MSG.BrokerMessageOut:
                if (m.Data != null)
                    await SendMessage(_topic, m.Data.ToString());
                break;
        }
    }

    async Task SendMessage(string topic, string message)
    {
        using var prod = new ProducerBuilder<Null, string>(_incfg).Build();
        var res = await prod.ProduceAsync(topic, new Message<Null, string> { Value = message });
    }

    async Task ReceiveLoop(CancellationToken stoppingToken) => await Task.Run(() =>
    {
        using var cons = new ConsumerBuilder<Ignore, string>(_outcfg).Build();
        cons.Subscribe(_topic);
       
        while (!stoppingToken.IsCancellationRequested)
        {
            var inmsg = cons.Consume(stoppingToken);
            Runtime.Send(MSG.BrokerMessageIn, ProcessId, 0, inmsg.Message.Value);
        }
        cons.Close();
    }, stoppingToken);

    bool Heartbeat()
    {
        try
        {
            using var hittest = new ProducerBuilder<Null, string>(_incfg).Build();
            return hittest.ProduceAsync(_topic, new Message<Null, string> { Value = "Hi!" }).Result.Status == PersistenceStatus.Persisted;
        }
        catch
        {
            return false;
        }
    }
}
