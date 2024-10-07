//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Служба Windows или демон Linux.
// Возможность запуска модуля Runtime в отдельном процессе.
//--------------------------------------------------------------------------------------------------
#region Using
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Server;
#endregion Using

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // fix error: No data is available for encoding 1251

var asm = Assembly.GetEntryAssembly();
Console.Title = string.Concat(
    asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "Сервер приложений УТИС ", " ",
    asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? " 3.0", " - ",
    asm.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? " УралТехИС");

UtisAppDomain<RuntimeService>? app = null;
AppDomain.CurrentDomain.ProcessExit += (s,e) => app?.StopAsync(CancellationToken.None);

await Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .UseSystemd()
    .UseContentRoot(Path.GetDirectoryName(asm.Location))
    .ConfigureAppConfiguration((ctx, cfg) =>
    {
        cfg.AddCommandLine(args, new Dictionary<string, string>());
        cfg.AddJsonFile(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + ".runtimeconfig.json", true);
    })
    .ConfigureServices(srv => srv.AddHostedService<UtisAppDomain<RuntimeService>>())
    .Build()
    .RunAsync();
