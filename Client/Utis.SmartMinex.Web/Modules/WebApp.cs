//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WebApp – Запуск Веб-приложения.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Client;
#endregion Using

class WebApp
{
    internal static async Task Main(string[] args)
    {
        await WebClient.CreateApplication(args.Length > 0 && int.TryParse(args[0], out var port) ? port : WebClient.DefaultPortSsl,
            srv => srv.AddSingleton<IDispatcher, DispatcherClient>());
    }
}