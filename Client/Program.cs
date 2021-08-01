using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShamrockVault.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShamrockVault.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("ShamrockVault.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ShamrockVault.ServerAPI"));

            builder.Services.AddApiAuthorization();

            string apiDir = "https://localhost:44343/api/";
            builder.Services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(apiDir);
            });

            builder.Services.AddHttpClient<IUserRoleService, UserRoleService>(client =>
            {
                client.BaseAddress = new Uri(apiDir);
            });

            builder.Services.AddHttpClient<IRoleService, RoleService>(client =>
            {
                client.BaseAddress = new Uri(apiDir);
            });

            await builder.Build().RunAsync();
        }
    }
}
