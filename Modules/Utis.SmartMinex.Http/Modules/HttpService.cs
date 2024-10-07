//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: HttpService – Базовая Веб-служба.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Security;
#endregion Using

namespace Utis.SmartMinex.Http;

/// <summary> Базовая Веб-служба.</summary>
public abstract class HttpService : SmartModule
{
    #region Declarations

    const string CORSPOLICENAME = "SmartMinex";

    readonly SslCertificate? _cert;
    readonly bool _ssl;
    readonly string _path;
    protected readonly IMetadata _md;

    WebApplication? _app;

    #endregion Declarations

    #region Properties

    public int Port { get; set; }

    #endregion Properties

    public HttpService(IRuntime runtime, IMetadata metadata, string name, string? uri, SslCertificate? certificate) : base(runtime)
    {
        _md = metadata;
        var scheme = (_ssl = Regex.IsMatch(uri ??= "https://0.0.0.0", @"^https*", RegexOptions.IgnoreCase)) ? Regex.Match(uri, @"^https*", RegexOptions.IgnoreCase).Value.ToUpper() : "HTTP";
        _cert = _ssl && certificate.Path != null ? certificate : null;
        _path = Regex.Match(uri, @"(?<=[\\/])[\w_\\/]+(?=$)").Value;
        Port = Regex.IsMatch(uri, @"(?<=:)\d+") ? int.Parse(Regex.Match(uri, @"(?<=:)\d+").Value) : scheme == "HTTPS" ? 443 : 80;
        Name = name + ", порт " + Port;
    }

    public override bool OnStart()
    {
        var builder = WebApplication.CreateBuilder();
        if (_cert != null)
        {
            var cert = TPath.Combine(Runtime.WorkingDirectory, _cert.Path ?? string.Empty);
            if (!File.Exists(cert)) throw new Exception("Не найден SSL-сертификат: " + cert);
            builder.WebHost.ConfigureKestrel(opt =>
            {
                opt.ListenAnyIP(Port, listen =>
                {
                    listen.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                    listen.UseHttps(new X509Certificate2(cert, _cert.Password));
                });
            });
        }
        else if (_ssl)
            builder.WebHost.ConfigureKestrel(opt =>
            {
                opt.ListenAnyIP(Port, listen =>
                {
                    listen.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                    listen.UseHttps(Cerberus.Certificate());
                });
            });

        else
            builder.WebHost.ConfigureKestrel(opt =>
            {
                opt.ListenAnyIP(Port);
            });

        var srv = builder.Services;
        srv.AddCors(opt =>
            opt.AddPolicy(CORSPOLICENAME, police => // Политика для всех узлов -->
                police.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

        srv.AddSingleton(Runtime);
        srv.AddSingleton(_md);

        ConfigureServices(srv);

        if (!string.IsNullOrWhiteSpace(_path))
            srv.AddControllersWithViews(opt => opt.Conventions.Add(new XRoutePrefixConvention(_path)));

        srv.AddControllers() // Добавим контроллеры из сборки -->
            .AddApplicationPart(GetType().Assembly)
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;  // Выводит наименования параметров как есть, без изменения регистра букв
                opt.JsonSerializerOptions.IncludeFields = true;         // Включим в результат поля и свойства
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull;
            });

        srv.AddDistributedMemoryCache();
        srv.AddSession(opt =>
        {
            opt.Cookie.Name = ".lesev.session";
            opt.IdleTimeout = TimeSpan.FromMinutes(15);
            opt.Cookie.IsEssential = true;
        });

        _app = builder.Build();

        _app.UseExceptionHandler(appex => appex.Run(async ctx =>
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

        ConfigureApplication(_app);
        _app?.RunAsync().ConfigureAwait(false);
        return true;
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public virtual void ConfigureApplication(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(CORSPOLICENAME);
        app.UseAuthorization();
        app.UseSession();
        app.MapControllers();
    }

    public override void OnStop()
    {
        _app?.StopAsync().ConfigureAwait(false);
    }

    #region Nested types

    class XRoutePrefixConvention(string path) : IApplicationModelConvention
    {
        readonly AttributeRouteModel _path = new(new RouteAttribute(path));

        public void Apply(ApplicationModel application)
        {
            foreach (var sel in application.Controllers.SelectMany(c => c.Selectors))
                if (sel.AttributeRouteModel != null)
                    sel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_path, sel.AttributeRouteModel);
                else
                    sel.AttributeRouteModel = _path;
        }
    }

    #endregion Nested types
}
