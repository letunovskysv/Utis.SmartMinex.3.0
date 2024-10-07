//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisAuthStateProvider –
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
#endregion Using

namespace Utis.SmartMinex.Client;

class UtisAuthStateProvider : AuthenticationStateProvider
{
    static readonly Task<AuthenticationState> defaultUnauthenticatedTask =
        Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

    readonly Task<AuthenticationState> authenticationStateTask = defaultUnauthenticatedTask;

    public UtisAuthStateProvider(PersistentComponentState state)
    {
        if (!state.TryTakeFromJson<UserAccount>(nameof(UserAccount), out var usr) || usr is null)
            return;

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()),
                new Claim(ClaimTypes.Name, usr.Email),
                new Claim(ClaimTypes.Email, usr.Email) ];

        authenticationStateTask = Task.FromResult(
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: nameof(UtisAuthStateProvider)))));
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationStateTask;
}
