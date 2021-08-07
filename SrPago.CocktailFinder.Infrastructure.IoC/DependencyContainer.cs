using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using SrPago.CocktailFinder.Application.Interfaces;
using SrPago.CocktailFinder.Application.Services;
using SrPago.CocktailFinder.Domain.Interfaces;
using SrPago.Infrastructure.Data.Repository;
using System;
using System.Net.Http;

namespace SrPago.CocktailFinder.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddHttpClient<ICategoryOptionRepository, CategoryOptionRepository>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            services.AddHttpClient<IElementDetailRepository, ElementDetailtRepository>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            services.AddHttpClient<IElementRepository, ElementRepository>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());


            //CocktailFinder.Application
            services.AddScoped<ICategoryOptionService, CategoyOptionService>();
            services.AddScoped<IElementDetailService, ElementDetailService>();
            services.AddScoped<IElementService, ElementService>();

            //CocktailFinder.Domain.Interfaces => CocktailFinder.Data.Repository
            services.AddScoped<ICategoryOptionRepository, CategoryOptionRepository>();
            services.AddScoped<IElementDetailRepository, ElementDetailtRepository>();
            services.AddScoped<IElementRepository, ElementRepository>();

        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(2, retryAttemp =>
                {
                    //Implement exponential wait times
                    var timeToWait = TimeSpan.FromSeconds(Math.Pow(2, retryAttemp));
                    return timeToWait;
                });
        }
    }
}
