using System.Net.Http.Json;
using System.Security.Claims;
using Dima.Core.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;

namespace Dima.Web.Security;

public class CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory)
    : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private const string IdentityPreffix = "v1/identity";
    private bool _isAuthenticated = false;
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<bool> CheckAuthenticatedAsync()
    {
        await GetAuthenticationStateAsync();
        return _isAuthenticated;
    }

    public void NotifyAuthenticationStateChanged()
        => base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;
        var user = new ClaimsPrincipal(new ClaimsIdentity());

        var userInfo = await GetUser();
        if (userInfo is null)
            return new AuthenticationState(user);

        var claims = await GetClaims(userInfo);

        var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
        user = new ClaimsPrincipal(id);
        _isAuthenticated = true;
        return new AuthenticationState(user);
    }

    private async Task<User?> GetUser()
    {
        try
        {
            return await _client.GetFromJsonAsync<User>($"{IdentityPreffix}/manage/info");
        }
        catch
        {
            return null;
        }
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.Email, user.Email)
        ];

        claims.AddRange(user.Claims
            .Where(x => x.Key is not ClaimTypes.Name and ClaimTypes.Email)
            .Select(x => new Claim(x.Key, x.Value)));

        RoleClaim[]? roles;
        try
        {
            roles = await _client.GetFromJsonAsync<RoleClaim[]>($"{IdentityPreffix}/roles");
        }
        catch
        {
            return claims;
        }

        claims.AddRange(roles
            ?.Where(x => !string.IsNullOrEmpty(x.Type) && !string.IsNullOrEmpty(x.Value))
            .Select(x => new Claim(
                x.Type!,
                x.Value!,
                x.ValueType,
                x.Issuer,
                x.OriginalIssuer)) ?? []);

        return claims;
    }
}