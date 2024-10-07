//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: WebClient – Клиентская Веб-служба. Веб-сервер.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using Utis.SmartMinex.Client.Components;
using Utis.SmartMinex.Http;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Security;
#endregion Using

namespace Utis.SmartMinex.Client;

/// <summary> Клиентская Веб-служба.</summary>
sealed partial class WebClient : SmartModule, IHttpClient
{
    #region Declarations

    public const int DefaultPortSsl = 8080;

    readonly SslCertificate? _cert;
    readonly bool _ssl;
    readonly IMetadata _md;

    #endregion Declarations

    #region Properties

    public int Port { get; set; }

    #endregion Properties

    public WebClient(IRuntime runtime, IMetadata metadata, string name, string? uri, SslCertificate? certificate)
        : base(runtime)
    {
        _md = metadata;
        _cert = certificate;
        var scheme = (_ssl = Regex.IsMatch(uri ??= "https://0.0.0.0", @"^https*", RegexOptions.IgnoreCase)) ? Regex.Match(uri, @"^https*", RegexOptions.IgnoreCase).Value.ToUpper() : "HTTP";
        Port = Regex.IsMatch(uri, @"(?<=:)\d+")
            ? int.Parse(Regex.Match(uri, @"(?<=:)\d+").Value) 
            : scheme == "HTTPS" ? DefaultPortSsl : 80;

        Name = name + ", порт " + Port;
    }

    public override bool OnStart()
    {
        CreateApplication(Port,
            srv => srv.AddSingleton<IDispatcher>(new DispatcherService(_md))
        ).ConfigureAwait(false);

        return true;
    }

    public override Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        switch (m.Msg)
        {
            case MSG.Test:
                break;
        }
        return Task.CompletedTask;
    }

    public static async Task CreateApplication(int port, Action<IServiceCollection>? configureServices)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            WebRootPath = TPath.Combine(TPath.GetDirectoryName(Environment.CommandLine), "wwwroot")
        });

        builder.WebHost.ConfigureKestrel(opt =>
        {
            opt.ListenAnyIP(port, listen =>
            {
                listen.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                listen.UseHttps(Cerberus.Certificate());
            });
        });

        builder.Services.AddAuthorizationCore();
        builder.Services.AddOptions();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<AuthenticationStateProvider, UtisAuthStateProvider>();
        builder.Services.AddScoped<UtisSession>();
        builder.Services.AddTransient<GInstanceCreatorAsync>();
        configureServices?.Invoke(builder.Services);

        // Add services to the container.
        builder.Services.AddRazorComponents() //opt => opt.DetailedErrors = builder.Environment.IsDevelopment())
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddRadzenComponents();
        builder.Services.AddDistributedMemoryCache();

        var app = builder.Build();

        app.UseExceptionHandler(appex => appex.Run(async ctx =>
        {
            ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ctx.Response.ContentType = "application/json";
            var err = ctx.Features.Get<IExceptionHandlerFeature>();
            if (err != null)
            {
                if (err.Error is HttpApiException hfe)
                    ctx.Response.StatusCode = (int)hfe.StatusCode;

                await ctx.Response.WriteAsync(JsonConvert.SerializeObject(err.Error), Encoding.UTF8);
            }
        }));

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<UtisApp>()
            .AddAdditionalAssemblies([typeof(_Imports).Assembly, typeof(SmartLanternClient).Assembly])
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode();

        await app.RunAsync();
    }
}
