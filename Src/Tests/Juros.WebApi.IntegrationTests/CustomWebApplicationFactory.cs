using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Juros.Application.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Juros.WebApi.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    //// Create a new service provider.
                    var serviceProvider = new ServiceCollection()
                        .BuildServiceProvider();

                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database
                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var currentApiService = services.FirstOrDefault(d =>
                        d.ServiceType == typeof(IApiService));

                    services.Remove(currentApiService);

                    services.AddSingleton<IApiService, ApiServiceTest>();


                })
                .UseEnvironment("Test");
        }

        private class ApiServiceTest : IApiService
        {
            public async Task<decimal> GetTaxaJuros()
            {
                return await Task.FromResult(0.01m);
            }
        }

        public async Task<HttpClient> GetClient()
        {
            var client = CreateClient();

            return client;
        }
    }
}