//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DataController – Доступ к данным.
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text.Encodings.Web;
using System.Text.Json;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Http;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.DataAccess;

public class DataController(IRuntime runtime, IMetadata metadata) : SmartController(runtime, metadata)
{
    #region For testing

    /// <summary> https://localhost:8087/api/data/catalog/division </summary>
    [HttpGet("[action]/{scope}/{name}/{format?}")]
    public Task<IActionResult> Data(string scope, string name, string? format, [FromQuery] string? where, [FromQuery] string? order) =>
        SafeExecuteGetOperation<IActionResult>(() =>
        {
            if (_md.TryGetObject(string.Concat(scope, ".", name), out var oi) && oi is TObject obj && obj.Model != null)
                if (string.IsNullOrEmpty(format))
                    return new ContentResult
                    {
                        ContentType = "application/json",
                        Content = JsonConvert.SerializeObject(_md.Select(obj, where, order))
                    };
                else
                    return new JsonResult(_md.Select(obj.Model, where, order), _jsonOptions);

            throw new Exception("Тип " + name + " не найден!");
        });

    /// <summary> https://localhost:8087/api/query/catalog/division </summary>
    [HttpGet("[action]/{scope}/{name}/{format?}")]
    public Task<IActionResult> Query(string scope, string name, string? format, [FromQuery] string? where, [FromQuery] string? order) =>
        SafeExecuteGetOperation<IActionResult>(() =>
        {
            if (_md.TryGetObject(string.Concat(scope, ".", name), out var oi) && oi is TObject obj && obj.Model != null)
                if (format == "query" || format == "q")
                    return new ContentResult
                    {
                        ContentType = "text/plain; charset=utf-8",
                        Content = _md.Query(obj, where, order)
                    };
                else
                    return new ContentResult
                    {
                        ContentType = "text/plain",
                        Content = _md.Query(obj.Model, where, order)
                    };

            throw new Exception("Тип " + name + " не найден!");
        });

    /// <summary> https://localhost:8087/api/stopwatch </summary>
    [HttpGet("[action]")]
    public Task<IActionResult> Stopwatch() =>
        Task.FromResult<IActionResult>(new ContentResult
        {
            ContentType = "text/html; charset=utf-8",
            Content = string.Concat("Время выполнения: ", HttpContext.Session.GetString("sw"), " мс")
        });

    #endregion For testing
}
