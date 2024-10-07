//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ArchestraService – Веб-служба конфигуратора параметров Системы.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;
using Radzen;
using Utis.SmartMinex.Archestra.Components;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Http;
using Utis.SmartMinex.Archestra.Components.Shared;
#endregion Using

namespace Utis.SmartMinex.Archestra;

/// <summary> Веб-служба конфигуратора параметров Системы.</summary>
sealed partial class ArchestraService : HttpService, IDispatcher
{
    #region Events

    public event MetadataEventHandlerAsync MetadataChanged;

    #endregion Events

    public ArchestraService(IRuntime runtime, IMetadata metadata, string name, string? uri, SslCertificate? certificate, IHttpClient? client)
        : base(runtime, metadata, name, uri, certificate)
    {
        Messages = [MSG.ObjectModified];
        ClientPort = client?.Port;
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        services.AddRadzenComponents();
        services.AddScoped(srv => Runtime);
        services.AddSingleton(srv => _md);
        services.AddSingleton<IDispatcher>(this);
        services.AddScoped<SessionData>();

        base.ConfigureServices(services);
    }

    public override void ConfigureApplication(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        base.ConfigureApplication(app);

        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new EmbeddedFileProvider(typeof(UtisApp).Assembly,
                string.Concat(Regex.Match(typeof(UtisApp).Assembly.FullName, @"[\w_\.]+").Value, ".wwwroot"))
        });
        app.UseAntiforgery();

        app.MapRazorComponents<UtisApp>()
            .AddInteractiveServerRenderMode();
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.ObjectModified:
                if (MetadataChanged != null)
                    await MetadataChanged.Invoke(m.LParam, m.Data as TEntity);
                break;
        }
    }
}
