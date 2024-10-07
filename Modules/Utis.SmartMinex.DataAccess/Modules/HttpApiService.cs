//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: HttpApiService – Информационный сервис. Веб-служба доступа к данным Системы.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Http;
#endregion Using

namespace Utis.SmartMinex.DataAccess;

/// <summary> Веб-служба доступа к данным Системы.</summary>
sealed class HttpApiService : HttpService
{
    public HttpApiService(IRuntime runtime, IMetadata metadata, string name, string? uri, SslCertificate? certificate)
        : base(runtime, metadata, name, uri, certificate)
    { }

    public override Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.Test:
                break;
        }
        return Task.CompletedTask;
    }
}
