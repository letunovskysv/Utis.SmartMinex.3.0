//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisAppDomain - Запуск конфигурации в отдельном процессе.
//--------------------------------------------------------------------------------------------------
using Utis.SmartMinex.Runtime;

namespace Utis.SmartMinex.Server;

class UtisAppDomain<T>(IServiceProvider services, ILogger<RuntimeService> logger, IConfiguration config) : BackgroundService
{
    readonly Type _type = typeof(T);
    readonly IServiceProvider _srv = services;
    readonly ILogger _logger = logger;
    readonly  IConfiguration _cfg = config;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) =>
        await ((RuntimeService)Activator.CreateInstance(_type, _srv, _logger, _cfg))
            .ExecuteAsync(stoppingToken);
}
