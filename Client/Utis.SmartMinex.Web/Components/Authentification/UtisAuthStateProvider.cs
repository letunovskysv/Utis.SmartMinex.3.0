//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisAuthStateProvider –
// Blazor Authentication and Authorization:
// https://gist.github.com/SteveSandersonMS/175a08dcdccb384a52ba760122cd2eda
// ASP.NET Core Blazor authentication and authorization:
// https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-8.0
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
#endregion Using

namespace Utis.SmartMinex.Client;

class UtisAuthStateProvider(IDispatcher dsp, IJSRuntime jsRuntime) : ServerAuthenticationStateProvider
{
    #region Declarations

    const string SECURITY_TOKEN = "sessionToken";
    const string SESSION_ID = "sid";
    const string SESSION_MACHINE = "mac";
    const string SESSION_USER = "usr";
    const string SESSION_PASS = "pwd";

    static int _sessionCounter = 0;

    static readonly SigningCredentials CREDENTIALS = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Utis.SmartMinex.SecurityKey.7Hfp0nvthm!")), SecurityAlgorithms.HmacSha256);

    readonly IDispatcher _dsp = dsp;
    readonly IJSRuntime _jsr = jsRuntime;

    #endregion Declarations

    public async Task<AuthenticationState?> Logon(string username, string password, string machine, int? idSession = null)
    {
        if (await _dsp.Authentificate(username, password) is UserAccount userAccount)
        {
            var tkn = CreateToken((idSession ?? ++_sessionCounter).ToString(), username, password, machine);
            return await SetTokenAsync(tkn, userAccount);
        }
        return null;
    }

    /// <summary> Автоматическая аутентификация на основании выданного ранее токена безопасности (сессии).</summary>
    public async Task<AuthenticationState>? AutoLogon()
    {
        var tkn = await GetTokenAsync();
        if (tkn != null)
        {
            var claims = ParseClaimsFromJwt(tkn);
            var machine = claims.FirstOrDefault(c => c.Type == SESSION_MACHINE)?.Value;
            var username = claims.FirstOrDefault(c => c.Type == SESSION_USER)?.Value;
            var password = claims.FirstOrDefault(c => c.Type == SESSION_PASS)?.Value;
            if (int.TryParse(claims.FirstOrDefault(c => c.Type == SESSION_ID)?.Value, out int sid) && username != null && password != null)
                return await Logon(username, password, machine, sid);
        }
        return null;
    }

    public void Logout() => SetTokenAsync(null, null).ConfigureAwait(false);

    public async Task<AuthenticationState> GetAuthenticationStateAsync(UserAccount? userAccount)
    {
        var tkn = await GetTokenAsync();
        if (tkn == null)
            return new AuthenticationState(new ClaimsPrincipal());

        var idSession = ParseClaimsFromJwt(tkn).FirstOrDefault(c => c.Type == SESSION_ID)?.Value;
        var username = ParseClaimsFromJwt(tkn).FirstOrDefault(c => c.Type == SESSION_USER)?.Value;

        var claims = new[]
        {
                    new Claim(SESSION_ID, idSession),
                    new Claim(ClaimTypes.Name, username)
            };
        var ident = new ClaimsIdentity(claims, "auth")
        {
            Label = userAccount.Name
        };
        return new AuthenticationState(new ClaimsPrincipal(ident));
    }

    static string CreateToken(string idSession, string username, string password, string machine) =>
        new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(claims: new[] {
                new Claim(SESSION_ID, idSession),
                new Claim(SESSION_MACHINE, machine),
                new Claim(SESSION_USER, username),
                new Claim(SESSION_PASS, password)
        }, signingCredentials: CREDENTIALS));

    async Task<string> GetTokenAsync() =>
        await _jsr.InvokeAsync<string>(WellKnownJS.GetSessionItem, SECURITY_TOKEN);

    Task<AuthenticationState> SetTokenAsync(string? token, UserAccount? userAccount)
    {
        if (token == null)
        {
            _jsr.InvokeAsync<object>(WellKnownJS.RemoveSessionItem, SECURITY_TOKEN);
        }
        else
            _jsr.InvokeAsync<object>(WellKnownJS.SetSessionItem, SECURITY_TOKEN, token);

        var state = GetAuthenticationStateAsync(userAccount);
        SetAuthenticationState(state);
        return state;
    }

    static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        try
        {
            var payload = jwt?.Split('.')[1];
            if (!string.IsNullOrEmpty(payload))
            {
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
                return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
            }
        }
        catch (IndexOutOfRangeException)
        {
        }
        catch (FormatException)
        {
        }
        catch (JsonException)
        {
        }
        return Array.Empty<Claim>();
    }

    static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
