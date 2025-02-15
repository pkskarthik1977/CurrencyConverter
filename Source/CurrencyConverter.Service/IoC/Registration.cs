using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using CurrencyConverter.Abstracts.Services;
using CurrencyConverter.Service.Services;
using CurrencyConverter.Service.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: InternalsVisibleTo("CurrencyConverter.Service.Tests")]

namespace CurrencyConverter.Service.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceDataTypes(this IServiceCollection services)
        {
            services.AddHttpClient(@"CurrencyConverter", SetupDataServiceHttpClient);

            services.AddTransient<IFrankfurterService, FrankfurterService>();
            services.AddSingleton<IServiceManagerContext, ServiceManagerContext>();
            services.AddHttpClient(@"CurrencyConverter", SetupDataServiceHttpClient);

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="httpClient"></param>
        public static void SetupDataServiceHttpClient(IServiceProvider serviceProvider, HttpClient httpClient)
        {
            var serviceUrlSetting = serviceProvider.GetService<IOptions<ServiceUrlOption>>();
            if (string.IsNullOrWhiteSpace(serviceUrlSetting?.Value?.CurrencyConverter))
                throw new ArgumentException(@"IOptions<ServiceUrlSetting> is not registered");

            httpClient.BaseAddress = new Uri(serviceUrlSetting.Value.CurrencyConverter);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}