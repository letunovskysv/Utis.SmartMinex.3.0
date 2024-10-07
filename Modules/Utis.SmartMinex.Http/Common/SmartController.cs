//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SmartController – Базовый класс контроллера для доступа к данным.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Utis.SmartMinex.Runtime;
using Utis.SmartMinex.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
#endregion Using

namespace Utis.SmartMinex.Http;

/// <summary> Базовый класс контроллера для доступа к данным.</summary>
[ApiController]
public abstract class SmartController(IRuntime runtime, IMetadata metadata) : ControllerBase
{
    #region Declarations

    /// <summary> Настройки JSON-сериализатора.</summary>
    protected static JsonSerializerOptions _jsonOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        IncludeFields = true
    };

    protected readonly IRuntime _rtm = runtime;
    protected readonly IMetadata _md = metadata;
    protected Stopwatch _sw;

    #endregion Declarations

    #region Common methods

    /// <summary> Безопасное выполнение http-метода с логированием вызовов.</summary>
    protected Task<TResult> SafeExecuteGetOperation<TResult>(Func<TResult> operation, HttpStatusCode errorHttpStatusCode = HttpStatusCode.BadRequest)
    {
        try
        {
            _sw = Stopwatch.StartNew();
            try
            {
                return Task.FromResult(operation());
            }
            finally
            {
                _sw.Stop();
                HttpContext.Session.SetString("sw", _sw.ElapsedMilliseconds.ToString());
            }
        }
        catch (Exception ex)
        {
            throw new HttpApiException(errorHttpStatusCode, ex.Message);
        }
    }

    #endregion Common methods
}
