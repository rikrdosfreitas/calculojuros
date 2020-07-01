using System.Net.Http;
using System.Reflection;
using AutoMapper;
using Juros.Application.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Juros.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHttpClient();

            services.AddSingleton<IApiService>(sp =>
            {
                return new ApiService(sp.GetRequiredService<IHttpClientFactory>(), "http://localhost:5000");
            });

            return services;
        }
    }
}
