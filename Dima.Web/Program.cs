using System.Globalization;
using Dima.Core.Handlers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Dima.Web;
using Dima.Web.Handlers;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl")!;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();
builder.Services
    .AddHttpClient(
        Configuration.HttpClientName, 
        options => options.BaseAddress = new Uri(Configuration.BackendUrl))
    .AddHttpMessageHandler<CookieHandler>(); 
// O método AddHttpMessageHandler<CookieHandler>() faz com que cada requisição
// HTTP enviada através desse cliente passe pelo CookieHandler personalizado.

builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

builder.Services.AddLocalization(); // Permite que sua aplicação use recursos de localização
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR"); // Define a cultura para formatação de números, datas, moedas, etc.
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR"); // Define a cultura para textos e recursos de interface do usuário

await builder.Build().RunAsync();