//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: HttpApiException –
// Статусы: https://learn.microsoft.com/ru-ru/dotnet/api/system.net.httpstatuscode?view=net-7.0
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net;
#endregion Using

namespace Utis.SmartMinex.Http;

/// <summary> Исключение, с которым связан код состояния HTTP.</summary>
public class HttpApiException : WebException
{
    public HttpStatusCode StatusCode;
    public WebHeaderCollection Headers;

    public HttpApiException(HttpStatusCode statusCode, string message = null)
        : base(message, WebExceptionStatus.ConnectionClosed)
    {
        StatusCode = statusCode;
    }

    public HttpApiException(HttpStatusCode statusCode, string keyHeader, string valueHeader)
        : base(null, WebExceptionStatus.ConnectionClosed)
    {
        StatusCode = statusCode;
        Headers = new WebHeaderCollection
        {
            { keyHeader, valueHeader }
        };
    }
}
