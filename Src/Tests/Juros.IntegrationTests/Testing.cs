using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.WebApi;
using Juros.Application.Service;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Juros.Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "Application.WebApi"));

            startup.ConfigureServices(services);

            var currentApiService = services.FirstOrDefault(d =>
                d.ServiceType == typeof(IApiService));

            services.Remove(currentApiService);

            services.AddSingleton<IApiService, ApiServiceTest>();

            services.AddLogging();


            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        private class ApiServiceTest : IApiService
        {
            public async Task<decimal> GetTaxaJuros()
            {
                return await Task.FromResult(0.01m);
            }
        }


        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }
    }
}