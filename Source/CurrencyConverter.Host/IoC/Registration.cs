using System.Runtime.CompilerServices;
using CurrencyConverter.Data.IoC;
using CurrencyConverter.Domain.IoC;
using CurrencyConverter.Service.IoC;

[assembly: InternalsVisibleTo("CurrencyConverter.Tests")]

namespace CurrencyConverter.Host.IoC
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
        public static IServiceCollection RegisterHostTypes(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            services
                .AddSingleton(_ => configuration)
                .AddSingleton(_ => hostEnvironment)
                //.RegisterCommonTypes<Startup>(typeof(RequestPreProcessor<>))
                .RegisterDataTypes()
                .RegisterDomainTypes()
                .RegisterServiceDataTypes();
                //.RegisterServiceApis<Startup>();

            return services;
        }
    }
}