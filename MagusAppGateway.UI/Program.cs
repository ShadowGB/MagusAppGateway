using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MagusAppGateway.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("Oidc", options.ProviderOptions);
            });

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IUserService, UserService>("User", client => client.BaseAddress = new Uri(builder.Configuration["ServiceAddress"]))
                .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IRoleService, RoleService>("Role", client => client.BaseAddress = new Uri(builder.Configuration["ServiceAddress"]))
                .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IApiScopeService, ApiScopeService>("Api", client => client.BaseAddress = new Uri(builder.Configuration["ServiceAddress"]))
                .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IClientService, ClientService>("Client", client => client.BaseAddress = new Uri(builder.Configuration["ServiceAddress"]))
                .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("User"));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Role"));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Client"));

            // ÃÌº”BootStrap÷ß≥÷
            builder.Services.AddBootstrapBlazor(); 

            await builder.Build().RunAsync();
        }
    }
}
