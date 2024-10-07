//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ConfiguratorController – Конфигуратор метаданных.
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Mvc;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Http;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Archestra;

public class ConfiguratorController(IRuntime runtime, IMetadata metadata) : SmartController(runtime, metadata)
{
    /// <summary> Возвращает полный список объектов конфигурации.</summary>
    /// <example> https://localhost:8088/configurator/inspector </example>
    [HttpGet("[action]")]
    public async Task<IActionResult> Inspector() =>
        await SafeExecuteGetOperation<IActionResult>(() =>
        {
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "Inspector"
            };
        });
}
