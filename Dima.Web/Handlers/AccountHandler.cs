using System.Net.Http.Json;
using System.Text;
using Dima.Core.Handlers;
using Dima.Core.Requests.Account;
using Dima.Core.Responses;

namespace Dima.Web.Handlers;

public class AccountHandler(IHttpClientFactory httpClientFactory) 
    : IAccountHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    private const string IdentityPreffix = "v1/identity";

    public async Task<Response<string>> LoginAsync(LoginRequest request)
    {
        // .PostAsJsonAsync = faz com que o request vá no formato JSON 
        var result = await _client
            .PostAsJsonAsync($"{IdentityPreffix}/login?useCookies=true", request);

        return result.IsSuccessStatusCode
            ? new Response<string>(null, message: "Login realizado com sucesso!")
            : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o login!");
    }

    public async Task<Response<string>> RegisterAsync(RegisterRequest request)
    {
        var result = await _client
            .PostAsJsonAsync($"{IdentityPreffix}/register", request);

        return result.IsSuccessStatusCode
            ? new Response<string>(null, (int)result.StatusCode, message: "Cadastro realizado com sucesso!")
            : new Response<string>(null, (int)result.StatusCode, "Não foi possível realizar o cadastro!");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        await _client.PostAsJsonAsync($"{IdentityPreffix}/logout", emptyContent);
    }
}